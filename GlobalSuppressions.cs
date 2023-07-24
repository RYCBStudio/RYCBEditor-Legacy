// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0044:添加只读修饰符", Justification = "<挂起>", Scope = "member", Target = "~F:IDE.CodeSettings.addY")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:删除未使用的私有成员", Justification = "<挂起>", Scope = "member", Target = "~F:IDE.CodeSettings.addY")]
[assembly: SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>", Scope = "member", Target = "~M:IDE.LightEdit.tabControl1_DragDrop(System.Object,System.Windows.Forms.DragEventArgs)")]
[assembly: SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>", Scope = "member", Target = "~M:IDE.CodeSettings.addNewCS(System.Object,System.EventArgs)")]


namespace IDE;
public static class GlobalSuppressions
{
    /// <summary>
    /// 程序主语言
    /// </summary>
    public static string language = Program.reConf.Read("general", "language", "zh-CN");
    public static Dictionary<string, string> language_set = new()
    {
        { "简体中文(中国)", "zh-CN" },
        { "繁體中文(香港)", "zh-HK" },
        { "English", "en-US" },
        { "日本語", "ja-JP" },
    };

}