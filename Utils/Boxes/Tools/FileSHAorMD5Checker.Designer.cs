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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtBoxFilePath = new System.Windows.Forms.TextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtBoxFileName = new System.Windows.Forms.TextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtBoxFileMD5 = new System.Windows.Forms.TextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtBoxFileSHA1 = new System.Windows.Forms.TextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.txtBoxFileSHA256 = new System.Windows.Forms.TextBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
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
            this.tableLayoutPanel1.Controls.Add(this.uiButton1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(513, 202);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(96, 40);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Path";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFilePath
            // 
            this.txtBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFilePath.Location = new System.Drawing.Point(105, 3);
            this.txtBoxFilePath.Name = "txtBoxFilePath";
            this.txtBoxFilePath.Size = new System.Drawing.Size(378, 34);
            this.txtBoxFilePath.TabIndex = 1;
            this.txtBoxFilePath.TextChanged += new System.EventHandler(this.FileChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(3, 40);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(96, 40);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "Name";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileName, 2);
            this.txtBoxFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFileName.Location = new System.Drawing.Point(105, 43);
            this.txtBoxFileName.Name = "txtBoxFileName";
            this.txtBoxFileName.Size = new System.Drawing.Size(405, 34);
            this.txtBoxFileName.TabIndex = 3;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(3, 80);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(96, 40);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "MD5";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileMD5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileMD5, 2);
            this.txtBoxFileMD5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFileMD5.Location = new System.Drawing.Point(105, 83);
            this.txtBoxFileMD5.Name = "txtBoxFileMD5";
            this.txtBoxFileMD5.Size = new System.Drawing.Size(405, 34);
            this.txtBoxFileMD5.TabIndex = 5;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(3, 120);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(96, 40);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "SHA1";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileSHA1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileSHA1, 2);
            this.txtBoxFileSHA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFileSHA1.Location = new System.Drawing.Point(105, 123);
            this.txtBoxFileSHA1.Name = "txtBoxFileSHA1";
            this.txtBoxFileSHA1.Size = new System.Drawing.Size(405, 34);
            this.txtBoxFileSHA1.TabIndex = 7;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(3, 160);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(96, 42);
            this.uiLabel5.TabIndex = 8;
            this.uiLabel5.Text = "SHA256";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxFileSHA256
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtBoxFileSHA256, 2);
            this.txtBoxFileSHA256.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFileSHA256.Location = new System.Drawing.Point(105, 163);
            this.txtBoxFileSHA256.Name = "txtBoxFileSHA256";
            this.txtBoxFileSHA256.Size = new System.Drawing.Size(405, 34);
            this.txtBoxFileSHA256.TabIndex = 9;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(489, 3);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(21, 34);
            this.uiButton1.TabIndex = 10;
            this.uiButton1.Text = "...";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.OpenFile);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // FileSHAorMD5Checker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(513, 237);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FileSHAorMD5Checker";
            this.Text = "File SHA or MD5 Encoding Validator";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private Sunny.UI.UILabel uiLabel1;
    private System.Windows.Forms.TextBox txtBoxFilePath;
    private System.Windows.Forms.TextBox txtBoxFileSHA256;
    private Sunny.UI.UILabel uiLabel5;
    private System.Windows.Forms.TextBox txtBoxFileSHA1;
    private Sunny.UI.UILabel uiLabel4;
    private System.Windows.Forms.TextBox txtBoxFileMD5;
    private Sunny.UI.UILabel uiLabel3;
    private System.Windows.Forms.TextBox txtBoxFileName;
    private Sunny.UI.UILabel uiLabel2;
    private Sunny.UI.UIButton uiButton1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
}