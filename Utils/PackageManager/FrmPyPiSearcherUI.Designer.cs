namespace IDE.Utils;

partial class FrmPyPiSearcherUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPyPiSearcherUI));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Description = new Sunny.UI.UITextBox();
            this.Version = new Sunny.UI.UITextBox();
            this.SchBox = new Sunny.UI.UITextBox();
            this.Sch = new System.Windows.Forms.Button();
            this.ResLst = new System.Windows.Forms.ListBox();
            this.NameBox = new Sunny.UI.UITextBox();
            this.Inst = new System.Windows.Forms.Button();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.Pre = new System.Windows.Forms.Button();
            this.Page = new System.Windows.Forms.Label();
            this.End = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Nxt = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46725F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46725F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.66376F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.27074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46725F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.66376F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Description, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Version, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.SchBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Sch, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ResLst, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NameBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Inst, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel1, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.35484F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.12903F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 396);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Description
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Description, 4);
            this.Description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Description.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.Description.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Description.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Description.Location = new System.Drawing.Point(230, 144);
            this.Description.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Description.MinimumSize = new System.Drawing.Size(1, 16);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.Padding = new System.Windows.Forms.Padding(5);
            this.Description.ReadOnly = true;
            this.Description.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.tableLayoutPanel1.SetRowSpan(this.Description, 2);
            this.Description.ShowScrollBar = true;
            this.Description.ShowText = false;
            this.Description.Size = new System.Drawing.Size(418, 116);
            this.Description.TabIndex = 7;
            this.Description.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.Description.Watermark = "";
            // 
            // Version
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Version, 2);
            this.Version.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Version.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.Version.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Version.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Version.Location = new System.Drawing.Point(457, 81);
            this.Version.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Version.MinimumSize = new System.Drawing.Size(1, 16);
            this.Version.Name = "Version";
            this.Version.Padding = new System.Windows.Forms.Padding(5);
            this.Version.ReadOnly = true;
            this.Version.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.Version.ShowText = false;
            this.Version.Size = new System.Drawing.Size(191, 53);
            this.Version.TabIndex = 6;
            this.Version.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Version.Watermark = "";
            // 
            // SchBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SchBox, 5);
            this.SchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchBox.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.SchBox.Location = new System.Drawing.Point(4, 5);
            this.SchBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SchBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.SchBox.Name = "SchBox";
            this.SchBox.Padding = new System.Windows.Forms.Padding(5);
            this.SchBox.ShowText = false;
            this.SchBox.Size = new System.Drawing.Size(558, 66);
            this.SchBox.TabIndex = 0;
            this.SchBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.SchBox.Watermark = "";
            this.SchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiTextBox1_KeyDown);
            // 
            // Sch
            // 
            this.Sch.BackgroundImage = global::IDE.Properties.Resources.Pypi_search;
            this.Sch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Sch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sch.FlatAppearance.BorderSize = 0;
            this.Sch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sch.Location = new System.Drawing.Point(569, 3);
            this.Sch.Name = "Sch";
            this.Sch.Size = new System.Drawing.Size(80, 70);
            this.Sch.TabIndex = 1;
            this.Sch.UseVisualStyleBackColor = true;
            this.Sch.Click += new System.EventHandler(this.Search);
            // 
            // ResLst
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ResLst, 2);
            this.ResLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResLst.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ResLst.FormattingEnabled = true;
            this.ResLst.ItemHeight = 31;
            this.ResLst.Location = new System.Drawing.Point(3, 79);
            this.ResLst.Name = "ResLst";
            this.tableLayoutPanel1.SetRowSpan(this.ResLst, 5);
            this.ResLst.Size = new System.Drawing.Size(220, 314);
            this.ResLst.TabIndex = 2;
            this.ResLst.SelectedIndexChanged += new System.EventHandler(this.GetInfo);
            // 
            // NameBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.NameBox, 2);
            this.NameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameBox.FillReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.NameBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.NameBox.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.NameBox.Location = new System.Drawing.Point(230, 81);
            this.NameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.NameBox.Name = "NameBox";
            this.NameBox.Padding = new System.Windows.Forms.Padding(5);
            this.NameBox.ReadOnly = true;
            this.NameBox.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.NameBox.ShowText = false;
            this.NameBox.Size = new System.Drawing.Size(219, 53);
            this.NameBox.TabIndex = 5;
            this.NameBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameBox.Watermark = "";
            // 
            // Inst
            // 
            this.Inst.BackgroundImage = global::IDE.Properties.Resources.python_pip_install;
            this.Inst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.Inst, 4);
            this.Inst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inst.FlatAppearance.BorderSize = 2;
            this.Inst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.Inst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.Inst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Inst.ForeColor = System.Drawing.Color.Teal;
            this.Inst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Inst.Location = new System.Drawing.Point(229, 268);
            this.Inst.Name = "Inst";
            this.Inst.Size = new System.Drawing.Size(420, 57);
            this.Inst.TabIndex = 8;
            this.Inst.Text = "Install from Pip";
            this.Inst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Inst.UseVisualStyleBackColor = true;
            this.Inst.Click += new System.EventHandler(this.Install);
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.SetColumnSpan(this.uiTableLayoutPanel1, 4);
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.uiTableLayoutPanel1.Controls.Add(this.Nxt, 4, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.Start, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.End, 5, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.Page, 2, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.Pre, 0, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(229, 331);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 1;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(420, 62);
            this.uiTableLayoutPanel1.TabIndex = 10;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // Pre
            // 
            this.Pre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pre.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Pre.Location = new System.Drawing.Point(81, 3);
            this.Pre.Name = "Pre";
            this.Pre.Size = new System.Drawing.Size(72, 56);
            this.Pre.TabIndex = 4;
            this.Pre.Text = "<";
            this.Pre.UseVisualStyleBackColor = true;
            this.Pre.Click += new System.EventHandler(this.PrePg);
            // 
            // Page
            // 
            this.Page.AutoSize = true;
            this.uiTableLayoutPanel1.SetColumnSpan(this.Page, 2);
            this.Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page.Location = new System.Drawing.Point(159, 0);
            this.Page.Name = "Page";
            this.Page.Size = new System.Drawing.Size(98, 62);
            this.Page.TabIndex = 10;
            this.Page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // End
            // 
            this.End.Dock = System.Windows.Forms.DockStyle.Fill;
            this.End.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.End.Location = new System.Drawing.Point(341, 3);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(76, 56);
            this.End.TabIndex = 11;
            this.End.Text = ">>";
            this.End.UseVisualStyleBackColor = true;
            this.End.Click += new System.EventHandler(this.Ed);
            // 
            // Start
            // 
            this.Start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Start.Location = new System.Drawing.Point(3, 3);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(72, 56);
            this.Start.TabIndex = 12;
            this.Start.Text = "<<";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.St);
            // 
            // Nxt
            // 
            this.Nxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Nxt.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Nxt.Location = new System.Drawing.Point(263, 3);
            this.Nxt.Name = "Nxt";
            this.Nxt.Size = new System.Drawing.Size(72, 56);
            this.Nxt.TabIndex = 13;
            this.Nxt.Text = ">";
            this.Nxt.UseVisualStyleBackColor = true;
            this.Nxt.Click += new System.EventHandler(this.NxtPg);
            // 
            // PyPiSearcherUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(652, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PyPiSearcherUI";
            this.ShowTitleIcon = true;
            this.Text = "PyPi";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            this.Load += new System.EventHandler(this.PyPiSearcherUI_Load);
            this.Shown += new System.EventHandler(this.PyPiSearcherUI_AfterShown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private Sunny.UI.UITextBox SchBox;
    private System.Windows.Forms.Button Sch;
    private System.Windows.Forms.ListBox ResLst;
    private Sunny.UI.UITextBox NameBox;
    private Sunny.UI.UITextBox Version;
    private Sunny.UI.UITextBox Description;
    private System.Windows.Forms.Button Inst;
    private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
    private System.Windows.Forms.Button Pre;
    private System.Windows.Forms.Button End;
    private System.Windows.Forms.Label Page;
    private System.Windows.Forms.Button Nxt;
    private System.Windows.Forms.Button Start;
}