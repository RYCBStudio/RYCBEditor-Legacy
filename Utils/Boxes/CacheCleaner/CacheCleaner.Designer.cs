namespace IDE;

partial class CacheCleaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheCleaner));
            this.CLogFile = new Sunny.UI.UICheckBox();
            this.CPyCNCompiledFile = new Sunny.UI.UICheckBox();
            this.CTemporaryCode = new Sunny.UI.UICheckBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiProcessBar1 = new Sunny.UI.UIProcessBar();
            this.uiLine2 = new Sunny.UI.UILine();
            this.BtnStart = new Sunny.UI.UIButton();
            this.BtnCancel = new Sunny.UI.UIButton();
            this.BtnOk = new Sunny.UI.UIButton();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.uiCheckBox2 = new Sunny.UI.UICheckBox();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiCheckBox3 = new Sunny.UI.UICheckBox();
            this.uiCheckBox4 = new Sunny.UI.UICheckBox();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CLogFile
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.CLogFile, 10);
            this.CLogFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CLogFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLogFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CLogFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CLogFile.Location = new System.Drawing.Point(3, 101);
            this.CLogFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.CLogFile.Name = "CLogFile";
            this.CLogFile.Size = new System.Drawing.Size(621, 43);
            this.CLogFile.Style = Sunny.UI.UIStyle.Custom;
            this.CLogFile.StyleCustomMode = true;
            this.CLogFile.TabIndex = 0;
            this.CLogFile.Text = "text.window.cc.choices.logfile";
            this.CLogFile.CheckedChanged += new System.EventHandler(this.ChangeState_Log);
            // 
            // CPyCNCompiledFile
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.CPyCNCompiledFile, 10);
            this.CPyCNCompiledFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPyCNCompiledFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPyCNCompiledFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPyCNCompiledFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CPyCNCompiledFile.Location = new System.Drawing.Point(3, 52);
            this.CPyCNCompiledFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.CPyCNCompiledFile.Name = "CPyCNCompiledFile";
            this.CPyCNCompiledFile.Size = new System.Drawing.Size(621, 43);
            this.CPyCNCompiledFile.Style = Sunny.UI.UIStyle.Custom;
            this.CPyCNCompiledFile.StyleCustomMode = true;
            this.CPyCNCompiledFile.TabIndex = 1;
            this.CPyCNCompiledFile.Text = "text.window.cc.choices.pycnfile";
            this.CPyCNCompiledFile.CheckedChanged += new System.EventHandler(this.ChangeState_PyCN);
            // 
            // CTemporaryCode
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.CTemporaryCode, 10);
            this.CTemporaryCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CTemporaryCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CTemporaryCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CTemporaryCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.CTemporaryCode.Location = new System.Drawing.Point(3, 150);
            this.CTemporaryCode.MinimumSize = new System.Drawing.Size(1, 1);
            this.CTemporaryCode.Name = "CTemporaryCode";
            this.CTemporaryCode.Size = new System.Drawing.Size(621, 43);
            this.CTemporaryCode.Style = Sunny.UI.UIStyle.Custom;
            this.CTemporaryCode.StyleCustomMode = true;
            this.CTemporaryCode.TabIndex = 2;
            this.CTemporaryCode.Text = "text.window.cc.choices.tmpcodefile";
            this.CTemporaryCode.CheckedChanged += new System.EventHandler(this.ChangeState_Tmp);
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiLine1, 10);
            this.uiLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.LineColor2 = System.Drawing.Color.White;
            this.uiLine1.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine1.LineSize = 5;
            this.uiLine1.Location = new System.Drawing.Point(3, 3);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(621, 43);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.StyleCustomMode = true;
            this.uiLine1.TabIndex = 3;
            this.uiLine1.Text = "text.window.cc.clearchoices";
            // 
            // uiProcessBar1
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiProcessBar1, 10);
            this.uiProcessBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiProcessBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiProcessBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiProcessBar1.Location = new System.Drawing.Point(3, 419);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.Size = new System.Drawing.Size(621, 33);
            this.uiProcessBar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProcessBar1.StyleCustomMode = true;
            this.uiProcessBar1.TabIndex = 4;
            this.uiProcessBar1.ValueChanged += new Sunny.UI.UIProcessBar.OnValueChanged(this.IsOver);
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiLine2, 10);
            this.uiLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine2.LineColor2 = System.Drawing.Color.White;
            this.uiLine2.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine2.LineSize = 5;
            this.uiLine2.Location = new System.Drawing.Point(3, 385);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(621, 28);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.StyleCustomMode = true;
            this.uiLine2.TabIndex = 5;
            this.uiLine2.Text = "text.window.cc.clearprogress";
            // 
            // BtnStart
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.BtnStart, 2);
            this.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(251, 458);
            this.BtnStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(118, 37);
            this.BtnStart.Style = Sunny.UI.UIStyle.Custom;
            this.BtnStart.StyleCustomMode = true;
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "text.window.cc.start";
            this.BtnStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Click += new System.EventHandler(this.Disable);
            // 
            // BtnCancel
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.BtnCancel, 2);
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(499, 458);
            this.BtnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(125, 37);
            this.BtnCancel.Style = Sunny.UI.UIStyle.Custom;
            this.BtnCancel.StyleCustomMode = true;
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "text.window.cc.cancel";
            this.BtnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Click += new System.EventHandler(this.Cancel);
            // 
            // BtnOk
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.BtnOk, 2);
            this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(375, 458);
            this.BtnOk.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(118, 37);
            this.BtnOk.Style = Sunny.UI.UIStyle.Custom;
            this.BtnOk.StyleCustomMode = true;
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "text.window.cc.ok";
            this.BtnOk.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiCheckBox1
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiCheckBox1, 10);
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCheckBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox1.Location = new System.Drawing.Point(3, 199);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Size = new System.Drawing.Size(621, 43);
            this.uiCheckBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox1.StyleCustomMode = true;
            this.uiCheckBox1.TabIndex = 9;
            this.uiCheckBox1.Text = "text.window.cc.choices.updatearchive";
            this.uiCheckBox1.CheckedChanged += new System.EventHandler(this.ChangeState_UA);
            // 
            // uiCheckBox2
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiCheckBox2, 10);
            this.uiCheckBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCheckBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox2.Location = new System.Drawing.Point(3, 248);
            this.uiCheckBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox2.Name = "uiCheckBox2";
            this.uiCheckBox2.Size = new System.Drawing.Size(621, 43);
            this.uiCheckBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox2.StyleCustomMode = true;
            this.uiCheckBox2.TabIndex = 10;
            this.uiCheckBox2.Text = "text.window.cc.choices.updateres";
            this.uiCheckBox2.CheckedChanged += new System.EventHandler(this.ChangeState_UR);
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 10;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiCheckBox4, 0, 7);
            this.uiTableLayoutPanel1.Controls.Add(this.uiCheckBox3, 0, 6);
            this.uiTableLayoutPanel1.Controls.Add(this.uiCheckBox2, 0, 5);
            this.uiTableLayoutPanel1.Controls.Add(this.CLogFile, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.BtnStart, 4, 10);
            this.uiTableLayoutPanel1.Controls.Add(this.uiCheckBox1, 0, 4);
            this.uiTableLayoutPanel1.Controls.Add(this.uiProcessBar1, 0, 9);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLine2, 0, 8);
            this.uiTableLayoutPanel1.Controls.Add(this.CPyCNCompiledFile, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.CTemporaryCode, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLine1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.BtnOk, 6, 10);
            this.uiTableLayoutPanel1.Controls.Add(this.BtnCancel, 8, 10);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 11;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(627, 498);
            this.uiTableLayoutPanel1.TabIndex = 11;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiCheckBox3
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiCheckBox3, 10);
            this.uiCheckBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCheckBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox3.Location = new System.Drawing.Point(3, 297);
            this.uiCheckBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox3.Name = "uiCheckBox3";
            this.uiCheckBox3.Size = new System.Drawing.Size(621, 43);
            this.uiCheckBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox3.StyleCustomMode = true;
            this.uiCheckBox3.TabIndex = 11;
            this.uiCheckBox3.Text = "text.window.cc.choices.cachepath";
            this.uiCheckBox3.CheckedChanged += new System.EventHandler(this.ChangeStatus_CP);
            // 
            // uiCheckBox4
            // 
            this.uiTableLayoutPanel1.SetColumnSpan(this.uiCheckBox4, 10);
            this.uiCheckBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCheckBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox4.Location = new System.Drawing.Point(3, 346);
            this.uiCheckBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox4.Name = "uiCheckBox4";
            this.uiCheckBox4.Size = new System.Drawing.Size(621, 33);
            this.uiCheckBox4.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox4.StyleCustomMode = true;
            this.uiCheckBox4.TabIndex = 12;
            this.uiCheckBox4.Text = "text.window.cc.choices.dump";
            this.uiCheckBox4.CheckedChanged += new System.EventHandler(this.ChangeStatus_DMP);
            // 
            // CacheCleaner
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(627, 533);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CacheCleaner";
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "text.window.cachecleaner.title";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Sunny.UI.UICheckBox CLogFile;
    private Sunny.UI.UICheckBox CPyCNCompiledFile;
    private Sunny.UI.UICheckBox CTemporaryCode;
    private Sunny.UI.UILine uiLine1;
    private Sunny.UI.UIProcessBar uiProcessBar1;
    private Sunny.UI.UILine uiLine2;
    private Sunny.UI.UIButton BtnStart;
    private Sunny.UI.UIButton BtnCancel;
    private Sunny.UI.UIButton BtnOk;
    private Sunny.UI.UICheckBox uiCheckBox1;
    private Sunny.UI.UICheckBox uiCheckBox2;
    private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
    private Sunny.UI.UICheckBox uiCheckBox3;
    private Sunny.UI.UICheckBox uiCheckBox4;
}