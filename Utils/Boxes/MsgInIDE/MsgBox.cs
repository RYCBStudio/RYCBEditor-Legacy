using System;
using Markdig;
using Sunny.UI;

namespace IDE;
public partial class MsgBox : UIForm
{

    private MsgType CurrentMsgType { get; set; }
    public string MarkdownText { get; set; }
    private string htmlText;

    public MsgBox(MsgType type, string markdownText)
    {
        InitializeComponent();
        CurrentMsgType = type;
        MarkdownText = markdownText;
    }

    public enum MsgType
    {
        Normal,
        Warning,
        Error,
        Fatal,
    }

    private async void PreInit(object sender, EventArgs e)
    {
        await webView21.EnsureCoreWebView2Async();
        if (!MarkdownText.IsNullOrEmpty())
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
    }

    private bool GetHtmlText()
    {
        try
        {
            htmlText = Markdown.ToHtml(MarkdownText);
            return true;
        }
        catch { return false; }
    }

    private void PostInit(object sender, EventArgs e)
    {
        if (GetHtmlText())
        {
            webView21.CoreWebView2.NavigateToString(htmlText);
        }
    }
}
