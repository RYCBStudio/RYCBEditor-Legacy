namespace IDE;

partial class InterpreterConfigBox
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TBoxItptrArgs = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBoxItptrType = new Sunny.UI.UIComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBoxItptrPath = new Sunny.UI.UITextBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.label5 = new System.Windows.Forms.Label();
            this.TBoxItptrFinalCmd = new Sunny.UI.UITextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiListBox1 = new Sunny.UI.UIListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiComboBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiListBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 387);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.TBoxItptrArgs, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CBoxItptrType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TBoxItptrPath, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.uiButton1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.TBoxItptrFinalCmd, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.button5, 2, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(167, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(656, 343);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // TBoxItptrArgs
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.TBoxItptrArgs, 2);
            this.TBoxItptrArgs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBoxItptrArgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBoxItptrArgs.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TBoxItptrArgs.Location = new System.Drawing.Point(168, 73);
            this.TBoxItptrArgs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxItptrArgs.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBoxItptrArgs.Multiline = true;
            this.TBoxItptrArgs.Name = "TBoxItptrArgs";
            this.TBoxItptrArgs.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.SetRowSpan(this.TBoxItptrArgs, 4);
            this.TBoxItptrArgs.ShowText = false;
            this.TBoxItptrArgs.Size = new System.Drawing.Size(484, 126);
            this.TBoxItptrArgs.TabIndex = 5;
            this.TBoxItptrArgs.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.TBoxItptrArgs.Watermark = "";
            this.TBoxItptrArgs.TextChanged += new System.EventHandler(this.UpdateItptrArgsInfo);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.tableLayoutPanel2.SetRowSpan(this.label4, 4);
            this.label4.Size = new System.Drawing.Size(158, 136);
            this.label4.TabIndex = 4;
            this.label4.Text = "text.icb.itptr.args";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "text.icb.itptr.type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBoxItptrType
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.CBoxItptrType, 2);
            this.CBoxItptrType.DataSource = null;
            this.CBoxItptrType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBoxItptrType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CBoxItptrType.FillColor = System.Drawing.Color.White;
            this.CBoxItptrType.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.CBoxItptrType.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.CBoxItptrType.Items.AddRange(new object[] {
            "System",
            "Local",
            "Virtual Environment(venv)"});
            this.CBoxItptrType.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CBoxItptrType.Location = new System.Drawing.Point(168, 5);
            this.CBoxItptrType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxItptrType.MinimumSize = new System.Drawing.Size(63, 0);
            this.CBoxItptrType.Name = "CBoxItptrType";
            this.CBoxItptrType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CBoxItptrType.Size = new System.Drawing.Size(484, 26);
            this.CBoxItptrType.TabIndex = 1;
            this.CBoxItptrType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CBoxItptrType.Watermark = "";
            this.CBoxItptrType.SelectedValueChanged += new System.EventHandler(this.UpdateItptrTypeInfo);
            this.CBoxItptrType.Click += new System.EventHandler(this.UpdateItptrTypeInfo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 34);
            this.label3.TabIndex = 2;
            this.label3.Text = "text.icb.itptr.path";
            // 
            // TBoxItptrPath
            // 
            this.TBoxItptrPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBoxItptrPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBoxItptrPath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TBoxItptrPath.Location = new System.Drawing.Point(168, 39);
            this.TBoxItptrPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxItptrPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBoxItptrPath.Name = "TBoxItptrPath";
            this.TBoxItptrPath.Padding = new System.Windows.Forms.Padding(5);
            this.TBoxItptrPath.ShowText = false;
            this.TBoxItptrPath.Size = new System.Drawing.Size(451, 26);
            this.TBoxItptrPath.Symbol = 162434;
            this.TBoxItptrPath.TabIndex = 3;
            this.TBoxItptrPath.Text = "C:\\Example\\eg\\Simple\\py.exe";
            this.TBoxItptrPath.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.TBoxItptrPath.Watermark = "";
            this.TBoxItptrPath.TextChanged += new System.EventHandler(this.UpdateItptrPathInfo);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("Yu Gothic UI", 14F);
            this.uiButton1.Location = new System.Drawing.Point(626, 37);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(27, 28);
            this.uiButton1.TabIndex = 6;
            this.uiButton1.Text = "...";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.ChooseDirectory);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 34);
            this.label5.TabIndex = 7;
            this.label5.Text = "text.icb.itptr.finalcmd";
            // 
            // TBoxItptrFinalCmd
            // 
            this.TBoxItptrFinalCmd.ButtonSymbol = 57433;
            this.TBoxItptrFinalCmd.ButtonWidth = 26;
            this.TBoxItptrFinalCmd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TBoxItptrFinalCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBoxItptrFinalCmd.FillReadOnlyColor = System.Drawing.Color.White;
            this.TBoxItptrFinalCmd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TBoxItptrFinalCmd.ForeReadOnlyColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.TBoxItptrFinalCmd.Location = new System.Drawing.Point(168, 243);
            this.TBoxItptrFinalCmd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxItptrFinalCmd.MinimumSize = new System.Drawing.Size(1, 16);
            this.TBoxItptrFinalCmd.Name = "TBoxItptrFinalCmd";
            this.TBoxItptrFinalCmd.Padding = new System.Windows.Forms.Padding(5);
            this.TBoxItptrFinalCmd.ReadOnly = true;
            this.TBoxItptrFinalCmd.ShowButton = true;
            this.TBoxItptrFinalCmd.ShowText = false;
            this.TBoxItptrFinalCmd.Size = new System.Drawing.Size(451, 26);
            this.TBoxItptrFinalCmd.TabIndex = 8;
            this.TBoxItptrFinalCmd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TBoxItptrFinalCmd.Watermark = "";
            this.TBoxItptrFinalCmd.ButtonClick += new System.EventHandler(this.CopyToPaste);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IDE.Properties.Resources.Exception_32X;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(626, 309);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 31);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 2);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(617, 37);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fail to delete. Something wrong happened.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            this.label6.VisibleChanged += new System.EventHandler(this.label6_VisibleChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::IDE.Properties.Resources.Run1;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(626, 241);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 28);
            this.button5.TabIndex = 11;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.RunCmd);
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiComboBox1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Items.AddRange(new object[] {
            "Python",
            "C#",
            "C++",
            "Java"});
            this.uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Location = new System.Drawing.Point(168, 5);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.Size = new System.Drawing.Size(654, 31);
            this.uiComboBox1.TabIndex = 5;
            this.uiComboBox1.Text = "Python";
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "text.icb.itptr";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiListBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiListBox1, 4);
            this.uiListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiListBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiListBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiListBox1.ItemSelectForeColor = System.Drawing.Color.White;
            this.uiListBox1.Location = new System.Drawing.Point(4, 81);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(2);
            this.uiListBox1.ShowText = false;
            this.uiListBox1.Size = new System.Drawing.Size(156, 301);
            this.uiListBox1.TabIndex = 6;
            this.uiListBox1.Text = "uiListBox1";
            this.uiListBox1.SelectedIndexChanged += new System.EventHandler(this.ReadValues);
            this.uiListBox1.SelectedValueChanged += new System.EventHandler(this.ReadValues);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::IDE.Properties.Resources.plus;
            this.button1.Location = new System.Drawing.Point(3, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 32);
            this.button1.TabIndex = 7;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddNewConfig);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Image = global::IDE.Properties.Resources.minus;
            this.button2.Location = new System.Drawing.Point(44, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 32);
            this.button2.TabIndex = 8;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeleteConfig);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Image = global::IDE.Properties.Resources.seek;
            this.button3.Location = new System.Drawing.Point(85, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 32);
            this.button3.TabIndex = 9;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SearchForExistingConfig);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::IDE.Properties.Resources.refresh;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(126, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 32);
            this.button4.TabIndex = 10;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.RefreshConfig);
            // 
            // uiStyleManager1
            // 
            this.uiStyleManager1.GlobalFont = true;
            this.uiStyleManager1.GlobalFontName = "微软雅黑";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "py.exe";
            this.openFileDialog1.Filter = "Python|*.exe";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.Wait);
            // 
            // InterpreterConfigBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(826, 422);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Name = "InterpreterConfigBox";
            this.Text = "text.icb.title";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Load += new System.EventHandler(this.InterpreterConfigBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private Sunny.UI.UIStyleManager uiStyleManager1;
    private System.Windows.Forms.Label label1;
    private Sunny.UI.UIComboBox uiComboBox1;
    private Sunny.UI.UIListBox uiListBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Label label2;
    private Sunny.UI.UIComboBox CBoxItptrType;
    private System.Windows.Forms.Label label3;
    private Sunny.UI.UITextBox TBoxItptrPath;
    private System.Windows.Forms.Label label4;
    private Sunny.UI.UITextBox TBoxItptrArgs;
    private Sunny.UI.UIButton uiButton1;
    private System.Windows.Forms.Label label5;
    private Sunny.UI.UITextBox TBoxItptrFinalCmd;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button5;
}