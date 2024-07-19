using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE.Init.FirstBoot
{
    internal class FBSInitializer
    {
        internal readonly IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\fbs.relang", Encoding.UTF8);
    }
}
namespace IDE.Init
{
    public partial class FrmFirstBootStep1
    {
        FirstBoot.FBSInitializer _fbsInitializer = new();

        internal void InitializeLocalization()
        {
            this.label1.Text = _fbsInitializer._I18nFile.Localize("text.title.fbs.1.welcomeuse");
            this.uiLabel1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.poem.1");
            this.uiButton1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.next");
        }
    }

    public partial class FrmFirstBootStep2
    {
        FirstBoot.FBSInitializer _fbsInitializer = new();

        internal void InitializeLocalization()
        {
            this.uiLabel1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.poem.2");
            this.uiLabel2.Text = _fbsInitializer._I18nFile.Localize("text.fbs.bs.tip");
            this.uiLine1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.chooseyourmainfont.title");
            this.uiLabel3.Text = Extensions.Combine2WithChar(_fbsInitializer._I18nFile.Localize("text.fbs.chooseyourmainfont.tip.l1"),_fbsInitializer._I18nFile.Localize("text.fbs.chooseyourmainfont.tip.l2"), "\n");
            this.uiLine2.Text = _fbsInitializer._I18nFile.Localize("text.fbs.chooseyoureditorfont.title");
            this.uiLabel4.Text = _fbsInitializer._I18nFile.Localize("text.fbs.chooseyoureditorfont.tip.l1")+"\n"+_fbsInitializer._I18nFile.Localize("text.fbs.chooseyoureditorfont.tip.l2")+"\n"+ _fbsInitializer._I18nFile.Localize("text.fbs.chooseyoureditorfont.tip.l3");
            this.uiButton1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.next");
            this.uiButton2.Text = _fbsInitializer._I18nFile.Localize("text.fbs.pre");
        }
    }

    public partial class FrmFirstBootStep3
    {
        FirstBoot.FBSInitializer _fbsInitializer = new();

        internal void InitializeLocalization()
        {
            this.uiLabel2.Text = _fbsInitializer._I18nFile.Localize("text.fbs.as.tip");
            this.uiLabel1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.poem.3");
            this.uiButton1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.next");
            this.uiButton2.Text = _fbsInitializer._I18nFile.Localize("text.fbs.pre");
        }
    }

    public partial class FrmFirstBootStep4
    {
        FirstBoot.FBSInitializer _fbsInitializer = new();

        internal void InitializeLocalization()
        {
            this.uiLabel3.Text = _fbsInitializer._I18nFile.Localize("text.fbs.xsecclose");
            this.label1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.bingo");
            this.uiLabel4.Text = _fbsInitializer._I18nFile.Localize("text.fbs.sthgoodiscoming");
            this.uiLabel1.Text = _fbsInitializer._I18nFile.Localize("text.fbs.poem.4");;
        }
    }
}