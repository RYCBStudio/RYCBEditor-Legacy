using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sunny.UI;

namespace IDE;
internal partial class ErrorMessageBox : UIForm
{

    internal enum Engines
    {
        SIMPLIFIED_CHINESE = 0,
        TRADITIONAL_CHINESE_CHINA = 1,
        TRADITIONAL_CHINESE_GLOBAL = 2,
        JAPANESE = 3,
    }

    private string _error;
    private TextEditor _editor;
    private Form _parent;
    private List<string> errors = new();
    private List<string> exceptions = new();
    private List<int> lines = new();
    private List<string> contents = new();

    internal static readonly Dictionary<Engines, string> TranslateEngines = new()
    {
        { Engines.SIMPLIFIED_CHINESE, "https://fanyi.baidu.com/#en/zh/{text}"},
        { Engines.TRADITIONAL_CHINESE_CHINA, "https://fanyi.baidu.com/#en/zht/{text}"},
        { Engines.TRADITIONAL_CHINESE_GLOBAL, "https://translate.google.com/?sl=auto&tl=zh-TW&text={text}&op=translate"},
        { Engines.JAPANESE, "https://translate.google.com/?sl=auto&tl=ja&text={text}&op=translate"},
    };
    internal static readonly Dictionary<Engines, string> SearchEngines = new()
    {
        { Engines.SIMPLIFIED_CHINESE, "https://cn.bing.com/search?q=Python+{text}"},
        { Engines.TRADITIONAL_CHINESE_CHINA, "https://www.bing.com/search?q=Python+{text}"},
        { Engines.TRADITIONAL_CHINESE_GLOBAL, "https://www.google.com/search?q=Python+{text}"},
        { Engines.JAPANESE, "https://www.google.com/search?q=Python+{text}"},
    };

    public ErrorMessageBox(string error, TextEditor editor, Form parent)
    {
        InitializeComponent();
        InitializeTranslation();
        this._error = error;
        this._editor = editor;
        this._parent = parent;
        this.Location = new System.Drawing.Point((int)editor.ActualWidth - 100, Screen.PrimaryScreen.WorkingArea.Height - (int)editor.ActualHeight - this.Height+100);
        this.TopMost = true;
    }

