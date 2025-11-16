using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.Util.TypeEnum;
using Emgu.CV.Structure;

namespace Origami
{
    public partial class MainForm : Form
    {
        OrigamiStart startStep = null;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
         //   Image<Bgr, byte> gry = new Image<Bgr, byte>(@"f:\\tmpdata\\111.png");
        //    gry.Resize(0.25, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR).Save(@"f:\\tmpdata\\222.png");
            //Image<Gray, byte> gray = new Image<Gray, byte>(@"E:\个人科研成果\机器视觉\项目--老黄--测试软件\线扫尺寸测量系统\testlineProduct\X64\xianquan\123.png");
            //gray = gray.Resize(8, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            //gray.Save(@"E:\个人科研成果\机器视觉\项目--老黄--测试软件\线扫尺寸测量系统\testlineProduct\X64\xianquan\456.png");
            splitContainer2.SplitterDistance = splitContainer2.Height * 4 / 5;
            foreach (string name in Enum.GetNames(typeof(PaperType)))
            {
                comboBox1.Items.Add(name);
            }
            comboBox1.SelectedIndex = 0;
            //for (int i = 0; i < 8; i++)
            //    comboBox1.Items.Add("类型" + (i+1));
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

        private void btnTest1_Click(object sender, EventArgs e)
        {
            GenSample1();
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            GenSample2();
        }

        private void btnTest3_Click(object sender, EventArgs e)
        {
            GenSample3();
        }

        private void btnTest4_Click(object sender, EventArgs e)
        {
            GenSample4();
        }

        private void btnTest5_Click(object sender, EventArgs e)
        {

            GenSample5();
            
        }

        private void btnTest6_Click(object sender, EventArgs e)
        {

            GenSample6();

 
        }

        private OrigamiStart GenStartStep()
        {
            int typeId = comboBox1.SelectedIndex;
            OrigamiStart startStep = new OrigamiStart(new Size(360, 360), OrigamiPaperType.UnRegular, OrigamiPaper.CreatePaper((PaperType)typeId));
 
       
            return startStep;
        }

