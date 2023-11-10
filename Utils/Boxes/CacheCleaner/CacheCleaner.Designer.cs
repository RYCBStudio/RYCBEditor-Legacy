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
            this.SuspendLayout();
            // 
            // CLogFile
            // 
            this.CLogFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CLogFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CLogFile.Location = new System.Drawing.Point(3, 90);
            this.CLogFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.CLogFile.Name = "CLogFile";
            this.CLogFile.Size = new System.Drawing.Size(621, 37);
            this.CLogFile.Style = Sunny.UI.UIStyle.Custom;
            this.CLogFile.StyleCustomMode = true;
            this.CLogFile.TabIndex = 0;
            this.CLogFile.Text = "text.window.cc.choices.logfile";
            this.CLogFile.CheckedChanged += new System.EventHandler(this.ChangeState_Log);
            // 
            // CPyCNCompiledFile
            // 
            this.CPyCNCompiledFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPyCNCompiledFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPyCNCompiledFile.Location = new System.Drawing.Point(3, 133);
            this.CPyCNCompiledFile.MinimumSize = new System.Drawing.Size(1, 1);
            this.CPyCNCompiledFile.Name = "CPyCNCompiledFile";
            this.CPyCNCompiledFile.Size = new System.Drawing.Size(621, 37);
            this.CPyCNCompiledFile.Style = Sunny.UI.UIStyle.Custom;
            this.CPyCNCompiledFile.StyleCustomMode = true;
            this.CPyCNCompiledFile.TabIndex = 1;
            this.CPyCNCompiledFile.Text = "text.window.cc.choices.pycnfile";
            this.CPyCNCompiledFile.CheckedChanged += new System.EventHandler(this.ChangeState_PyCN);
            // 
            // CTemporaryCode
            // 
            this.CTemporaryCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CTemporaryCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CTemporaryCode.Location = new System.Drawing.Point(3, 176);
            this.CTemporaryCode.MinimumSize = new System.Drawing.Size(1, 1);
            this.CTemporaryCode.Name = "CTemporaryCode";
            this.CTemporaryCode.Size = new System.Drawing.Size(621, 37);
            this.CTemporaryCode.Style = Sunny.UI.UIStyle.Custom;
            this.CTemporaryCode.StyleCustomMode = true;
            this.CTemporaryCode.TabIndex = 2;
            this.CTemporaryCode.Text = "text.window.cc.choices.tmpcodefile";
            this.CTemporaryCode.CheckedChanged += new System.EventHandler(this.ChangeState_Tmp);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.LineColor2 = System.Drawing.Color.White;
            this.uiLine1.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine1.LineSize = 5;
            this.uiLine1.Location = new System.Drawing.Point(3, 38);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(621, 38);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.StyleCustomMode = true;
            this.uiLine1.TabIndex = 3;
            this.uiLine1.Text = "text.window.cc.clearchoices";
            // 
            // uiProcessBar1
            // 
            this.uiProcessBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiProcessBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiProcessBar1.Location = new System.Drawing.Point(3, 263);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.Size = new System.Drawing.Size(621, 34);
            this.uiProcessBar1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProcessBar1.StyleCustomMode = true;
            this.uiProcessBar1.TabIndex = 4;
            this.uiProcessBar1.ValueChanged += new Sunny.UI.UIProcessBar.OnValueChanged(this.IsOver);
            // 
            // uiLine2
            // 
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine2.LineColor2 = System.Drawing.Color.White;
            this.uiLine2.LineDashStyle = Sunny.UI.UILineDashStyle.Solid;
            this.uiLine2.LineSize = 5;
            this.uiLine2.Location = new System.Drawing.Point(3, 219);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(621, 38);
            this.uiLine2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine2.StyleCustomMode = true;
            this.uiLine2.TabIndex = 5;
            this.uiLine2.Text = "text.window.cc.clearprogress";
            // 
            // BtnStart
            // 
            this.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Location = new System.Drawing.Point(315, 316);
            this.BtnStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(99, 36);
            this.BtnStart.Style = Sunny.UI.UIStyle.Custom;
            this.BtnStart.StyleCustomMode = true;
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "text.window.cc.start";
            this.BtnStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnStart.Click += new System.EventHandler(this.Disable);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(525, 316);
            this.BtnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 36);
            this.BtnCancel.Style = Sunny.UI.UIStyle.Custom;
            this.BtnCancel.StyleCustomMode = true;
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "text.window.cc.cancel";
            this.BtnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // BtnOk
            // 
            this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(420, 316);
            this.BtnOk.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(99, 36);
            this.BtnOk.Style = Sunny.UI.UIStyle.Custom;
            this.BtnOk.StyleCustomMode = true;
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "text.window.cc.ok";
            this.BtnOk.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // CacheCleaner
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(627, 355);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.uiProcessBar1);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.CTemporaryCode);
            this.Controls.Add(this.CPyCNCompiledFile);
            this.Controls.Add(this.CLogFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CacheCleaner";
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "text.window.cachecleaner.title";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
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
}