namespace IDE;

partial class WBBox
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
            this.uiWaitingBar1 = new Sunny.UI.UIWaitingBar();
            this.uiProcessBar1 = new Sunny.UI.UIProcessBar();
            this.SuspendLayout();
            // 
            // uiWaitingBar1
            // 
            this.uiWaitingBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiWaitingBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWaitingBar1.Location = new System.Drawing.Point(0, 0);
            this.uiWaitingBar1.MinimumSize = new System.Drawing.Size(70, 23);
            this.uiWaitingBar1.Name = "uiWaitingBar1";
            this.uiWaitingBar1.Size = new System.Drawing.Size(443, 23);
            this.uiWaitingBar1.TabIndex = 0;
            this.uiWaitingBar1.Text = "uiWaitingBar1";
            this.uiWaitingBar1.Visible = false;
            // 
            // uiProcessBar1
            // 
            this.uiProcessBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiProcessBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiProcessBar1.Location = new System.Drawing.Point(0, 0);
            this.uiProcessBar1.MinimumSize = new System.Drawing.Size(70, 3);
            this.uiProcessBar1.Name = "uiProcessBar1";
            this.uiProcessBar1.ShowValue = false;
            this.uiProcessBar1.Size = new System.Drawing.Size(443, 22);
            this.uiProcessBar1.TabIndex = 1;
            this.uiProcessBar1.Text = "uiProcessBar1";
            this.uiProcessBar1.Visible = false;
            // 
            // WBBox
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(443, 22);
            this.ControlBox = false;
            this.Controls.Add(this.uiProcessBar1);
            this.Controls.Add(this.uiWaitingBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WBBox";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Text = "";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Load += new System.EventHandler(this.WBBox_Load);
            this.ResumeLayout(false);

    }

    #endregion

    internal Sunny.UI.UIWaitingBar uiWaitingBar1;
    internal Sunny.UI.UIProcessBar uiProcessBar1;

}