    private void Translate(object sender, EventArgs e)
    {
        var lang = GlobalSettings.language;
        switch (lang)
        {
            case "zh-CN":
                Process.Start(TranslateEngines[Engines.SIMPLIFIED_CHINESE].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                break;
            case "zh-TD":
                var res = MessageBoxEX.Show("Please select the translate engine: ", "Info", MessageBoxButtons.OKCancel, new string[] { "Google", "Baidu" });
                if (res == DialogResult.OK)
                {
                    Process.Start(TranslateEngines[Engines.TRADITIONAL_CHINESE_GLOBAL].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                }
                else if (res == DialogResult.Cancel)
                {
                    Process.Start(TranslateEngines[Engines.TRADITIONAL_CHINESE_CHINA].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                }
                break;
            case "ja-JP":
                Process.Start(TranslateEngines[Engines.JAPANESE].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                break;
            default:
                break;
        }
    }

    internal void GetErrorsLinesAndFunctions()
    {
        foreach (var item in errors)
        {
            item.Replace("\r\n", "");
            item.Replace("\r", "");
            item.Replace("\n", "");
            var _errors = item.Split(new string[] { "\n", "\t", "\r", string.Empty }, StringSplitOptions.RemoveEmptyEntries); ;
            this.exceptions.Add(GetExceptionAndContent(_errors[_errors.Length - 1])[0]);
            this.lines.Add(GetLineNumber(_errors[1]));
            this.contents.Add(GetExceptionAndContent(_errors[_errors.Length - 1])[1]);
        }
    }

    private static List<string> GetExceptionAndContent(string input)
    {
        var result = new List<string>();

        var colonIndex = input.IndexOf(':');

        if (colonIndex >= 0)
        {
            var exception = input.Substring(0, colonIndex).Trim();
            var content = input.Substring(colonIndex + 1).Trim();

            result.Add(exception);
            result.Add(content);
        }
        else
        {
            result.Add(input.Trim());
            result.Add("<None>");
        }

        return result;
    }

    private static int GetLineNumber(string input)
    {
        var lineNumber = 0;

        var startIndex = input.LastIndexOf("line ") + 5; // 找到行号开始的位置
        var endIndex = input.IndexOf(',', startIndex); // 找到行号结束的位置

        if (startIndex >= 0 && endIndex > startIndex)
        {
            var lineNumberString = input.Substring(startIndex, endIndex - startIndex);
            int.TryParse(lineNumberString, out lineNumber); // 将行号字符串转换为整数
        }

        return lineNumber;
    }

    private void ErrorMessageBox_Load(object sender, EventArgs e)
    {
        if (_error.Contains("During handling of the above exception, another exception occurred:"))
        {
            foreach (var item in _error.Split("During handling of the above exception, another exception occurred:"))
            {
                errors.Add(item);
            }
        }
        else
        {
            errors.Add(_error);
        }
        GetErrorsLinesAndFunctions();
        this.tabPage1.Text = this.exceptions[0];
        this.uiTextBox1.Text = this.exceptions[0];
        this.uiTextBox2.Text = this.lines[0].ToString();
        this.uiTextBox3.Text = this.contents[0];
        for (var i = 1; i < errors.Count - 1; i++)
        {
            #region Controls Setup
            this.uiTabControlMenu1.SuspendLayout();
            this.SuspendLayout();
            TabPage newTab = new();
            Button newBtn = new(), newBtn2 = new();
            UITextBox newTxtBox1 = new(), newTxtBox2 = new(), newTxtBox3 = new();
            UILabel l1 = new(), l2 = new(), l3 = new();
            UIButton btn1 = new(), btn2 = new();
            newTab.SuspendLayout();
            #region newTxtBox3
            newTxtBox3.ButtonFillColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox3.ButtonFillHoverColor = System.Drawing.Color.FromArgb((int)(byte)51, (int)(byte)203, (int)(byte)189);
            newTxtBox3.ButtonFillPressColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)152, (int)(byte)138);
            newTxtBox3.ButtonRectColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox3.ButtonRectHoverColor = System.Drawing.Color.FromArgb((int)(byte)51, (int)(byte)203, (int)(byte)189);
            newTxtBox3.ButtonRectPressColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)152, (int)(byte)138);
            newTxtBox3.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            newTxtBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            newTxtBox3.FillColor2 = System.Drawing.Color.FromArgb((int)(byte)238, (int)(byte)251, (int)(byte)250);
            newTxtBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            newTxtBox3.Location = new System.Drawing.Point(85, 109);
            newTxtBox3.Margin = new Padding(4, 5, 4, 5);
            newTxtBox3.MinimumSize = new System.Drawing.Size(1, 16);
            newTxtBox3.Multiline = true;
            newTxtBox3.Name = "uiTextBox3";
            newTxtBox3.Padding = new Padding(5);
            newTxtBox3.ReadOnly = true;
            newTxtBox3.RectColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox3.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            newTxtBox3.ScrollBarColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox3.ShowText = false;
            newTxtBox3.Size = new System.Drawing.Size(222, 145);
            newTxtBox3.Style = Sunny.UI.UIStyle.Custom;
            newTxtBox3.StyleCustomMode = true;
            newTxtBox3.TabIndex = 7;
            newTxtBox3.Text = contents[i];
            newTxtBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            newTxtBox3.Watermark = "";
            #endregion
            #region newTxtBox2
            newTxtBox2.ButtonFillColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox2.ButtonFillHoverColor = System.Drawing.Color.FromArgb((int)(byte)51, (int)(byte)203, (int)(byte)189);
            newTxtBox2.ButtonFillPressColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)152, (int)(byte)138);
            newTxtBox2.ButtonRectColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox2.ButtonRectHoverColor = System.Drawing.Color.FromArgb((int)(byte)51, (int)(byte)203, (int)(byte)189);
            newTxtBox2.ButtonRectPressColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)152, (int)(byte)138);
            newTxtBox2.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            newTxtBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            newTxtBox2.FillColor2 = System.Drawing.Color.FromArgb((int)(byte)238, (int)(byte)251, (int)(byte)250);
            newTxtBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            newTxtBox2.Location = new System.Drawing.Point(85, 54);
            newTxtBox2.Margin = new Padding(4, 5, 4, 5);
            newTxtBox2.MinimumSize = new System.Drawing.Size(1, 16);
            newTxtBox2.Name = "uiTextBox2";
            newTxtBox2.Padding = new Padding(5);
            newTxtBox2.ReadOnly = true;
            newTxtBox2.RectColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            newTxtBox2.ScrollBarColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox2.ShowText = false;
            newTxtBox2.Size = new System.Drawing.Size(183, 42);
            newTxtBox2.Style = Sunny.UI.UIStyle.Custom;
            newTxtBox2.StyleCustomMode = true;
            newTxtBox2.TabIndex = 4;
            newTxtBox2.Text = lines[i].ToString();
            newTxtBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            newTxtBox2.Watermark = "";
            #endregion
            #region newTxtBox1
            newTxtBox1.AutoSize = true;
            newTxtBox1.ButtonFillColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox1.ButtonFillHoverColor = System.Drawing.Color.FromArgb((int)(byte)51, (int)(byte)203, (int)(byte)189);
            newTxtBox1.ButtonFillPressColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)152, (int)(byte)138);
            newTxtBox1.ButtonRectColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox1.ButtonRectHoverColor = System.Drawing.Color.FromArgb((int)(byte)51, (int)(byte)203, (int)(byte)189);
            newTxtBox1.ButtonRectPressColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)152, (int)(byte)138);
            newTxtBox1.ButtonSymbolOffset = new System.Drawing.Point(0, 0);
            newTxtBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            newTxtBox1.FillColor2 = System.Drawing.Color.FromArgb((int)(byte)238, (int)(byte)251, (int)(byte)250);
            newTxtBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            newTxtBox1.Location = new System.Drawing.Point(85, 9);
            newTxtBox1.Margin = new Padding(4, 5, 4, 5);
            newTxtBox1.MinimumSize = new System.Drawing.Size(1, 16);
            newTxtBox1.Name = "uiTextBox1";
            newTxtBox1.Padding = new Padding(5);
            newTxtBox1.ReadOnly = true;
            newTxtBox1.RectColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            newTxtBox1.ScrollBarColor = System.Drawing.Color.FromArgb((int)(byte)0, (int)(byte)190, (int)(byte)172);
            newTxtBox1.ShowText = false;
            newTxtBox1.Size = new System.Drawing.Size(183, 42);
            newTxtBox1.Style = Sunny.UI.UIStyle.Custom;
            newTxtBox1.StyleCustomMode = true;
            newTxtBox1.TabIndex = 1;
            newTxtBox1.Text = exceptions[i];
            newTxtBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            newTxtBox1.Watermark = "";
            #endregion
            #region l1
            l1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            l1.Location = new System.Drawing.Point(3, 7);
            l1.Name = "uiLabel1";
            l1.Size = new System.Drawing.Size(75, 29);
            l1.Style = Sunny.UI.UIStyle.Custom;
            l1.TabIndex = 0;
            l1.Text = uiLabel1.Text;
            l1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            #endregion
            #region l2
            l2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            l2.Location = new System.Drawing.Point(3, 63);
            l2.Name = "uiLabel2";
            l2.Size = new System.Drawing.Size(75, 29);
            l2.Style = Sunny.UI.UIStyle.Custom;
            l2.TabIndex = 3;
            l2.Text = uiLabel2.Text;
            l2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            #endregion
            #region l3
            l3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            l3.Location = new System.Drawing.Point(3, 109);
            l3.Name = "uiLabel3";
            l3.Size = new System.Drawing.Size(75, 98);
            l3.Style = Sunny.UI.UIStyle.Custom;
            l3.TabIndex = 6;
            l3.Text = uiLabel3.Text;
            l3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            #endregion
            #region btn1
            btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            btn1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            btn1.Location = new System.Drawing.Point(275, 3);
            btn1.MinimumSize = new System.Drawing.Size(1, 1);
            btn1.Name = "uiButton1";
            btn1.Radius = 15;
            btn1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            btn1.Size = new System.Drawing.Size(33, 33);
            btn1.Style = Sunny.UI.UIStyle.Custom;
            btn1.StyleCustomMode = true;
            btn1.TabIndex = 2;
            btn1.Text = "?";
            btn1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            btn1.Click += new EventHandler(this.GetHelp);
            #endregion
            #region btn2
            btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            btn2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            btn2.Location = new System.Drawing.Point(275, 59);
            btn2.MinimumSize = new System.Drawing.Size(1, 1);
            btn2.Name = "uiButton2";
            btn2.Radius = 15;
            btn2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            btn2.Size = new System.Drawing.Size(33, 33);
            btn2.Style = Sunny.UI.UIStyle.Custom;
            btn2.StyleCustomMode = true;
            btn2.TabIndex = 5;
            btn2.Text = "⇱";
            btn2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)134);
            btn2.Click += new EventHandler(this.GoToLine);
            #endregion
            #region newBtn
            newBtn.BackgroundImage = Properties.Resources.translate;
            newBtn.BackgroundImageLayout = ImageLayout.Stretch;
            newBtn.Location = new System.Drawing.Point(42, 223);
            newBtn.Name = "button1";
            newBtn.Size = new System.Drawing.Size(36, 36);
            newBtn.TabIndex = 8;
            newBtn.UseVisualStyleBackColor = true;
            newBtn.Click += new EventHandler(this.Translate);
            #endregion
            #region newBtn2
            newBtn2.BackgroundImage = global::IDE.Properties.Resources.seek;
            newBtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            newBtn2.Location = new System.Drawing.Point(0, 223);
            newBtn2.Name = "button2";
            newBtn2.Size = new System.Drawing.Size(36, 36);
            newBtn2.TabIndex = 9;
            newBtn2.UseVisualStyleBackColor = true;
            newBtn2.Click += new EventHandler(this.GetWebHelp);
            #endregion
            #region newTab
            newTab.Controls.Add(newBtn);
            newTab.Controls.Add(newTxtBox3);
            newTab.Controls.Add(l3);
            newTab.Controls.Add(btn2);
            newTab.Controls.Add(newTxtBox2);
            newTab.Controls.Add(l2);
            newTab.Controls.Add(btn1);
            newTab.Controls.Add(newTxtBox1);
            newTab.Controls.Add(l1);
            newTab.Controls.Add(newBtn2);
            newTab.Location = new System.Drawing.Point(151, 0);
            newTab.Name = "tabPage1";
            newTab.Size = new System.Drawing.Size(311, 259);
            newTab.TabIndex = i;
            newTab.Text = this.exceptions[i];
            newTab.UseVisualStyleBackColor = true;
            uiTabControlMenu1.TabPages.Add(newTab);
            this.uiTabControlMenu1.ResumeLayout(false);
            newTab.ResumeLayout(false);
            newTab.PerformLayout();
            this.ResumeLayout(false);
            #endregion
            #endregion
        }
    }

    private void GoToLine(object sender, EventArgs e)
    {
        this._editor.ScrollToLine(Convert.ToInt32(uiTabControlMenu1.SelectedTab.Controls["uiTextBox2"].Text));
        this._parent.Focus();
    }

    private void GetHelp(object sender, EventArgs e)
    {
        var lang = GlobalSettings.language;
        switch (lang)
        {
            case "zh-CN":
                Process.Start(SearchEngines[Engines.SIMPLIFIED_CHINESE].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox1"].Text));
                break;
            case "zh-TD":
                if (MessageBoxEX.Show("Please select the search engine: ", "Info", MessageBoxButtons.OKCancel, new string[] { "Google", "Baidu" }) == DialogResult.OK)
                {
                    Process.Start(SearchEngines[Engines.TRADITIONAL_CHINESE_GLOBAL].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox1"].Text));
                }
                else
                {
                    Process.Start(SearchEngines[Engines.TRADITIONAL_CHINESE_CHINA].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox1"].Text));
                }
                break;
            case "ja-JP":
                Process.Start(SearchEngines[Engines.JAPANESE].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox1"].Text));
                break;
            default:
                break;
        }
    }

    private void GetWebHelp(object sender, EventArgs e)
    {
        var lang = GlobalSettings.language;
        switch (lang)
        {
            case "zh-CN":
                Process.Start(SearchEngines[Engines.SIMPLIFIED_CHINESE].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                break;
            case "zh-TD":
                if (MessageBoxEX.Show("Please select the translate engine: ", "Info", MessageBoxButtons.OKCancel, new string[] { "Google", "Baidu" }) == DialogResult.OK)
                {
                    Process.Start(SearchEngines[Engines.TRADITIONAL_CHINESE_GLOBAL].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                }
                else
                {
                    Process.Start(SearchEngines[Engines.TRADITIONAL_CHINESE_CHINA].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                }
                break;
            case "ja-JP":
                Process.Start(SearchEngines[Engines.JAPANESE].Replace("{text}", uiTabControlMenu1.SelectedTab.Controls["uiTextBox3"].Text));
                break;
            default:
                break;
        }
    }
}
