using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class LicenseAndCopyrights
{
    private void InitializeTranslation()
    {
        IniFile _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSuppressions.language}\\LAC.relang", System.Text.Encoding.UTF8);
        this.Text = _I18nFile.ReadString("I18n", this.Text, this.Text);
        label1.Text = _I18nFile.ReadString("I18n", label1.Text, label1.Text);
        label2.Text = _I18nFile.ReadString("I18n", label2.Text, label2.Text);
        label3.Text = _I18nFile.ReadString("I18n", label3.Text, label3.Text);
        label4.Text = _I18nFile.ReadString("I18n", label4.Text, label4.Text);
        groupBox1.Text = _I18nFile.ReadString("I18n", groupBox1.Text, groupBox1.Text);
        groupBox2.Text = _I18nFile.ReadString("I18n", groupBox2.Text, groupBox2.Text);
        groupBox3.Text = _I18nFile.ReadString("I18n", groupBox3.Text, groupBox3.Text);
        groupBox4.Text = _I18nFile.ReadString("I18n", groupBox4.Text, groupBox4.Text);
        metroLabel1.Text = _I18nFile.ReadString("I18n", metroLabel1.Text, metroLabel1.Text);
        metroLabel2.Text = _I18nFile.ReadString("I18n", metroLabel2.Text, metroLabel2.Text);
        metroLabel3.Text = _I18nFile.ReadString("I18n", metroLabel3.Text, metroLabel3.Text);
        metroLabel4.Text = _I18nFile.ReadString("I18n", metroLabel4.Text, metroLabel4.Text);
        linkLabel2.Text = _I18nFile.ReadString("I18n", "text.LAC.gb1.website", linkLabel2.Text);
        linkLabel3.Text = _I18nFile.ReadString("I18n", linkLabel3.Text, linkLabel3.Text);
        linkLabel5.Text = _I18nFile.ReadString("I18n", linkLabel5.Text, linkLabel5.Text);
        linkLabel7.Text = _I18nFile.ReadString("I18n", linkLabel7.Text, linkLabel7.Text);
    }
}
