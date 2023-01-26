namespace IDE
{
    partial class CustomSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomSettings));
            this.xshdFileLabel = new System.Windows.Forms.Label();
            this.XshdCBox = new System.Windows.Forms.ComboBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.findFIle = new System.Windows.Forms.Button();
            this.addToIDE = new System.Windows.Forms.Button();
            this.XshdFileFinder = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // xshdFileLabel
            // 
            this.xshdFileLabel.AutoSize = true;
            this.xshdFileLabel.Location = new System.Drawing.Point(12, 9);
            this.xshdFileLabel.Name = "xshdFileLabel";
            this.xshdFileLabel.Size = new System.Drawing.Size(215, 23);
            this.xshdFileLabel.TabIndex = 0;
            this.xshdFileLabel.Text = "Xshd(代码高亮)文件路径：";
            // 
            // XshdCBox
            // 
            this.XshdCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.XshdCBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XshdCBox.FormattingEnabled = true;
            this.XshdCBox.Location = new System.Drawing.Point(261, 8);
            this.XshdCBox.Name = "XshdCBox";
            this.XshdCBox.Size = new System.Drawing.Size(359, 31);
            this.XshdCBox.TabIndex = 1;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(834, 396);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(10, 10);
            this.elementHost1.TabIndex = 2;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // findFIle
            // 
            this.findFIle.Location = new System.Drawing.Point(626, 9);
            this.findFIle.Name = "findFIle";
            this.findFIle.Size = new System.Drawing.Size(42, 30);
            this.findFIle.TabIndex = 3;
            this.findFIle.Text = "...";
            this.findFIle.UseVisualStyleBackColor = true;
            this.findFIle.Click += new System.EventHandler(this.FindFile);
            // 
            // addToIDE
            // 
            this.addToIDE.Location = new System.Drawing.Point(689, 9);
            this.addToIDE.Name = "addToIDE";
            this.addToIDE.Size = new System.Drawing.Size(110, 29);
            this.addToIDE.TabIndex = 4;
            this.addToIDE.Text = "添加至IDE";
            this.addToIDE.UseVisualStyleBackColor = true;
            this.addToIDE.Click += new System.EventHandler(this.addXshdToIDE);
            // 
            // XshdFileFinder
            // 
            this.XshdFileFinder.DefaultExt = "xshd";
            this.XshdFileFinder.Filter = "语法高亮文件|*.xshd";
            this.XshdFileFinder.Title = "查找Xshd文件";
            // 
            // CustomSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 400);
            this.Controls.Add(this.addToIDE);
            this.Controls.Add(this.findFIle);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.XshdCBox);
            this.Controls.Add(this.xshdFileLabel);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label xshdFileLabel;
        private System.Windows.Forms.ComboBox XshdCBox;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button findFIle;
        private System.Windows.Forms.Button addToIDE;
        private System.Windows.Forms.OpenFileDialog XshdFileFinder;
    }
}