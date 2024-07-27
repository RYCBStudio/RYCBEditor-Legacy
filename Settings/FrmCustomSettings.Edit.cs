using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using Sunny.UI;
using System.Xml;

namespace IDE;
public partial class FrmCustomSettings
{
    private void OpenEditor(object sender, EventArgs e)
    {
        new CustomSettingsFileEditor().Show();
    }

    private void EditXshdFiles(object sender, EventArgs e)
    {
        new XshdFileEditor(TBoxXshdCache.Text + "\\" + CBoxEditorXshd.SelectedItem).Show();
    }

    private void ChangeXshdColor(object sender, EventArgs e)
    {
        var path = "";
        foreach (var item in xshd_files)
        {
            if (item.EndsWith(CBoxEditorXshd.Text))
            {
                path = item;
                break;
            }
        }
        GetColors(path);
    }

    private void Update(object sender, int value)
    {
        settings.Write("Editor", "Size", NUDFontSize.Value);
        settings.Write("Editor", "Font", CBoxEditorFont.SelectedText);
        edit.FontFamily = new FontFamily(CBoxEditorFont.SelectedText);
        edit.FontSize = NUDFontSize.Value;
    }

    private void UpdateSettings(object sender, EventArgs e)
    {
        settings.Write("Editor", "ShowLineNum", CkBoxShowLN.Checked.ToString().ToLower());
        edit.ShowLineNumbers = CkBoxShowLN.Checked;
    }

    private void ChooseColor(object sender, EventArgs e)
    {
        FrmRYCBColorPicker picker = new()
        {
            Color = ((Button)sender).BackColor
        };
        picker.ShowDialog(this);
        ((Button)sender).BackColor = picker.Color;
    }

    private void Update(object sender, EventArgs e)
    {
        settings.Write("Editor", "Font", CBoxEditorFont.SelectedText);
        settings.Write("Editor", "Size", NUDFontSize.Value);
        edit.FontFamily = new FontFamily(CBoxEditorFont.SelectedText);
        edit.FontSize = NUDFontSize.Value;
        edit.ShowLineNumbers = CkBoxShowLN.Checked;

    }

    private void GetColors(string path)
    {
        if (path.Contains("PlainText"))
        {
            BtnColor_Com.Disabled();
            BtnColor_Com.BackColor = System.Drawing.Color.Transparent;
            BtnColor_Com.ForeColor = System.Drawing.Color.White;
            BtnColor_Keyword.Disabled();
            BtnColor_Keyword.BackColor = System.Drawing.Color.Transparent;
            BtnColor_Keyword.ForeColor = System.Drawing.Color.White;
            BtnColor_Method.Disabled();
            BtnColor_Method.BackColor = System.Drawing.Color.Transparent;
            BtnColor_Method.ForeColor = System.Drawing.Color.White;
            BtnColor_Normal.Disabled();
            BtnColor_Normal.BackColor = System.Drawing.Color.Transparent;
            BtnColor_Normal.ForeColor = System.Drawing.Color.White;
            BtnColor_Num.Disabled();
            BtnColor_Num.BackColor = System.Drawing.Color.Transparent;
            BtnColor_Num.ForeColor = System.Drawing.Color.White;
            return;
        }
        BtnColor_Com.Enable();
        BtnColor_Keyword.Enable();
        BtnColor_Method.Enable();
        BtnColor_Normal.Enable();
        BtnColor_Num.Enable();
        var stream = new XmlTextReader(path);
        using (var s = new XmlTextReader(path))
        {
            XmlDocument xDoc = new();
            xDoc.Load(s);
            var rootElem = xDoc.DocumentElement;
            var xshd = HighlightingLoader.LoadXshd(stream);
            edit.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            edit.UpdateLayout();
            foreach (XmlNode item in rootElem.ChildNodes)
            {
                if (item.Name != "Color")
                {
                    continue;
                }
                var attrName = item.Attributes["name"]?.Value;
                var attrForeground = item.Attributes["foreground"]?.Value;


                if (attrName == "Keywords")
                {
                    attrForeground.Replace("ff", "");
                    BtnColor_Keyword.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                }
                else if (attrName == "MethodCall")
                {
                    attrForeground.Replace("ff", "");
                    BtnColor_Method.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                }
                else if (attrName == "Comment")
                {
                    attrForeground.Replace("ff", "");
                    BtnColor_Com.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                }
                else if (attrName == "NumberLiteral")
                {
                    attrForeground.Replace("ff", "");
                    BtnColor_Num.BackColor = System.Drawing.ColorTranslator.FromHtml(attrForeground);
                }
            }
        }
    }
}
