namespace IDE
{
    partial class XshdVisualEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XshdVisualEditor));
            this.label1 = new System.Windows.Forms.Label();
            this.FileTxtBox = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.FileInfomation = new System.Windows.Forms.GroupBox();
            this.FileExtensionTypeTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FileSizeTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SyntaxHighlightingTypeNameTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FileNameTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FileStructure = new System.Windows.Forms.GroupBox();
            this.Tv_File = new System.Windows.Forms.TreeView();
            this.VisualEditingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Edit = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBBox_Edit_FontProperties = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.colorPicker2 = new System.Windows.Forms.Button();
            this.TxtBox_Edit_Background = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.colorPicker1 = new System.Windows.Forms.Button();
            this.TxtBox_Edit_Foreground = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBox_Edit_keyname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Copyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.CodeEditingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.FileInfomation.SuspendLayout();
            this.FileStructure.SuspendLayout();
            this.VisualEditingPanel.SuspendLayout();
            this.Edit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.CodeEditingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件路径:";
            // 
            // FileTxtBox
            // 
            this.FileTxtBox.BackColor = System.Drawing.Color.Black;
            this.FileTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileTxtBox.ForeColor = System.Drawing.Color.White;
            this.FileTxtBox.Location = new System.Drawing.Point(91, 9);
            this.FileTxtBox.Name = "FileTxtBox";
            this.FileTxtBox.Size = new System.Drawing.Size(818, 20);
            this.FileTxtBox.TabIndex = 1;
            // 
            // Save
            // 
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Location = new System.Drawing.Point(724, 503);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(100, 29);
            this.Save.TabIndex = 3;
            this.Save.Text = "保存(Enter)";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Location = new System.Drawing.Point(830, 503);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 29);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "取消(Esc)";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // FileInfomation
            // 
            this.FileInfomation.Controls.Add(this.FileExtensionTypeTxtBox);
            this.FileInfomation.Controls.Add(this.label10);
            this.FileInfomation.Controls.Add(this.label5);
            this.FileInfomation.Controls.Add(this.FileSizeTxtBox);
            this.FileInfomation.Controls.Add(this.label4);
            this.FileInfomation.Controls.Add(this.SyntaxHighlightingTypeNameTxtBox);
            this.FileInfomation.Controls.Add(this.label3);
            this.FileInfomation.Controls.Add(this.FileNameTxtBox);
            this.FileInfomation.Controls.Add(this.label2);
            this.FileInfomation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FileInfomation.Location = new System.Drawing.Point(307, 3);
            this.FileInfomation.Name = "FileInfomation";
            this.FileInfomation.Size = new System.Drawing.Size(580, 187);
            this.FileInfomation.TabIndex = 1;
            this.FileInfomation.TabStop = false;
            this.FileInfomation.Text = "文件信息";
            // 
            // FileExtensionTypeTxtBox
            // 
            this.FileExtensionTypeTxtBox.BackColor = System.Drawing.Color.Black;
            this.FileExtensionTypeTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileExtensionTypeTxtBox.ForeColor = System.Drawing.Color.White;
            this.FileExtensionTypeTxtBox.Location = new System.Drawing.Point(112, 85);
            this.FileExtensionTypeTxtBox.Name = "FileExtensionTypeTxtBox";
            this.FileExtensionTypeTxtBox.Size = new System.Drawing.Size(462, 27);
            this.FileExtensionTypeTxtBox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "文件扩展类型";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "KB";
            // 
            // FileSizeTxtBox
            // 
            this.FileSizeTxtBox.BackColor = System.Drawing.Color.Black;
            this.FileSizeTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileSizeTxtBox.ForeColor = System.Drawing.SystemColors.Control;
            this.FileSizeTxtBox.Location = new System.Drawing.Point(81, 118);
            this.FileSizeTxtBox.Name = "FileSizeTxtBox";
            this.FileSizeTxtBox.ReadOnly = true;
            this.FileSizeTxtBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FileSizeTxtBox.Size = new System.Drawing.Size(459, 20);
            this.FileSizeTxtBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "文件大小";
            // 
            // SyntaxHighlightingTypeNameTxtBox
            // 
            this.SyntaxHighlightingTypeNameTxtBox.BackColor = System.Drawing.Color.Black;
            this.SyntaxHighlightingTypeNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SyntaxHighlightingTypeNameTxtBox.ForeColor = System.Drawing.Color.White;
            this.SyntaxHighlightingTypeNameTxtBox.Location = new System.Drawing.Point(142, 52);
            this.SyntaxHighlightingTypeNameTxtBox.Name = "SyntaxHighlightingTypeNameTxtBox";
            this.SyntaxHighlightingTypeNameTxtBox.Size = new System.Drawing.Size(432, 27);
            this.SyntaxHighlightingTypeNameTxtBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "语法高亮类型名称";
            // 
            // FileNameTxtBox
            // 
            this.FileNameTxtBox.BackColor = System.Drawing.Color.Black;
            this.FileNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileNameTxtBox.ForeColor = System.Drawing.SystemColors.Control;
            this.FileNameTxtBox.Location = new System.Drawing.Point(81, 20);
            this.FileNameTxtBox.Name = "FileNameTxtBox";
            this.FileNameTxtBox.ReadOnly = true;
            this.FileNameTxtBox.Size = new System.Drawing.Size(493, 27);
            this.FileNameTxtBox.TabIndex = 1;
            this.FileNameTxtBox.TextChanged += new System.EventHandler(this.EnableButtons);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件名称";
            // 
            // FileStructure
            // 
            this.FileStructure.Controls.Add(this.Tv_File);
            this.FileStructure.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FileStructure.Location = new System.Drawing.Point(3, 3);
            this.FileStructure.Name = "FileStructure";
            this.FileStructure.Size = new System.Drawing.Size(298, 187);
            this.FileStructure.TabIndex = 0;
            this.FileStructure.TabStop = false;
            this.FileStructure.Text = "文件结构";
            // 
            // Tv_File
            // 
            this.Tv_File.BackColor = System.Drawing.Color.Black;
            this.Tv_File.ForeColor = System.Drawing.SystemColors.Control;
            this.Tv_File.Location = new System.Drawing.Point(6, 19);
            this.Tv_File.Name = "Tv_File";
            this.Tv_File.Size = new System.Drawing.Size(286, 162);
            this.Tv_File.TabIndex = 0;
            this.Tv_File.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.GetInfo);
            // 
            // VisualEditingPanel
            // 
            this.VisualEditingPanel.Controls.Add(this.FileStructure);
            this.VisualEditingPanel.Controls.Add(this.FileInfomation);
            this.VisualEditingPanel.Controls.Add(this.Edit);
            this.VisualEditingPanel.Location = new System.Drawing.Point(16, 39);
            this.VisualEditingPanel.Name = "VisualEditingPanel";
            this.VisualEditingPanel.Size = new System.Drawing.Size(893, 458);
            this.VisualEditingPanel.TabIndex = 2;
            // 
            // Edit
            // 
            this.Edit.Controls.Add(this.panel1);
            this.Edit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Edit.Location = new System.Drawing.Point(3, 196);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(890, 262);
            this.Edit.TabIndex = 5;
            this.Edit.TabStop = false;
            this.Edit.Text = "编辑";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CBBox_Edit_FontProperties);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.colorPicker2);
            this.panel1.Controls.Add(this.TxtBox_Edit_Background);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.colorPicker1);
            this.panel1.Controls.Add(this.TxtBox_Edit_Foreground);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TxtBox_Edit_keyname);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(6, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 233);
            this.panel1.TabIndex = 0;
            // 
            // CBBox_Edit_FontProperties
            // 
            this.CBBox_Edit_FontProperties.BackColor = System.Drawing.Color.Black;
            this.CBBox_Edit_FontProperties.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CBBox_Edit_FontProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBox_Edit_FontProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBBox_Edit_FontProperties.ForeColor = System.Drawing.Color.White;
            this.CBBox_Edit_FontProperties.FormattingEnabled = true;
            this.CBBox_Edit_FontProperties.Items.AddRange(new object[] {
            "",
            "bold",
            "italic",
            "underline",
            "strikeout"});
            this.CBBox_Edit_FontProperties.Location = new System.Drawing.Point(97, 108);
            this.CBBox_Edit_FontProperties.Name = "CBBox_Edit_FontProperties";
            this.CBBox_Edit_FontProperties.Size = new System.Drawing.Size(222, 28);
            this.CBBox_Edit_FontProperties.TabIndex = 12;
            this.InfoTip.SetToolTip(this.CBBox_Edit_FontProperties, "(无) - 无特殊设置\r\nbold - 粗体\r\nitalic - 斜体\r\nunderline - 下划线\r\nstrikeout - 删除线");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "字体属性";
            // 
            // colorPicker2
            // 
            this.colorPicker2.BackgroundImage = global::IDE.Properties.Resources.ColorPicker;
            this.colorPicker2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorPicker2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorPicker2.Location = new System.Drawing.Point(293, 75);
            this.colorPicker2.Name = "colorPicker2";
            this.colorPicker2.Size = new System.Drawing.Size(27, 27);
            this.colorPicker2.TabIndex = 10;
            this.colorPicker2.UseVisualStyleBackColor = true;
            this.colorPicker2.Click += new System.EventHandler(this.PickBackgroundColors);
            // 
            // TxtBox_Edit_Background
            // 
            this.TxtBox_Edit_Background.BackColor = System.Drawing.Color.Black;
            this.TxtBox_Edit_Background.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBox_Edit_Background.ForeColor = System.Drawing.Color.White;
            this.TxtBox_Edit_Background.Location = new System.Drawing.Point(76, 75);
            this.TxtBox_Edit_Background.Name = "TxtBox_Edit_Background";
            this.TxtBox_Edit_Background.Size = new System.Drawing.Size(209, 27);
            this.TxtBox_Edit_Background.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "背景色";
            // 
            // colorPicker1
            // 
            this.colorPicker1.BackgroundImage = global::IDE.Properties.Resources.ColorPicker;
            this.colorPicker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorPicker1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorPicker1.Location = new System.Drawing.Point(293, 42);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.Size = new System.Drawing.Size(27, 27);
            this.colorPicker1.TabIndex = 7;
            this.colorPicker1.UseVisualStyleBackColor = true;
            this.colorPicker1.Click += new System.EventHandler(this.PickForegroundColors);
            // 
            // TxtBox_Edit_Foreground
            // 
            this.TxtBox_Edit_Foreground.BackColor = System.Drawing.Color.Black;
            this.TxtBox_Edit_Foreground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBox_Edit_Foreground.ForeColor = System.Drawing.Color.White;
            this.TxtBox_Edit_Foreground.Location = new System.Drawing.Point(76, 42);
            this.TxtBox_Edit_Foreground.Name = "TxtBox_Edit_Foreground";
            this.TxtBox_Edit_Foreground.Size = new System.Drawing.Size(209, 27);
            this.TxtBox_Edit_Foreground.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "前景色";
            // 
            // TxtBox_Edit_keyname
            // 
            this.TxtBox_Edit_keyname.BackColor = System.Drawing.Color.Black;
            this.TxtBox_Edit_keyname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBox_Edit_keyname.ForeColor = System.Drawing.Color.White;
            this.TxtBox_Edit_keyname.Location = new System.Drawing.Point(61, 9);
            this.TxtBox_Edit_keyname.Name = "TxtBox_Edit_keyname";
            this.TxtBox_Edit_keyname.Size = new System.Drawing.Size(259, 27);
            this.TxtBox_Edit_keyname.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "名称";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copyright,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(921, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Copyright
            // 
            this.Copyright.Name = "Copyright";
            this.Copyright.Size = new System.Drawing.Size(230, 20);
            this.Copyright.Text = "Copyright © 2023 RYCBStudio";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(676, 20);
            this.toolStripStatusLabel1.Text = "                                                                                 " +
    "                      鼠标指针悬浮于各组件上即可获得帮助";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // InfoTip
            // 
            this.InfoTip.BackColor = System.Drawing.Color.DimGray;
            this.InfoTip.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.InfoTip.ToolTipTitle = "信息";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "切换到代码编辑模式(Alt+&C)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Coding);
            // 
            // CodeEditingPanel
            // 
            this.CodeEditingPanel.Controls.Add(this.elementHost1);
            this.CodeEditingPanel.Location = new System.Drawing.Point(16, 39);
            this.CodeEditingPanel.Name = "CodeEditingPanel";
            this.CodeEditingPanel.Size = new System.Drawing.Size(893, 458);
            this.CodeEditingPanel.TabIndex = 7;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(3, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(893, 458);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // XshdVisualEditor
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(921, 564);
            this.Controls.Add(this.VisualEditingPanel);
            this.Controls.Add(this.CodeEditingPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.FileTxtBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XshdVisualEditor";
            this.Text = "Xshd文件可视化编辑器";
            this.Load += new System.EventHandler(this.XshdVisualEditor_Load);
            this.FileInfomation.ResumeLayout(false);
            this.FileInfomation.PerformLayout();
            this.FileStructure.ResumeLayout(false);
            this.VisualEditingPanel.ResumeLayout(false);
            this.Edit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.CodeEditingPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileTxtBox;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.GroupBox FileInfomation;
        private System.Windows.Forms.TextBox SyntaxHighlightingTypeNameTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FileNameTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox FileStructure;
        private System.Windows.Forms.TreeView Tv_File;
        private System.Windows.Forms.FlowLayoutPanel VisualEditingPanel;
        private System.Windows.Forms.GroupBox Edit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FileSizeTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Copyright;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtBox_Edit_keyname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button colorPicker1;
        private System.Windows.Forms.TextBox TxtBox_Edit_Foreground;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button colorPicker2;
        private System.Windows.Forms.TextBox TxtBox_Edit_Background;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox CBBox_Edit_FontProperties;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.TextBox FileExtensionTypeTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel CodeEditingPanel;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}