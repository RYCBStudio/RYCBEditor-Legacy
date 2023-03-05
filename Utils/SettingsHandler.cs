using Sunny.UI;

namespace IDE
{
    internal static class SettingsHandler
    {
        private readonly static IniFileEx reConf = Main.reConf;

        public static string[] GetKeysOfSecton(string section)
        {
            return reConf.KeyNames(section);
        }

        public static void SetSettings(string section, string formatter, string keyName)
        {
            reConf.Write(section, keyName, formatter);
        }
    }
}
