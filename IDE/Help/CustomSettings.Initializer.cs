using Sunny.UI;
using System.Windows.Forms;

namespace IDE;
public partial class CustomSettings
{
    private void InitializeTranslation()
    {
        IniFileEx _I18nFile = new(Application.StartupPath + $"\\Languages\\{GlobalSettings.language}\\Settings.relang");
        
    }
}
