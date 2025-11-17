namespace Origami
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逆推BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逆推CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTypeBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTypeCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.picStep = new System.Windows.Forms.PictureBox();
            this.imageListControl1 = new Origami.ImageListControl();
            this.btnExtraTest1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnTest7 = new System.Windows.Forms.Button();
            this.btnTest8 = new System.Windows.Forms.Button();
            this.btnTestHole = new System.Windows.Forms.Button();
            this.btnTest6 = new System.Windows.Forms.Button();
            this.btnTest5 = new System.Windows.Forms.Button();
            this.btnTest4 = new System.Windows.Forms.Button();
            this.btnTest3 = new System.Windows.Forms.Button();
            this.btnTest2 = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.d2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.template3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStep)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.d2DToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(941, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.逆推BToolStripMenuItem,
            this.逆推CToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(52, 28);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            this.templateToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.templateToolStripMenuItem.Text = "2D Templates";
            this.templateToolStripMenuItem.Click += new System.EventHandler(this.templateToolStripMenuItem_Click);
            // 
            // 逆推BToolStripMenuItem
            // 
            this.逆推BToolStripMenuItem.Name = "逆推BToolStripMenuItem";
            this.逆推BToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.逆推BToolStripMenuItem.Text = "Reverse B";
            // 
            // 逆推CToolStripMenuItem
            // 
            this.逆推CToolStripMenuItem.Name = "逆推CToolStripMenuItem";
            this.逆推CToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.逆推CToolStripMenuItem.Text = "Reverse C";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDatasetToolStripMenuItem,
            this.exportTypeBToolStripMenuItem,
            this.exportTypeCToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(78, 28);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportDatasetToolStripMenuItem
            // 
            this.exportDatasetToolStripMenuItem.Name = "exportDatasetToolStripMenuItem";
            this.exportDatasetToolStripMenuItem.Size = new System.Drawing.Size(165, 28);
            this.exportDatasetToolStripMenuItem.Text = "Export Type A";
            this.exportDatasetToolStripMenuItem.Click += new System.EventHandler(this.exportDatasetToolStripMenuItem_Click);
            // 
            // exportTypeBToolStripMenuItem
            // 
            this.exportTypeBToolStripMenuItem.Name = "exportTypeBToolStripMenuItem";
            this.exportTypeBToolStripMenuItem.Size = new System.Drawing.Size(165, 28);
            this.exportTypeBToolStripMenuItem.Text = "Export Type B";
            this.exportTypeBToolStripMenuItem.Click += new System.EventHandler(this.exportTypeBToolStripMenuItem_Click);
            // 
            // exportTypeCToolStripMenuItem
            // 
            this.exportTypeCToolStripMenuItem.Name = "exportTypeCToolStripMenuItem";
            this.exportTypeCToolStripMenuItem.Size = new System.Drawing.Size(165, 28);
            this.exportTypeCToolStripMenuItem.Text = "Export Type C";
            this.exportTypeCToolStripMenuItem.Click += new System.EventHandler(this.exportTypeCToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExtraTest1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest7);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest8);
            this.splitContainer1.Panel2.Controls.Add(this.btnTestHole);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest6);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest5);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest4);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest3);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest2);
            this.splitContainer1.Panel2.Controls.Add(this.btnTest1);
            this.splitContainer1.Size = new System.Drawing.Size(941, 603);
            this.splitContainer1.SplitterDistance = 683;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.picStep);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.imageListControl1);
            this.splitContainer2.Size = new System.Drawing.Size(683, 603);
            this.splitContainer2.SplitterDistance = 412;
            this.splitContainer2.TabIndex = 1;
            // 
            // picStep
            // 
            this.picStep.BackColor = System.Drawing.Color.Gray;
            this.picStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picStep.Location = new System.Drawing.Point(0, 0);
            this.picStep.Name = "picStep";
            this.picStep.Size = new System.Drawing.Size(683, 412);
            this.picStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStep.TabIndex = 0;
            this.picStep.TabStop = false;
            // 
            // imageListControl1
            // 
            this.imageListControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.imageListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListControl1.Location = new System.Drawing.Point(0, 0);
            this.imageListControl1.Name = "imageListControl1";
            this.imageListControl1.SelectedIndex = -1;
            this.imageListControl1.Size = new System.Drawing.Size(683, 187);
            this.imageListControl1.TabIndex = 0;
            this.imageListControl1.SelectedImageChanged += new System.EventHandler(this.imageListControl1_SelectedImageChanged);
            // 
            // btnExtraTest1
            // 
            this.btnExtraTest1.Location = new System.Drawing.Point(64, 542);
            this.btnExtraTest1.Name = "btnExtraTest1";
            this.btnExtraTest1.Size = new System.Drawing.Size(91, 36);
            this.btnExtraTest1.TabIndex = 11;
            this.btnExtraTest1.Text = "Special Fold 1";
            this.btnExtraTest1.UseVisualStyleBackColor = true;
            this.btnExtraTest1.Click += new System.EventHandler(this.btnExtraTest1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Paper Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 9;
            // 
            // btnTest7
            // 
            this.btnTest7.Location = new System.Drawing.Point(64, 390);
            this.btnTest7.Name = "btnTest7";
            this.btnTest7.Size = new System.Drawing.Size(91, 36);
            this.btnTest7.TabIndex = 8;
            this.btnTest7.Text = "Fold 7";
            this.btnTest7.UseVisualStyleBackColor = true;
            this.btnTest7.Click += new System.EventHandler(this.btnTest7_Click);
            // 
            // btnTest8
            // 
            this.btnTest8.Location = new System.Drawing.Point(64, 445);
            this.btnTest8.Name = "btnTest8";
            this.btnTest8.Size = new System.Drawing.Size(91, 36);
            this.btnTest8.TabIndex = 7;
            this.btnTest8.Text = "Fold 8";
            this.btnTest8.UseVisualStyleBackColor = true;
            this.btnTest8.Click += new System.EventHandler(this.btnTest8_Click);
            // 
            // btnTestHole
            // 
            this.btnTestHole.Location = new System.Drawing.Point(64, 488);
            this.btnTestHole.Name = "btnTestHole";
            this.btnTestHole.Size = new System.Drawing.Size(91, 36);
            this.btnTestHole.TabIndex = 6;
            this.btnTestHole.Text = "Test Area";
            this.btnTestHole.UseVisualStyleBackColor = true;
            this.btnTestHole.Click += new System.EventHandler(this.btnTestHole_Click);
            // 
            // btnTest6
            // 
            this.btnTest6.Location = new System.Drawing.Point(64, 333);
            this.btnTest6.Name = "btnTest6";
            this.btnTest6.Size = new System.Drawing.Size(91, 36);
            this.btnTest6.TabIndex = 5;
            this.btnTest6.Text = "Fold 6";
            this.btnTest6.UseVisualStyleBackColor = true;
            this.btnTest6.Click += new System.EventHandler(this.btnTest6_Click);
            // 
            // btnTest5
            // 
            this.btnTest5.Location = new System.Drawing.Point(64, 276);
            this.btnTest5.Name = "btnTest5";
            this.btnTest5.Size = new System.Drawing.Size(91, 36);
            this.btnTest5.TabIndex = 4;
            this.btnTest5.Text = "Fold 5";
            this.btnTest5.UseVisualStyleBackColor = true;
            this.btnTest5.Click += new System.EventHandler(this.btnTest5_Click);
            // 
            // btnTest4
            // 
            this.btnTest4.Location = new System.Drawing.Point(64, 218);
            this.btnTest4.Name = "btnTest4";
            this.btnTest4.Size = new System.Drawing.Size(91, 36);
            this.btnTest4.TabIndex = 3;
            this.btnTest4.Text = "Fold 4";
            this.btnTest4.UseVisualStyleBackColor = true;
            this.btnTest4.Click += new System.EventHandler(this.btnTest4_Click);
            // 
            // btnTest3
            // 
            this.btnTest3.Location = new System.Drawing.Point(64, 157);
            this.btnTest3.Name = "btnTest3";
            this.btnTest3.Size = new System.Drawing.Size(91, 36);
            this.btnTest3.TabIndex = 2;
            this.btnTest3.Text = "Fold 3";
            this.btnTest3.UseVisualStyleBackColor = true;
            this.btnTest3.Click += new System.EventHandler(this.btnTest3_Click);
            // 
            // btnTest2
            // 
            this.btnTest2.Location = new System.Drawing.Point(64, 104);
            this.btnTest2.Name = "btnTest2";
            this.btnTest2.Size = new System.Drawing.Size(91, 36);
            this.btnTest2.TabIndex = 1;
            this.btnTest2.Text = "Fold 2";
            this.btnTest2.UseVisualStyleBackColor = true;
            this.btnTest2.Click += new System.EventHandler(this.btnTest2_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(64, 53);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(91, 36);
            this.btnTest1.TabIndex = 0;
            this.btnTest1.Text = "Fold 1";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // d2DToolStripMenuItem
            // 
            this.d2DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateToolStripMenuItem,
            this.template3DToolStripMenuItem});
            this.d2DToolStripMenuItem.Name = "d2DToolStripMenuItem";
            this.d2DToolStripMenuItem.Size = new System.Drawing.Size(80, 28);
            this.d2DToolStripMenuItem.Text = "3D/2D";
            // 
            // template3DToolStripMenuItem
            // 
            this.template3DToolStripMenuItem.Name = "template3DToolStripMenuItem";
            this.template3DToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.template3DToolStripMenuItem.Text = "3D Templates";
            this.template3DToolStripMenuItem.Click += new System.EventHandler(this.template3DToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem1});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.关于ToolStripMenuItem.Text = "About";
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(152, 28);
            this.关于ToolStripMenuItem1.Text = "About";
            this.关于ToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 635);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox picStep;
        private System.Windows.Forms.Button btnTest5;
        private System.Windows.Forms.Button btnTest4;
        private System.Windows.Forms.Button btnTest3;
        private System.Windows.Forms.Button btnTest2;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button btnTest6;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ImageListControl imageListControl1;
        private System.Windows.Forms.Button btnTestHole;
        private System.Windows.Forms.Button btnTest8;
        private System.Windows.Forms.Button btnTest7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnExtraTest1;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 逆推BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 逆推CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTypeBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTypeCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem template3DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
    }
}

