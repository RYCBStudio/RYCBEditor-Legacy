using System;
using System.Windows.Forms;
using Markdig;
using Sunny.UI;

namespace IDE;
public partial class MsgBox : UIForm
{

    public MsgType CurrentMsgType
    {
        get; set;
    }
    public string MarkdownText
    {
        get; set;
    }
    public Exception CurrentException
    {
        get; set;
    }
    private string htmlText;
    private bool webView2Initialized;
    public Form MainForm;


    public MsgBox(MsgType type, string markdownText, Form form)
    {
        InitializeComponent();
        CurrentMsgType = type;
        MarkdownText = markdownText;
        MainForm = form;
    }

    public MsgBox(Exception ex, Form form, MsgType type = MsgType.Error)
    {
        InitializeComponent();
        CurrentException = ex;
        CurrentMsgType = type;
        MainForm = form;
    }

    public enum MsgType
    {
        Normal,
        Warning,
        Error,
        Fatal,
    }

    private void PreInit(object sender, EventArgs e)
    {
        if (CurrentException is not null)
        {
            var StackTrace = CurrentException.StackTrace.GetLines();
            var ExName = CurrentException.GetType().ToString();
            var ExMsg = CurrentException.Message;
            var Msg_Pre =
                $"""
                <h3>Error</h3> 
                <hr />
                <h4>Type:{ExName}</h4>
                <h4>Message:{ExMsg}</h4>
                <h4>Stacktrace(s):</h4>
                """;
            var Msg_Mid = "<p>";
            foreach (var item in StackTrace)
            {
                Msg_Mid += item;
                Msg_Mid += "<br />";
            }
            Msg_Mid += "</p>";
            var Msg_Suf =
                """
                <h3>Error has been written into the log file.</h3>
                """;
            var Msg = 
                $"""
                {Msg_Pre}
                {Msg_Mid}
                {Msg_Suf}
                """;
            htmlText = Msg;
        }
        if (!MarkdownText.IsNullOrEmpty() || !htmlText.IsNullOrEmpty())
        {
            switch (CurrentMsgType)
            {
                case MsgType.Normal:
                    this.Style = UIStyle.Green;
                    break;
                case MsgType.Warning:
                    this.Style = UIStyle.LayuiGreen;
                    break;
                case MsgType.Error:
                    this.Style = UIStyle.LayuiRed;
                    break;
                case MsgType.Fatal:
                    this.Style = UIStyle.Red;
                    break;
            }
        }
        if (!MainForm.IsNull())
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new(MainForm.Size.Width - this.Width - 25, MainForm.Size.Height - this.Height - 25);
        }
        if (GetHtmlText())
        {
            htmlLabel1.Text = htmlText;
        }
    }

    private bool GetHtmlText()
    {
        try
        {
            if (MarkdownText.IsNullOrEmpty())
            {
                htmlLabel1.Text = htmlText;
                return true;
            }
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            htmlText = Markdown.ToHtml(MarkdownText, pipeline);
            return true;
        }
        catch { return false; }
    }

    private void PostInit(object sender, EventArgs e)
    {
        if (GetHtmlText())
        {
            htmlLabel1.Text = htmlText;
        }
    }

    private void MsgBox_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Hide();
    }

    private void HideProcess(object sender, EventArgs e)
    {
        htmlLabel1.Text = string.Empty;
    }
}
