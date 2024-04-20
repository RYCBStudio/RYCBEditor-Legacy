namespace IDE;

partial class RYCBSearchPanel
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
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.TBoxFind = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Close = new Sunny.UI.UIButton();
            this.Collapse = new Sunny.UI.UIButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiToolTip1 = new Sunny.UI.UIToolTip(this.components);
            this.CBoxCase = new Sunny.UI.UICheckBox();
            this.CBoxRegex = new Sunny.UI.UICheckBox();
            this.CBoxFull = new Sunny.UI.UICheckBox();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.uiButton6 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.Style = Sunny.UI.UIStyle.Black;
            // 
            // TBoxFind
            // 
            this.TBoxFind.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.TBoxFind.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.TBoxFind.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBoxFind.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.TBoxFind.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TBoxFind.Location = new System.Drawing.Point(73, 7);
            this.TBoxFind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxFind.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBoxFind.Name = "TBoxFind";
            this.TBoxFind.Padding = new System.Windows.Forms.Padding(5);
            this.TBoxFind.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.TBoxFind.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.TBoxFind.ShowText = false;
            this.TBoxFind.Size = new System.Drawing.Size(310, 35);
            this.TBoxFind.Style = Sunny.UI.UIStyle.Custom;
            this.TBoxFind.StyleCustomMode = true;
            this.TBoxFind.TabIndex = 0;
            this.TBoxFind.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBoxFind.Watermark = "";
            this.TBoxFind.TextChanged += new System.EventHandler(this.Find);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(12, 7);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(54, 33);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "text.sp.find";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Close
            // 
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Close.Location = new System.Drawing.Point(390, 7);
            this.Close.MinimumSize = new System.Drawing.Size(1, 1);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(16, 16);
            this.Close.Style = Sunny.UI.UIStyle.Custom;
            this.Close.StyleCustomMode = true;
            this.Close.TabIndex = 2;
            this.Close.Text = "×";
            this.Close.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Close.Click += new System.EventHandler(this.Cancel);
            // 
            // Collapse
            // 
            this.Collapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Collapse.Font = new System.Drawing.Font("微软雅黑", 7.5F);
            this.Collapse.Location = new System.Drawing.Point(390, 29);
            this.Collapse.MinimumSize = new System.Drawing.Size(1, 1);
            this.Collapse.Name = "Collapse";
            this.Collapse.Size = new System.Drawing.Size(16, 16);
            this.Collapse.Style = Sunny.UI.UIStyle.Custom;
            this.Collapse.StyleCustomMode = true;
            this.Collapse.TabIndex = 3;
            this.Collapse.Text = "⋁";
            this.Collapse.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Collapse.Click += new System.EventHandler(this.Switch);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(12, 108);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(54, 33);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.StyleCustomMode = true;
            this.uiLabel2.TabIndex = 5;
            this.uiLabel2.Text = "text.sp.find";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox1.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(73, 108);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.uiTextBox1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(333, 35);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.StyleCustomMode = true;
            this.uiTextBox1.TabIndex = 4;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.Watermark = "";
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLine1.Location = new System.Drawing.Point(0, 90);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(425, 10);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.StyleCustomMode = true;
            this.uiLine1.TabIndex = 6;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton1.Location = new System.Drawing.Point(73, 52);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(32, 32);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.StyleCustomMode = true;
            this.uiButton1.TabIndex = 7;
            this.uiButton1.Text = "Aa";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.SetToolTip(this.uiButton1, "text.sp.tooltip.case");
            this.uiButton1.Click += new System.EventHandler(this.FindInCase);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton2.Location = new System.Drawing.Point(111, 52);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(32, 32);
            this.uiButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton2.StyleCustomMode = true;
            this.uiButton2.TabIndex = 8;
            this.uiButton2.Text = ".*";
            this.uiButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.SetToolTip(this.uiButton2, "text.sp.tooltip.regex");
            this.uiButton2.Click += new System.EventHandler(this.FindInRegex);
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton3.Location = new System.Drawing.Point(149, 52);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(32, 32);
            this.uiButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton3.StyleCustomMode = true;
            this.uiButton3.TabIndex = 9;
            this.uiButton3.Text = "Ab";
            this.uiButton3.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.SetToolTip(this.uiButton3, "text.sp.tooltip.full");
            this.uiButton3.Click += new System.EventHandler(this.FindInFullWords);
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton4.Location = new System.Drawing.Point(187, 52);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(32, 32);
            this.uiButton4.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton4.StyleCustomMode = true;
            this.uiButton4.TabIndex = 10;
            this.uiButton4.Text = "✕";
            this.uiButton4.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.SetToolTip(this.uiButton4, "text.sp.tooltip.clear");
            this.uiButton4.Click += new System.EventHandler(this.Clear);
            // 
            // uiToolTip1
            // 
            this.uiToolTip1.AutoPopDelay = 5000;
            this.uiToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.uiToolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.uiToolTip1.InitialDelay = 250;
            this.uiToolTip1.OwnerDraw = true;
            this.uiToolTip1.ReshowDelay = 100;
            // 
            // CBoxCase
            // 
            this.CBoxCase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBoxCase.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxCase.Location = new System.Drawing.Point(230, 59);
            this.CBoxCase.MinimumSize = new System.Drawing.Size(1, 1);
            this.CBoxCase.Name = "CBoxCase";
            this.CBoxCase.Size = new System.Drawing.Size(58, 25);
            this.CBoxCase.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxCase.StyleCustomMode = true;
            this.CBoxCase.TabIndex = 11;
            this.CBoxCase.Text = "Aa";
            // 
            // CBoxRegex
            // 
            this.CBoxRegex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBoxRegex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxRegex.Location = new System.Drawing.Point(294, 59);
            this.CBoxRegex.MinimumSize = new System.Drawing.Size(1, 1);
            this.CBoxRegex.Name = "CBoxRegex";
            this.CBoxRegex.Size = new System.Drawing.Size(58, 25);
            this.CBoxRegex.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxRegex.StyleCustomMode = true;
            this.CBoxRegex.TabIndex = 12;
            this.CBoxRegex.Text = ".*";
            // 
            // CBoxFull
            // 
            this.CBoxFull.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBoxFull.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CBoxFull.Location = new System.Drawing.Point(358, 59);
            this.CBoxFull.MinimumSize = new System.Drawing.Size(1, 1);
            this.CBoxFull.Name = "CBoxFull";
            this.CBoxFull.Size = new System.Drawing.Size(58, 25);
            this.CBoxFull.Style = Sunny.UI.UIStyle.Custom;
            this.CBoxFull.StyleCustomMode = true;
            this.CBoxFull.TabIndex = 13;
            this.CBoxFull.Text = "Ab";
            // 
            // uiButton5
            // 
            this.uiButton5.BackgroundImage = global::IDE.Properties.Resources.unselect;
            this.uiButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton5.FillColor = System.Drawing.Color.Transparent;
            this.uiButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton5.Location = new System.Drawing.Point(12, 63);
            this.uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton5.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton5.Size = new System.Drawing.Size(30, 30);
            this.uiButton5.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton5.StyleCustomMode = true;
            this.uiButton5.TabIndex = 15;
            this.uiButton5.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.SetToolTip(this.uiButton5, "text.sp.tooltip.case");
            this.uiButton5.Click += new System.EventHandler(this.Cancel);
            // 
            // uiButton6
            // 
            this.uiButton6.BackgroundImage = global::IDE.Properties.Resources.select;
            this.uiButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton6.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiButton6.FillColor = System.Drawing.Color.Transparent;
            this.uiButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton6.Location = new System.Drawing.Point(12, 32);
            this.uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton6.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton6.Size = new System.Drawing.Size(30, 30);
            this.uiButton6.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton6.StyleCustomMode = true;
            this.uiButton6.TabIndex = 14;
            this.uiButton6.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiToolTip1.SetToolTip(this.uiButton6, "text.sp.tooltip.case");
            this.uiButton6.Click += new System.EventHandler(this.Yes);
            // 
            // RYCBSearchPanel
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 150);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.uiButton5);
            this.Controls.Add(this.uiButton6);
            this.Controls.Add(this.CBoxFull);
            this.Controls.Add(this.CBoxRegex);
            this.Controls.Add(this.CBoxCase);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.Collapse);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.TBoxFind);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "RYCBSearchPanel";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.ShowInTaskbar = false;
            this.ShowRect = false;
            this.ShowTitle = false;
            this.StyleCustomMode = true;
            this.Text = "RYCBSearchPanel";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);

    }

    #endregion

    internal Sunny.UI.UIStyleManager uiStyleManager1;
    internal Sunny.UI.UITextBox TBoxFind;
    internal Sunny.UI.UILabel uiLabel1;
    internal Sunny.UI.UIButton Close;
    internal Sunny.UI.UIButton Collapse;
    internal Sunny.UI.UILabel uiLabel2;
    internal Sunny.UI.UITextBox uiTextBox1;
    internal Sunny.UI.UILine uiLine1;
    internal Sunny.UI.UIButton uiButton1;
    internal Sunny.UI.UIButton uiButton2;
    internal Sunny.UI.UIButton uiButton3;
    internal Sunny.UI.UIToolTip uiToolTip1;
    internal Sunny.UI.UIButton uiButton4;
    internal Sunny.UI.UICheckBox CBoxCase;
    internal Sunny.UI.UICheckBox CBoxRegex;
    internal Sunny.UI.UICheckBox CBoxFull;
    internal Sunny.UI.UIButton uiButton6;
    internal Sunny.UI.UIButton uiButton5;
}