using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Origami
{
    public partial class ExportForm : Form
    {

        CheckBox[] _checkTemplates;
        exportSetting _exportSetting = new exportSetting();
        string[] _exts = new string[] { ".png", ".jpg", ".bmp" };
        public ExportForm()
        {
            InitializeComponent();
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            InitTemplateUI();
            string path = Application.StartupPath + "\\数据集";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "\\Type-A";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "\\" + DateTime.Now.ToString("yyyy-MM-dd");//_HH-mm-ss");
                DateTime now = DateTime.Now;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            textPath.Text = path;
            progressBar1.Visible = false;
            foreach(string ext in _exts)
                comboBox1.Items.Add(ext);
            comboBox1.SelectedIndex = 0;

        }

        private void InitTemplateUI()
        {
            List<string> result = new List<string>();
            string path = Application.StartupPath + "\\Templates";

            if (!Directory.Exists(path))
            {
                return;
            }

            // 获取所有XML文件（搜索模式支持大小写不敏感）
            string[] xmlFiles = Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly);

            // 提取文件名（不含扩展名）
            List<CheckBox> checkList = new List<CheckBox>();
            foreach (string filePath in xmlFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                CheckBox check = new CheckBox();
                check.Text = fileName;
                check.Parent = groupBox2;
                check.Location = new Point(30, 20 + (check.Height + 10) * checkList.Count);
                checkList.Add(check);
            }
            _checkTemplates = checkList.ToArray();
                 
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                textPath.Text = dlg.SelectedPath;

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;

            _exportSetting._templateList.Clear();

            foreach (CheckBox check in _checkTemplates)
                if (check.Checked)
                    _exportSetting._templateList.Add(check.Text);

            _exportSetting._foldingExportParams[0]._enable = checkBox1.Checked;
            _exportSetting._foldingExportParams[1]._enable = checkBox2.Checked;
            _exportSetting._foldingExportParams[2]._enable = checkBox3.Checked;

            _exportSetting._foldingExportParams[0]._exportNum = GlobalUtils.IntParse(textBox1.Text);
            _exportSetting._foldingExportParams[1]._exportNum = GlobalUtils.IntParse(textBox2.Text);
            _exportSetting._foldingExportParams[2]._exportNum = GlobalUtils.IntParse(textBox3.Text);

            _exportSetting._foldingExportParams[0]._candidateNum = GlobalUtils.IntParse(textBox6.Text);
            _exportSetting._foldingExportParams[1]._candidateNum = GlobalUtils.IntParse(textBox5.Text);
            _exportSetting._foldingExportParams[2]._candidateNum = GlobalUtils.IntParse(textBox4.Text);

            _exportSetting._path = textPath.Text;
            _exportSetting._ext = comboBox1.SelectedItem.ToString();

            if (_exportSetting._templateList.Count == 0)
            {
                MessageBox.Show("没有选择任何模版！");
                return;
            }
            if (!_exportSetting._foldingExportParams[0]._enable && !_exportSetting._foldingExportParams[1]._enable && !_exportSetting._foldingExportParams[2]._enable)
            {
                MessageBox.Show("没有选择任何折叠！");
                return;
            }
            
            _stopExport = false;

            (new Thread(DoExport)).Start();
            btnExport.Enabled = false;
            progressBar1.Value = 0;
        }

        private bool _isExporting = false;

        private bool _stopExport = false;

        private void DoExport()
        {
            _isExporting = true;
            int id = 0;
            int totalNum = 0;
            Image unknowImg = Bitmap.FromFile(Application.StartupPath+"\\unknown.bmp");
            
            string savePath = _exportSetting._path;
            string jsonlPath = savePath+ "\\answer.jsonl"; // 输出文件路径
            StreamWriter writer = new StreamWriter(jsonlPath);
            foreach (string template in _exportSetting._templateList)
            {
                string path = Application.StartupPath + "\\Templates\\" + template + ".xml";
                List<OrigamiStep>   stepList = OrigamiEngine.ParseFile(path);

                for (int i = 0; i < stepList.Count; i++)
                {
                    progressBar1.Value = (int)(100*( (id + (float) (i)/stepList.Count)   / _exportSetting._templateList.Count));
                    Thread.Sleep(50);
                    int nfolderTime = (stepList[i] as OrigamiStart).GetFoldingCount();

                    OrigamiStart startStep = stepList[i] as OrigamiStart;

                    if (_stopExport)
                        break;

                    if (nfolderTime > 0 && nfolderTime < 4)
                    {
                        FoldingExportParam foldingParam = _exportSetting._foldingExportParams[nfolderTime - 1];
                        try
                        {
                            if (foldingParam._enable)
                            {
                                int num = foldingParam._exportNum;
                                
                                int candidateNum = foldingParam._candidateNum;

                                OrigamiCut cutStep = startStep.GetLastStep() as OrigamiCut;
                                List<Image> foldBmpList = OrigamiEngine.RenderImageList(startStep, false);
                                foldBmpList.RemoveAt(foldBmpList.Count - 1);

                                List<OrigamiCutObjs> cutObjsList = OrigamiConfuseScheme.RandomCreateCutObjsList(cutStep, num);
                                
                                if (cutStep != null)
                                {
                                    for (int k = 0; k < cutObjsList.Count; k++)
                                    {
                                        cutStep._cutObjs = cutObjsList[k];
                                        OrigamiConfuseScheme.RenderOneFold(cutStep, candidateNum);
                                        if (cutStep._cutObjs._candidateList.Count < 4)
                                            continue;

                                        List<Image> imgList = new List<Image>();
                                        imgList.AddRange(foldBmpList);
                                        imgList.Add(cutStep.Render());
                                        if (cutStep._cutObjs._candidateList.Count > 0)
                                            imgList.AddRange(cutStep._cutObjs._candidateList);

                                        List<Image> firstRow = new List<Image>();
                                        firstRow.AddRange(foldBmpList);
                                        firstRow.Add(cutStep.Render());
                                        firstRow.Add(unknowImg);



                                        List<Image> candidates = new List<Image>();
                                        candidates.AddRange(cutStep._cutObjs._candidateList);
                                        List<int> tmpList = new List<int>();
                                        candidates = ShuffleImages(candidates, out tmpList);
                                        Bitmap result = ImageComposer.Compose(firstRow, candidates);
                                        char answer = (char)('A' + tmpList[0]);
                                        string filename = template + "-id_" + i + "-fold_" + nfolderTime + "-sample_" + k + "-candidate_" + candidates.Count + "-answ_" + answer + _exportSetting._ext;
                                      //  result.Save("test\\" + Environment.TickCount+".bmp" );
                                        result.Save(savePath + "\\" + filename );

                                        string jsonLine = string.Format(
                                          "{{\"image\":\"{0}\",\"answer\":\"{1}\"}}",
                                          filename,
                                          answer
                                        );
                                        writer.WriteLine(jsonLine);
                                        Thread.Sleep(5);

                                        totalNum++;
                                    }
                                }

                            }
                        }
                        catch
                        { }
                    }
                }
                id++;
                if (_stopExport)
                    break;
            }
            _isExporting = false;
            writer.Flush();
            writer.Close();
            if (!_stopExport)
            {
                progressBar1.Value = 100;

                Invoke(new Action(() =>
                {
                    // 恢复按钮状态
                    btnExport.Enabled = true;
                    // 显示模态对话框（会阻塞主窗口消息循环）
                    MessageBox.Show(this, "导出工程结束！导出数量:" + totalNum, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 对话框关闭后，主窗口才会恢复响应
                }));
            }
            else
            {

                Invoke(new Action(() =>
                {
                    // 恢复按钮状态
                    btnExport.Enabled = true;
                    // 显示模态对话框（会阻塞主窗口消息循环）
                    MessageBox.Show(this, "导出工程已终止！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 对话框关闭后，主窗口才会恢复响应
                }));
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _stopExport = true;
            Thread.Sleep(300);
        }


        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isExporting)
            {
                e.Cancel = true;
                MessageBox.Show("请先停止数据导出！");
            }
        }

        Random _random = new Random(Environment.TickCount);
        public  List<Image> ShuffleImages(List<Image> candidates, out List<int> originalIndices)
        {
            int count = candidates.Count;

            // 创建原始索引数组（初始化为 -1）
            originalIndices = new List<int>(new int[count]);
            for (int i = 0; i < count; i++)
            {
                originalIndices[i] = -1;
            }

            // 创建随机数生成器
            

            // 创建新列表并复制原列表元素
            List<Image> shuffledList = new List<Image>(candidates);

            // Fisher-Yates 洗牌算法
            for (int i = count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);

                // 交换图片
                Image temp = shuffledList[i];
                shuffledList[i] = shuffledList[j];
                shuffledList[j] = temp;
            }

            // 记录每个原始索引在新列表中的位置
            for (int newIndex = 0; newIndex < count; newIndex++)
            {
                Image image = shuffledList[newIndex];
                int originalIndex = candidates.IndexOf(image);
                originalIndices[originalIndex] = newIndex;
            }

            return shuffledList;
        }

        static void WriteData(string filePath, string imagePath, string answer)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                    string jsonLine = string.Format(
                      "{{\"image\":\"{0}\",\"answer\":\"{1}\"}}",
                      imagePath,
                      answer
                  );
                    writer.WriteLine(jsonLine);


            }
        }
    }
}