        private void GenSample1()
        {
            startStep = GenStartStep();

            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.5f, new LineSegment2DF()));
            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Vert_Top, 0.5f, new LineSegment2DF()));
            
            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);

        }

        private void GenSample2()
        {
            startStep = GenStartStep();
           
            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.5f, new LineSegment2DF()));
            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.5f, new LineSegment2DF()));
            OrigamiFolding step3 = new OrigamiFolding();
            startStep.AppendLastStep(step3);
            step3.DoClip(new FoldingParam(FoldingType.Vert_Top, 0.5f, new LineSegment2DF()));

            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
        }

        private void GenSample3()
        {
            startStep = GenStartStep();
            
            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.35f, new LineSegment2DF()));

            OrigamiFolding step2 = new OrigamiFolding();
            step1.AppendStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Vert_Bottom, 0.45f, new LineSegment2DF()));

            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
        }

        private void GenSample4()
        {
            startStep = GenStartStep();
            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(360, 0), new PointF(0, 360))));


            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(180, 180), new PointF(360, 360))));

            OrigamiFolding step3 = new OrigamiFolding();
            startStep.AppendLastStep(step3);
            step3.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(180, 180), new PointF(360, 180))));


            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
            //picStep.Image = cutStep.RenderAnswer();

        }

        private  void GenSample5()
        {
            startStep = GenStartStep();

            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Vert_Bottom, 0.3333333333333f, new LineSegment2DF()));
            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Vert_Top, 0.5f, new LineSegment2DF()));
            OrigamiFolding step3 = new OrigamiFolding();
            startStep.AppendLastStep(step3);
            step3.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.5f, new LineSegment2DF()));

            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
        }


        private void GenSample6()
        {
            startStep = GenStartStep();

            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(160, 0), new PointF(0, 160))));
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(360, 160), new PointF(200, 0))));
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(200, 360), new PointF(360, 200))));
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(0, 200), new PointF(160, 360))));
            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.25f, new LineSegment2DF()));
            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
        }


        private void GenSample7()
        {
            startStep = GenStartStep();

            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(160, 0), new PointF(0, 160))));
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(360, 160), new PointF(200, 0))));
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(200, 360), new PointF(360, 200))));
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(0, 200), new PointF(160, 360))));
            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Hori_Left, 0.8f, new LineSegment2DF()));
            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
        }

        private void GenSample8()
        {
            startStep = GenStartStep();


            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Hori_Right, 0.5f, new LineSegment2DF()));
            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Vert_Top, 0.5f, new LineSegment2DF()));

            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);

        }

        private void btnTestHole_Click(object sender, EventArgs e)
        {
            try
            {
                
              List<OrigamiStep> stepList =  OrigamiEngine.ParseFile(Application.StartupPath + "\\Templates\\square.xml");
              if (stepList.Count > 0)
              {
                  List<Image> imgList = OrigamiEngine.RenderImageList(stepList[stepList.Count-1] as OrigamiStart, true);
                  imageListControl1.BindImages(imgList);
              }
            }
            catch
            { }
         //   GenSampleHole();
        }

        private void GenSampleHole()
        {
            try
            {
                // 使用 GraphicsPath 创建圆形区域

                GraphicsPath circlePath = new GraphicsPath();
                Rectangle circleRect = new Rectangle(100, 100, 200, 200);
                circlePath.AddEllipse(circleRect);
                Region circleRegion = new Region(circlePath);

                // 使用 GraphicsPath 创建方形区域
                GraphicsPath squarePath = new GraphicsPath();
                Rectangle squareRect = new Rectangle(150, 150, 200, 200);
                squarePath.AddRectangle(squareRect);
                Region squareRegion = new Region(squarePath);

                // 计算交集区域
                Region intersectionRegion = circleRegion.Clone();
                intersectionRegion.Intersect(squareRegion);

                Bitmap bmp = new Bitmap(800, 600);
                Graphics memDc = Graphics.FromImage(bmp);

                // 用特定颜色填充交集区域
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    memDc.FillRegion(brush, intersectionRegion);
                }

                // 创建一个矩阵并进行刚性变换（这里进行平移和旋转）
                Matrix transformMatrix = new Matrix();
                transformMatrix.Translate(200, 100);
                transformMatrix.Rotate(45);

                // 对交集区域应用矩阵变换
                intersectionRegion.Transform(transformMatrix);

                // 用另一种颜色填充变换后的交集区域
                using (SolidBrush transformedBrush = new SolidBrush(Color.Blue))
                {
                    memDc.FillRegion(transformedBrush, intersectionRegion);
                }

                // 释放资源
                circlePath.Dispose();
                squarePath.Dispose();
                circleRegion.Dispose();
                squareRegion.Dispose();
                intersectionRegion.Dispose();
                transformMatrix.Dispose();
                picStep.Image = bmp;
            }
            catch
            { }
 
        }

        private void btnTest8_Click(object sender, EventArgs e)
        {
            GenSample8();
        }

        private void btnTest7_Click(object sender, EventArgs e)
        {
            GenSample7();
        }

        private void btnExtraTest1_Click(object sender, EventArgs e)
        {
            GenSampleExtra1();
        }

        private void GenSampleExtra1()
        {
            startStep = GenStartStep();
            OrigamiFolding step1 = new OrigamiFolding();
            startStep.AppendLastStep(step1);
            step1.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(360, 0), new PointF(0, 360))));


            OrigamiFolding step2 = new OrigamiFolding();
            startStep.AppendLastStep(step2);
            step2.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(180, 360), new PointF(360, 180))), 1);

            OrigamiFolding step3 = new OrigamiFolding();
            startStep.AppendLastStep(step3);
            step3.DoClip(new FoldingParam(FoldingType.Angle, 1f, new LineSegment2DF(new PointF(360, 90), new PointF(90, 360))), 1);



            OrigamiCut cutStep = new OrigamiCut();
            startStep.AppendLastStep(cutStep);
            cutStep.RandAddObj();

            List<Image> imgList = OrigamiEngine.RenderImageList(startStep, true);
            imageListControl1.BindImages(imgList);
            //picStep.Image = cutStep.RenderAnswer();

        }

        private void templateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplateForm frm = new TemplateForm();
            frm.ShowDialog();
        }

        private void exportDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm frm = new ExportForm();
            frm.ShowDialog();
        }

        private void exportTypeCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTypeCForm frm = new ExportTypeCForm();
            frm.ShowDialog();
        }

        private void exportTypeBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportTypeBForm frm = new ExportTypeBForm();
            frm.ShowDialog();
        }

        private void template3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Template3DForm frm = new Template3DForm();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

    }
}
