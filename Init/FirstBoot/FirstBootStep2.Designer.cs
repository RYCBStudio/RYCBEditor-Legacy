namespace IDE.Init;

partial class FirstBootStep2
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiLine2 = new Sunny.UI.UILine();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.uiIntegerUpDown2 = new Sunny.UI.UIIntegerUpDown();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(3, 35);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(252, 27);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "与君初相识，犹如故人归。";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(3, 62);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(212, 27);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "下面是一些基础设置。";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(522, 360);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 15;
            this.uiButton1.Size = new System.Drawing.Size(78, 33);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "下一步";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.Next);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton2.Location = new System.Drawing.Point(8, 360);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Radius = 15;
            this.uiButton2.Size = new System.Drawing.Size(78, 33);
            this.uiButton2.TabIndex = 3;
            this.uiButton2.Text = "上一步";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Click += new System.EventHandler(this.Previous);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBox1.Location = new System.Drawing.Point(349, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 151);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Example Text\r\n示例文字\r\nサンプルテキスト\r\nعينة من النص\r\nBeispieltext";
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.Location = new System.Drawing.Point(8, 92);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(319, 25);
            this.uiLine1.TabIndex = 5;
            this.uiLine1.Text = "选择你的主界面字体";
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton3.Location = new System.Drawing.Point(8, 160);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(319, 29);
            this.uiButton3.TabIndex = 6;
            this.uiButton3.Text = "微软雅黑";
            this.uiButton3.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton3.Click += new System.EventHandler(this.ChangeMainFont);
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(4, 117);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(339, 40);
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "右侧的文字框实时显示了你所选择的主界面字体。\r\n你可以点击下方按钮以选择。";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontDialog1
            // 
            this.fontDialog1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.fontDialog1.FontMustExist = true;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(3, 220);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(339, 60);
            this.uiLabel4.TabIndex = 10;
            this.uiLabel4.Text = "右侧的文字框实时显示了你所选择的编辑器字体。\r\n你可以点击下方按钮以选择。\r\n推荐：JetBrains Mono";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButton4.Location = new System.Drawing.Point(8, 283);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(324, 29);
            this.uiButton4.TabIndex = 9;
            this.uiButton4.Text = "JetBrains Mono";
            this.uiButton4.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.Click += new System.EventHandler(this.ChangeEditorText);
            // 
            // uiLine2
            // 
            this.uiLine2.BackColor = System.Drawing.Color.Transparent;
            this.uiLine2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine2.Location = new System.Drawing.Point(8, 195);
            this.uiLine2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine2.Name = "uiLine2";
            this.uiLine2.Size = new System.Drawing.Size(319, 25);
            this.uiLine2.TabIndex = 8;
            this.uiLine2.Text = "选择你的编辑器字体";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("JetBrains Mono", 12F);
            this.textBox2.Location = new System.Drawing.Point(348, 197);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(252, 78);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "Example Text\r\n示例文字";
            // 
            // uiIntegerUpDown2
            // 
            this.uiIntegerUpDown2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiIntegerUpDown2.Location = new System.Drawing.Point(339, 283);
            this.uiIntegerUpDown2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown2.Minimum = 1;
            this.uiIntegerUpDown2.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown2.Name = "uiIntegerUpDown2";
            this.uiIntegerUpDown2.ShowText = false;
            this.uiIntegerUpDown2.Size = new System.Drawing.Size(100, 28);
            this.uiIntegerUpDown2.TabIndex = 14;
            this.uiIntegerUpDown2.Text = "uiIntegerUpDown2";
            this.uiIntegerUpDown2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiIntegerUpDown2.Value = 12;
            this.uiIntegerUpDown2.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.UpdateEditorFont);
            // 
            // FirstBootStep2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(603, 396);
            this.Controls.Add(this.uiIntegerUpDown2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiLine2);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.Name = "FirstBootStep2";
            this.Text = "Basic Settings";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Sunny.UI.UILabel uiLabel1;
    private Sunny.UI.UILabel uiLabel2;
    private Sunny.UI.UIButton uiButton1;
    private Sunny.UI.UIButton uiButton2;
    private System.Windows.Forms.TextBox textBox1;
    private Sunny.UI.UILine uiLine1;
    private Sunny.UI.UIButton uiButton3;
    private Sunny.UI.UILabel uiLabel3;
    private System.Windows.Forms.FontDialog fontDialog1;
    private Sunny.UI.UILabel uiLabel4;
    private Sunny.UI.UIButton uiButton4;
    private Sunny.UI.UILine uiLine2;
    private System.Windows.Forms.TextBox textBox2;
    private Sunny.UI.UIIntegerUpDown uiIntegerUpDown2;
}