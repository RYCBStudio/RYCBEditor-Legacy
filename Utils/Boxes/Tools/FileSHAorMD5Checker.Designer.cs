namespace IDE;

partial class FileSHAorMD5Checker
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtBoxFilePath = new System.Windows.Forms.TextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtBoxFileName = new System.Windows.Forms.TextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtBoxFileMD5 = new System.Windows.Forms.TextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtBoxFileSHA1 = new System.Windows.Forms.TextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.txtBoxFileSHA256 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtBoxGivenMD5Value = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtBoxGivenSHA1Value = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtBoxGivenSHA256Value = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.exCMenu = new Sunny.UI.UIContextMenuStrip();
            this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.toMd = new System.Windows.Forms.ToolStripMenuItem();
            this.toHtml = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.exCMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // txtBoxFilePath
            // 
            this.txtBoxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFilePath, 3);
            this.txtBoxFilePath.Location = new System.Drawing.Point(115, 3);
            this.txtBoxFilePath.Name = "txtBoxFilePath";
            this.txtBoxFilePath.Size = new System.Drawing.Size(405, 39);
            this.txtBoxFilePath.TabIndex = 1;
            this.txtBoxFilePath.TextChanged += new System.EventHandler(this.FileChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(106, 40);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Path";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(3, 40);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(106, 40);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "Name";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileName
            // 
            this.txtBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileName, 4);
            this.txtBoxFileName.Location = new System.Drawing.Point(115, 43);
            this.txtBoxFileName.Name = "txtBoxFileName";
            this.txtBoxFileName.Size = new System.Drawing.Size(443, 39);
            this.txtBoxFileName.TabIndex = 3;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(3, 80);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(106, 40);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "MD5";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileMD5
            // 
            this.txtBoxFileMD5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileMD5, 2);
            this.txtBoxFileMD5.Location = new System.Drawing.Point(115, 83);
            this.txtBoxFileMD5.Name = "txtBoxFileMD5";
            this.txtBoxFileMD5.Size = new System.Drawing.Size(218, 39);
            this.txtBoxFileMD5.TabIndex = 5;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(3, 120);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(106, 40);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "SHA1";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileSHA1
            // 
            this.txtBoxFileSHA1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileSHA1, 2);
            this.txtBoxFileSHA1.Location = new System.Drawing.Point(115, 123);
            this.txtBoxFileSHA1.Name = "txtBoxFileSHA1";
            this.txtBoxFileSHA1.Size = new System.Drawing.Size(218, 39);
            this.txtBoxFileSHA1.TabIndex = 7;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(3, 160);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(106, 42);
            this.uiLabel5.TabIndex = 8;
            this.uiLabel5.Text = "SHA256";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileSHA256
            // 
            this.txtBoxFileSHA256.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileSHA256, 2);
            this.txtBoxFileSHA256.Location = new System.Drawing.Point(115, 163);
            this.txtBoxFileSHA256.Name = "txtBoxFileSHA256";
            this.txtBoxFileSHA256.Size = new System.Drawing.Size(218, 39);
            this.txtBoxFileSHA256.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::IDE.Properties.Resources.delete;
            this.pictureBox3.Location = new System.Drawing.Point(526, 83);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 34);
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // txtBoxGivenMD5Value
            // 
            this.txtBoxGivenMD5Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxGivenMD5Value.Location = new System.Drawing.Point(339, 83);
            this.txtBoxGivenMD5Value.Name = "txtBoxGivenMD5Value";
            this.txtBoxGivenMD5Value.Size = new System.Drawing.Size(181, 39);
            this.txtBoxGivenMD5Value.TabIndex = 16;
            this.txtBoxGivenMD5Value.TextChanged += new System.EventHandler(this.Judge_MD5);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = global::IDE.Properties.Resources.delete;
            this.pictureBox4.Location = new System.Drawing.Point(526, 123);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 34);
            this.pictureBox4.TabIndex = 17;
            this.pictureBox4.TabStop = false;
            // 
            // txtBoxGivenSHA1Value
            // 
            this.txtBoxGivenSHA1Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxGivenSHA1Value.Location = new System.Drawing.Point(339, 123);
            this.txtBoxGivenSHA1Value.Name = "txtBoxGivenSHA1Value";
            this.txtBoxGivenSHA1Value.Size = new System.Drawing.Size(181, 39);
            this.txtBoxGivenSHA1Value.TabIndex = 18;
            this.txtBoxGivenSHA1Value.TextChanged += new System.EventHandler(this.Judge_SHA1);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = global::IDE.Properties.Resources.delete;
            this.pictureBox5.Location = new System.Drawing.Point(526, 163);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 36);
            this.pictureBox5.TabIndex = 19;
            this.pictureBox5.TabStop = false;
            // 
            // txtBoxGivenSHA256Value
            // 
            this.txtBoxGivenSHA256Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxGivenSHA256Value.Location = new System.Drawing.Point(339, 163);
            this.txtBoxGivenSHA256Value.Name = "txtBoxGivenSHA256Value";
            this.txtBoxGivenSHA256Value.Size = new System.Drawing.Size(181, 39);
            this.txtBoxGivenSHA256Value.TabIndex = 20;
            this.txtBoxGivenSHA256Value.TextChanged += new System.EventHandler(this.Judge_SHA256);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this.tableLayoutPanel1.Controls.Add(this.uiButton1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxGivenSHA256Value, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxGivenSHA1Value, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxGivenMD5Value, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxFileSHA256, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxFileSHA1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxFileMD5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxFileName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxFilePath, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 202);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(527, 3);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(30, 34);
            this.uiButton1.TabIndex = 25;
            this.uiButton1.Text = "...";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.OpenFile);
            // 
            // exCMenu
            // 
            this.exCMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.exCMenu.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.exCMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.exCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToToolStripMenuItem});
            this.exCMenu.Name = "exCMenu";
            this.exCMenu.Size = new System.Drawing.Size(188, 38);
            // 
            // exportToToolStripMenuItem
            // 
            this.exportToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toTxt,
            this.toMd,
            this.toHtml});
            this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
            this.exportToToolStripMenuItem.Size = new System.Drawing.Size(187, 34);
            this.exportToToolStripMenuItem.Text = "Export to...";
            // 
            // toTxt
            // 
            this.toTxt.Name = "toTxt";
            this.toTxt.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toTxt.ShowShortcutKeys = false;
            this.toTxt.Size = new System.Drawing.Size(269, 36);
            this.toTxt.Text = ".txt          (Ctrl+T)";
            this.toTxt.Click += new System.EventHandler(this.ExportToTxt);
            // 
            // toMd
            // 
            this.toMd.Name = "toMd";
            this.toMd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.toMd.ShowShortcutKeys = false;
            this.toMd.Size = new System.Drawing.Size(269, 36);
            this.toMd.Text = ".md        (Ctrl+M)";
            this.toMd.Click += new System.EventHandler(this.ExportToMd);
            // 
            // toHtml
            // 
            this.toHtml.Name = "toHtml";
            this.toHtml.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.toHtml.ShowShortcutKeys = false;
            this.toHtml.Size = new System.Drawing.Size(269, 36);
            this.toHtml.Text = ".html       (Ctrl+H)";
            this.toHtml.Click += new System.EventHandler(this.ExportToHtml);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "res";
            // 
            // FileSHAorMD5Checker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(561, 237);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ExtendBox = true;
            this.ExtendMenu = this.exCMenu;
            this.ExtendSymbol = 362831;
            this.ExtendSymbolOffset = new System.Drawing.Point(-5, 2);
            this.ExtendSymbolSize = 30;
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Name = "FileSHAorMD5Checker";
            this.ShowIcon = false;
            this.Text = "File SHA or MD5 Encoding Validator";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.exCMenu.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.TextBox txtBoxFilePath;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private Sunny.UI.UIButton uiButton1;
    private System.Windows.Forms.TextBox txtBoxGivenSHA256Value;
    private System.Windows.Forms.PictureBox pictureBox5;
    private System.Windows.Forms.TextBox txtBoxGivenSHA1Value;
    private System.Windows.Forms.PictureBox pictureBox4;
    private System.Windows.Forms.TextBox txtBoxGivenMD5Value;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.TextBox txtBoxFileSHA256;
    private Sunny.UI.UILabel uiLabel5;
    private System.Windows.Forms.TextBox txtBoxFileSHA1;
    private Sunny.UI.UILabel uiLabel4;
    private System.Windows.Forms.TextBox txtBoxFileMD5;
    private Sunny.UI.UILabel uiLabel3;
    private System.Windows.Forms.TextBox txtBoxFileName;
    private Sunny.UI.UILabel uiLabel2;
    private Sunny.UI.UILabel uiLabel1;
    private Sunny.UI.UIContextMenuStrip exCMenu;
    private System.Windows.Forms.ToolStripMenuItem exportToToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toTxt;
    private System.Windows.Forms.ToolStripMenuItem toMd;
    private System.Windows.Forms.ToolStripMenuItem toHtml;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
}