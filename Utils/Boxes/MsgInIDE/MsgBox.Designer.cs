
namespace IDE;

partial class MsgBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgBox));
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.SuspendLayout();
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.htmlLabel1.Location = new System.Drawing.Point(0, 35);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(416, 170);
            this.htmlLabel1.TabIndex = 0;
            // 
            // MsgBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(416, 205);
            this.Controls.Add(this.htmlLabel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MsgBox";
            this.Text = "MsgBox";
            this.TitleFont = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Activated += new System.EventHandler(this.PreInit);
            this.Deactivate += new System.EventHandler(this.HideProcess);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MsgBox_FormClosing);
            this.Load += new System.EventHandler(this.PreInit);
            this.Shown += new System.EventHandler(this.PostInit);
            this.SizeChanged += new System.EventHandler(this.MsgBox_SizeChanged);
            this.ResumeLayout(false);

    }

    #endregion

    private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
}