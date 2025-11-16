using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Origami
{
    public partial class TemplateForm : Form
    {
        private List<OrigamiStep> _stepList = new List<OrigamiStep>();
        public TemplateForm()
        {
            InitializeComponent();
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height * 4 / 5;

            LoadTemplate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchTemplate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SwitchFolding();
        }

        private void LoadTemplate()
        {
            try
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
                foreach (string filePath in xmlFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    comboBox1.Items.Add(fileName);
                }
            }
            catch { }
        }

        private void SwitchTemplate()
        {
            try
            {
                if (comboBox1.SelectedIndex >= 0)
                {
                    string path = Application.StartupPath + "\\Templates\\" + comboBox1.SelectedItem.ToString() + ".xml";
                    _stepList = OrigamiEngine.ParseFile(path);
                    listBox1.Items.Clear();
                    for (int i = 0; i < _stepList.Count; i++)
                        listBox1.Items.Add("" + i + ": 折叠次数：" + (_stepList[i] as OrigamiStart).GetFoldingCount());
                    listBox1.SelectedIndex = -1;
                    if (_stepList.Count > 0)
                        listBox1.SelectedIndex = 0;

                }
            }
            catch
            { }
        }

        private void SwitchFolding()
        {
            try
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    OrigamiStart startStep = _stepList[listBox1.SelectedIndex] as OrigamiStart;
                    List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
                    if (checkConfuse.Checked)
                        imgList.AddRange(startStep.GetConfuseImageList());
                    imageListControl1.BindImages(imgList);


                    if(imgList.Count>0)
                        imageListControl1.SelectedIndex = 0;
 
                }
            }
            catch
            { }
        }

        private void imageListControl1_SelectedImageChanged(object sender, EventArgs e)
        {
            try
            {
                picStep.Image = imageListControl1.SelectedImage;
            }
            catch
            { }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            int id = listBox1.SelectedIndex;
            SwitchTemplate();
            if (id >= 0 && listBox1.Items.Count > id)
                listBox1.SelectedIndex = id;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex >= 0)
                {
                    CandidateForm frm = new CandidateForm(_stepList[listBox1.SelectedIndex] as OrigamiStart);
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //导出选项：4-6个候选答案。 用户待选
            //导出一折，二折，三折，
            //答案分文件夹列表
            //AAAAA-BBB-X-CCCC--DD
            /*
             *  AAAA纸张类别
             *  BBBB，折纸的过程类别
             *  X, 1,2,3折
             *  CCCC--样本的索引
             *  DD--对应的真实答案位置A,B,C,D,E,F等等。
             *  
             * 图形，第一行问题，第二行，候选答案。
             *  
             * 确定图像大小。待定， 按文件夹存储
             * 
             * 
             */
            ExportForm frm = new ExportForm();
            frm.ShowDialog();
        }



    }
}
