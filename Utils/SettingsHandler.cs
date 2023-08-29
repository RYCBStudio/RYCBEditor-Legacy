using Sunny.UI;

namespace IDE
{
    internal static class SettingsHandler
    {
        private readonly static IniFile reConf = Program.reConf;

        public static string[] GetKeysOfSecton(string section)
        {
            return reConf.GetKeys(section);
        }

        public static void SetSettings(string section, string formatter, string keyName)
        {
            reConf.Write(section, keyName, formatter);
        }
    }
}
