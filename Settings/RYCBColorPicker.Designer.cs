namespace IDE;

partial class RYCBColorPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RYCBColorPicker));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.uiColorPicker1 = new Sunny.UI.UIColorPicker();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.rgbText = new Sunny.UI.UITextBox();
            this.hexText = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiColorPicker1
            // 
            this.uiColorPicker1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiColorPicker1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.uiColorPicker1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker1.FullControlSelect = true;
            this.uiColorPicker1.Location = new System.Drawing.Point(4, 130);
            this.uiColorPicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker1.Name = "uiColorPicker1";
            this.uiColorPicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker1.Size = new System.Drawing.Size(345, 32);
            this.uiColorPicker1.Style = Sunny.UI.UIStyle.Custom;
            this.uiColorPicker1.StyleCustomMode = true;
            this.uiColorPicker1.TabIndex = 0;
            this.uiColorPicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiColorPicker1.Watermark = "";
            this.uiColorPicker1.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.Update);
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.Style = Sunny.UI.UIStyle.Black;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(3, 39);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(94, 32);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Black;
            this.uiLabel1.TabIndex = 2;
            this.uiLabel1.Text = "text.settings.colorpicker.tip.rgb";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rgbText
            // 
            this.rgbText.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.rgbText.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.rgbText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rgbText.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rgbText.FillColor2 = System.Drawing.Color.White;
            this.rgbText.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rgbText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rgbText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.rgbText.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.rgbText.Location = new System.Drawing.Point(119, 40);
            this.rgbText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rgbText.MinimumSize = new System.Drawing.Size(1, 16);
            this.rgbText.Name = "rgbText";
            this.rgbText.Padding = new System.Windows.Forms.Padding(5);
            this.rgbText.ReadOnly = true;
            this.rgbText.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.rgbText.RectReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.rgbText.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.rgbText.ShowText = false;
            this.rgbText.Size = new System.Drawing.Size(230, 31);
            this.rgbText.Style = Sunny.UI.UIStyle.Custom;
            this.rgbText.StyleCustomMode = true;
            this.rgbText.TabIndex = 3;
            this.rgbText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.rgbText.Watermark = "";
            // 
            // hexText
            // 
            this.hexText.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.hexText.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            this.hexText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hexText.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.hexText.FillColor2 = System.Drawing.Color.White;
            this.hexText.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.hexText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hexText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.hexText.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.hexText.Location = new System.Drawing.Point(137, 81);
            this.hexText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hexText.MinimumSize = new System.Drawing.Size(1, 16);
            this.hexText.Name = "hexText";
            this.hexText.Padding = new System.Windows.Forms.Padding(5);
            this.hexText.ReadOnly = true;
            this.hexText.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.hexText.RectReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.hexText.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.hexText.ShowText = false;
            this.hexText.Size = new System.Drawing.Size(212, 31);
            this.hexText.Style = Sunny.UI.UIStyle.Custom;
            this.hexText.StyleCustomMode = true;
            this.hexText.TabIndex = 5;
            this.hexText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hexText.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.White;
            this.uiLabel2.Location = new System.Drawing.Point(3, 80);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 32);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Black;
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "text.settings.colorpicker.tip.hex";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.White;
            this.uiLabel3.Location = new System.Drawing.Point(114, 81);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(23, 32);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Black;
            this.uiLabel3.TabIndex = 6;
            this.uiLabel3.Text = "#";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RYCBColorPicker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(353, 174);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.hexText);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.rgbText);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiColorPicker1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RYCBColorPicker";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(58)))), ((int)(((byte)(92)))));
            this.Style = Sunny.UI.UIStyle.Black;
            this.Text = "text.settings.colorpicker.title";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Load += new System.EventHandler(this.RYCBColorPicker_Load);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ColorDialog colorDialog1;
    private Sunny.UI.UIColorPicker uiColorPicker1;
    private Sunny.UI.UIStyleManager uiStyleManager1;
    private Sunny.UI.UILabel uiLabel1;
    private Sunny.UI.UITextBox rgbText;
    private Sunny.UI.UITextBox hexText;
    private Sunny.UI.UILabel uiLabel2;
    private Sunny.UI.UILabel uiLabel3;
}