using Microsoft.Win32;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.International.Converters.PinYinConverter;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Drawing;
using Sunny.UI;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Windows.Forms;

namespace IDE
{
    public class FileTypeRegistryFactory
    {
        /// <summary>
        /// 文件类型注册信息
        /// </summary>
        public class FileTypeRegInfo
        {
            /// <summary>  
            /// 扩展名  
            /// </summary>  
            public string ExtendName;  //".pycn"  
            /// <summary>  
            /// 说明  
            /// </summary>  
            public string Description; //"The Py-CN Project项目文件"  
            /// <summary>  
            /// 关联的图标  
            /// </summary>  
            public string IconPath;
            /// <summary>  
            /// 应用程序  
            /// </summary>  
            public string ExePath;

            public FileTypeRegInfo()
            {
            }
            public FileTypeRegInfo(string extendName)
            {
                this.ExtendName = extendName;
            }
        }

        /// <summary>  
        /// 注册自定义的文件类型。  
        /// </summary>  
        public class FileTypeRegister
        {
            /// <summary>  
            /// 使文件类型与对应的图标及应用程序关联起来
            /// </summary>          
            public static void RegisterFileType(FileTypeRegInfo regInfo)
            {
                if (FileTypeRegistered(regInfo.ExtendName))
                {
                    return;
                }

                //HKEY_CLASSES_ROOT/.pycn
                var fileTypeKey = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
                var relationName = regInfo.ExtendName.Substring(1,
                                                                   regInfo.ExtendName.Length - 1).ToUpper() + "_FileType";
                fileTypeKey.SetValue("", relationName);
                fileTypeKey.Close();

                //HKEY_CLASSES_ROOT/PYCN_FileType
                var relationKey = Registry.ClassesRoot.CreateSubKey(relationName);
                relationKey.SetValue("", regInfo.Description);

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/DefaultIcon
                var iconKey = relationKey.CreateSubKey("DefaultIcon");
                iconKey.SetValue("", regInfo.IconPath);

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell
                var shellKey = relationKey.CreateSubKey("Shell");

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/Open
                var openKey = shellKey.CreateSubKey("Open");

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/Open/Command
                var commandKey = openKey.CreateSubKey("Command");
                commandKey.SetValue("", regInfo.ExePath + " %1"); // " %1"表示将被双击的文件的路径传给目标应用程序
                relationKey.Close();
            }

            /// <summary>  
            /// 更新指定文件类型关联信息  
            /// </summary>      
            public static bool UpdateFileTypeRegInfo(FileTypeRegInfo regInfo)
            {
                if (!FileTypeRegistered(regInfo.ExtendName))
                {
                    return false;
                }

                var extendName = regInfo.ExtendName;
                var relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
                var relationKey = Registry.ClassesRoot.OpenSubKey(relationName, true);
                relationKey.SetValue("", regInfo.Description);
                var iconKey = relationKey.OpenSubKey("DefaultIcon", true);
                iconKey.SetValue("", regInfo.IconPath);
                var shellKey = relationKey.OpenSubKey("Shell");
                var openKey = shellKey.OpenSubKey("Open");
                var commandKey = openKey.OpenSubKey("Command", true);
                commandKey.SetValue("", regInfo.ExePath + " %1");
                relationKey.Close();
                return true;
            }

            /// <summary>  
            /// 获取指定文件类型关联信息  
            /// </summary>          
            public static FileTypeRegInfo GetFileTypeRegInfo(string extendName)
            {
                if (!FileTypeRegistered(extendName))
                {
                    return null;
                }
                FileTypeRegInfo regInfo = new(extendName);

                var relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
                var relationKey = Registry.ClassesRoot.OpenSubKey(relationName);
                regInfo.Description = relationKey.GetValue("").ToString();
                var iconKey = relationKey.OpenSubKey("DefaultIcon");
                regInfo.IconPath = iconKey.GetValue("").ToString();
                var shellKey = relationKey.OpenSubKey("Shell");
                var openKey = shellKey.OpenSubKey("Open");
                var commandKey = openKey.OpenSubKey("Command");
                var temp = commandKey.GetValue("").ToString();
                regInfo.ExePath = temp.Substring(0, temp.Length - 3);
                return regInfo;
            }

            /// <summary>  
            /// 指定文件类型是否已经注册  
            /// </summary>          
            public static bool FileTypeRegistered(string extendName)
            {
                var softwareKey = Registry.ClassesRoot.OpenSubKey(extendName);
                if (softwareKey != null)
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class LangKeywords
    {
        public static class Keywords
        {
            public static readonly string[] pycn = { "and", "as", "assert", "async", "await", "break", "捕获", "捕获", "遍历", "不是", "不", "continue", "class", "尝试运行", "尝试", "抽象资源处理逻辑", "抽象处理逻辑", "抽象", "当", "定义", "定义方法", "定义函数", "打断循环", "等候", "等待", "断言", "当作", "def", "del", "elif", "else", "except", "finally", "for", "from", "否则", "否则如果", "非本地变量", "非本地化变量", "global", "或", "或者", "if", "import", "in", "is", "假", "快速", "空", "lambda", "->", "匿名函数", "nonlocal", "not", "or", "抛出", "pass", "raise", "return", "如果", "若捕获", "删除", "使变量全局", "使变量全局化", "try", "通过", "跳过并继续", "while", "with", "yield", "异步", "异步操作", "抑或", "占位语句", "占位符", "作为", "真" };
            public static readonly string[] python = { "False", "None", "True", "and", "as", "assert", "async", "await", "break", "class", "continue", "def", "del", "elif", "else", "except", "finally", "for", "from", "global", "if", "import", "in", "is", "lambda", "nonlocal", "not", "or", "pass", "raise", "return", "try", "while", "with", "yield" };
            public static readonly string[] cs = { "add", "and", "alias", "ascending", "args", "async", "await", "by", "descending", "dynamic", "equals", "from", "get", "global", "group", "init", "into", "join", "let", "nameof", "nint", "not", "notnull", "nuint", "on", "or", "orderby", "partial", "record", "remove", "select", "set", "unmanaged", "value", "var", "when", "where", "with", "yield", "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
        }

        public static class SpecialDefs
        {
            public static readonly string[] pycn = { "__dir__", "__getattr__", "__abs__", "__del__", "__hex__", "__int__", "__len__", "__add__", "__aenter__", "__aexit__", "__aiter__", "__await__", "__bool__", "__bytes__", "__call__", "__ceil__", "__class_getitem__", "__cmp__", "__coerce__", "__complex__", "__contains__", "__copy__", "__deepcopy__" };
            public static readonly string[] python = pycn;
            public static readonly string[] cs = { "#define", "#undef", "#if", "#else", "#elif", "#endif", "#line", "#error", "#warning", "#region", "#endregion" };
        }

        public static class BulitIns
        {
            public static readonly string[] py = { "abs", "aiter", "all", "anext", "any", "ascii", "bin", "bool", "breakpoint", "bytearray", "bytes", "callable", "chr", "classmethod", "compile", "complex", "delattr", "dict", "dir", "divmod", "enumerate", "eval", "exec", "filter", "float", "format", "frozenset", "getattr", "globals", "hasattr", "hash", "help", "hex", "id", "input", "int", "isinstance", "issubclass", "iter", "len", "list", "locals", "map", "max", "memoryview", "min", "next", "object", "oct", "open", "ord", "pow", "print", "property", "range", "repr", "reversed", "round", "set", "setattr", "slice", "sorted", "staticmethod", "str", "sum", "super", "tuple", "type", "vars", "zip", "__import__" };
            public static readonly string[] pycn = { "abs", "aiter", "all", "anext", "any", "ascii", "bin", "bool", "breakpoint", "bytearray", "bytes", "callable", "chr", "compile", "complex", "delattr", "dict", "dir", "divmod", "enumerate", "eval", "exec", "filter", "float", "format", "frozenset", "getattr", "globals", "hasattr", "hash", "help", "hex", "id", "input", "int", "isinstance", "issubclass", "iter", "len", "list", "locals", "map", "max", "memoryview", "min", "next", "object", "oct", "open", "ord", "pow", "print", "property", "range", "repr", "reversed", "round", "set", "setattr", "slice", "sorted", "str", "sum", "super", "tuple", "type", "vars", "zip", "__import__", "取绝对值", "异步_迭代器", "全为真", "异步_下一个元素", "有真", "ASCII字符", "二进制", "布尔值", "断点", "字节数组", "不可变字节数组", "是否可调用", "解码", "编译", "复数", "删除属性", "字典", "获取名称列表", "整除和取余", "获取枚举对象", "还原", "动态执行", "从函数新建迭代器", "浮点数", "格式化字符串", "冻结集合", "获取属性", "获取命名空间", "是否有属性", "哈希值", "帮助", "十六进制", "标识值", "获取输入", "整数", "是否是实例", "是否是子类", "迭代器", "获取长度", "列表", "获取本地符号表", "映射", "最大值", "获取内存视图", "最小值", "下一个元素", "基类", "八进制", "打开文件", "编码", "幂", "打印", "属性值", "生成序列", "转换为解释器可读", "逆转", "四舍五入", "集合", "设置属性", "切片", "排序", "字符串", "求和", "超类", "元组", "类型", "获取字典属性", "并行迭代", "__导入__" };
        }
    }

    public static class ChinsesePinYinHelper
    {
        ///<summary>
        /// 汉字
        /// </summary>
        private static string ChineseReg = "^[\\u4E00-\\u9FA5]+$";

        public static string GetPinYinFull(string str)
        {
            var pySb = new StringBuilder();
            foreach (var itemChar in str)
            {
                //过滤非汉字的字符，直接返回
                var reg = new Regex(ChineseReg);
                if (!reg.IsMatch(itemChar.ToString()))
                {
                    pySb.Append(itemChar);
                }
                else
                {
                    var chineseChar = new ChineseChar(itemChar);
                    var pyStr = chineseChar.Pinyins.First().ToLower();
                    pySb.Append(pyStr.Substring(0, pyStr.Length - 1));
                }
            }
            return pySb.ToString();
        }
    }

    public static class GlobalSettings
    {
        /// <summary>
        /// 程序主语言
        /// </summary>
        public static string language = Program.reConf.ReadString("General", "Language", "zh-CN");

        public static int CrashAttempts = Program.reConf.ReadInt("CrashHanding", "CrashAttempts", 3);

        internal static Tuple<string, Color, Color> theme = Themes.GetTheme(Program.reConf.ReadString("General", "Theme", "Dark"));

        internal static List<string> keywords;

        public static Dictionary<string, string> language_set = new()
        {
            { "简体中文", "zh-CN" },
            { "繁體中文", "zh-TD" },
            { "English", "en-US" },
            { "日本語", "ja-JP" },
        };

        public static Dictionary<string, Dictionary<string, string>> theme_set = new()
        {
            { "zh-CN", new(){{ "浅色", "Light" }, { "深色", "Dark" }, { "IDEA", "IDEA_Dark" }, { "自定义", "Custom" } } },
            { "zh-TD", new(){{ "淺色", "Light" }, { "深色", "Dark" }, { "IDEA", "IDEA_Dark" }, { "自定義", "Custom" } } },
            { "en-US", new(){{ "Light", "Light" }, { "Dark", "Dark" }, { "IDEA", "IDEA_Dark" }, { "Custom", "Custom" } } },
            { "ja-JP", new(){{ "ライト", "Light" }, { "ダーク", "Dark" }, { "IDEA", "IDEA_Dark" }, { "カスタム", "Custom" } } },
        };

        public static Dictionary<string, List<System.Windows.Media.Color>> editor_color_set = new()
        {
            { "Dark", new(){System.Windows.Media.Color.FromRgb(0xA9, 0xB7, 0xC6), System.Windows.Media.Color.FromRgb(0x1E, 0x1F, 0x22) } },
            { "Light",  new(){System.Windows.Media.Color.FromRgb(8, 8, 8), System.Windows.Media.Color.FromRgb(255, 255, 255) }},
        };
    }

    internal class Themes
    {
        /// <summary>
        /// Themes.Dark
        /// </summary>
        internal static Tuple<string, Color, Color> Dark =
            new("Dark", Color.WhiteSmoke, Color.Black);
        /// <summary>
        /// Themes.Light
        /// </summary>
        internal static Tuple<string, Color, Color> Light =
            new("Light", SystemColors.ControlText, SystemColors.Control);
        /// <summary>
        /// Themes.IDEA
        /// </summary>
        internal static Tuple<string, Color, Color> IDEA_Dark =
            new("IDEA_Dark", ColorTranslator.FromHtml("#DFE1E5"), ColorTranslator.FromHtml("#2B2D30"));
        /// <summary>
        /// Themes.Custom
        /// </summary>
        internal static Tuple<string, Color, Color> Custom =
            new("Custom", ColorTranslator.FromHtml(Program.reConf.ReadString("Theme", "Custom.ForeGround", "#FFF5F5F5")),
            ColorTranslator.FromHtml(Program.reConf.ReadString("Theme", "Custom.BackGround", "#FF000000")));

        internal static Tuple<string, Color, Color> GetTheme(string themeText)
        {
            return themeText switch
            {
                "Dark" => Dark,
                "Light" => Light,
                "IDEA" or "idea" or "IDEA_Dark" => IDEA_Dark,
                _ => Custom,
            };
        }
    }

    public class PythonVariableAnalyzer
    {
        public static Dictionary<string, List<string>> AnalyzeVariables(string pythonFilePath)
        {
            var engine = Python.CreateEngine();
            var paths = engine.GetSearchPaths();
            paths.Add(Environment.GetEnvironmentVariable("PATH").Split(';').FindIfContains("python").FindIfNotContains("Scripts")+"\\Libs");
            engine.SetSearchPaths(paths);
            dynamic script = engine.CreateScriptSourceFromFile(Path.Combine(pythonFilePath), Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File).Execute();
            dynamic scope = engine.GetSysModule().GetVariable("modules")["<module>"].__dict__;

            var variables = new Dictionary<string, List<string>>
            {
                { "Global", new List<string>() },
                { "Private", new List<string>() },
                { "Func", new List<string>() },
                { "FuncName", new List<string>() }
            };

            AnalyzeGlobalVariables(scope, variables["Global"]);
            AnalyzeFunctions(script, variables["FuncName"], variables["Func"]);

            return variables;
        }

        private static void AnalyzeGlobalVariables(dynamic scope, List<string> globalVariables)
        {
            try
            {
                foreach (string variableName in scope)
                {
                    dynamic variableValue = scope[variableName];

                    if (!IsSystemVariable(variableName) && !IsFunction(variableValue))
                    {
                        globalVariables.Add(variableName);
                    }
                }
            }
            catch (Exception ex)
            {
                Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.FATAL, EnumPort.CLIENT);
            }
        }

        private static void AnalyzeFunctions(dynamic script, List<string> functionNames, List<string> functionParameters)
        {
            try
            {
                foreach (var member in script.GetMembers())
                {
                    if (member.MemberType.ToString() == "Method")
                    {
                        functionNames.Add(member.Name);
                        functionParameters.AddRange(member.GetVariableNames());
                    }
                }
            }
            catch (Exception ex)
            {
                Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.FATAL, EnumPort.CLIENT);
            }
        }

        private static bool IsSystemVariable(string variableName)
        {
            string[] systemVariables = { "__name__", "__file__", "__doc__", "__package__", "__spec__", "__builtins__" };
            return Array.IndexOf(systemVariables, variableName) >= 0;
        }

        private static bool IsFunction(dynamic variableValue)
        {
            return variableValue is Delegate;
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// 指示指定的Unicode字符是香属于字母或十进制数字类别。
        /// </summary>
        /// <param name="c">要计算的Unicode字符。</param>
        /// <returns>如果<paramref name="c"/>是字母或十进制数，则为true; 否则为false。</returns>
        public static bool IsLetterOrDigit(this char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
        }

        /// <summary>
        /// 检查指定字符串所对应的字体是否存在。
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <returns>如果计算机中存在<paramref name="fontName"/>，则为true；否则为false。</returns>
        public static bool FontExists(this string fontName)
        {
            using var font = new Font(fontName, 12);
            return string.Equals(font.Name, fontName, System.StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// 读取I18n文件中的本地化值
        /// </summary>
        /// <param name="iniFile">I18n文件类</param>
        /// <param name="translationKey">翻译的键</param>
        /// <returns>本地化结果</returns>
        public static string Localize(this IniFile iniFile, string translationKey)
        {
            return iniFile.ReadString("I18n", translationKey, translationKey);
        }

        /// <summary>
        /// 将路径中的空格替换为程序可读的形式。
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>不含可见空格的路径。</returns>
        public static string ReplaceSpacesInPath(this string path)
        {
            return path.Replace(" ", "%20");
        }

        /// <summary>
        /// <code>获取string.split('\n')的值。</code>
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns><code>string.split('\n')的值。</code></returns>
        public static string[] GetLines(this string str)
        {
            return str.Split('\n');
        }

        /// <summary>
        /// 启用控件
        /// </summary>
        /// <param name="ctrl">控件名</param>
        public static void Enable(this Control ctrl)
        {
            ctrl.Enabled = true;
        }

        public static string FindIfContains(this string[] array, string findstr)
        {
            foreach (var item in array)
            {
                if (item.Contains(findstr))
                {
                    return item;
                }
            }
            return string.Empty;
        }

        public static string FindIfNotContains(this string str, string findstr)
        {
            if (!str.Contains(findstr))
            {
                return str;
            }
            return string.Empty;
        }
    }

    public class Dictionaries
    {
        public static class Exceptions
        {
            public static readonly Dictionary<string, string> cs = new()
            {
                {"System.OutOfMemoryException", "内存溢出"},
                {"System.NullReferenceException", "空引用"},
                {"System.IndexOutOfRangeException", "索引超出范围"},
                {"System.DivideByZeroException", "除以零"},
                {"System.InvalidCastException", "无效的类型转换"},
                {"System.FormatException", "格式化"},
                {"System.ArithmeticException", "算术"},
                {"System.NotSupportedException", "不支持的操作"},
                {"System.OverflowException", "溢出"},
                {"System.IO.IOException", "输入/输出"},
                {"System.FileNotFoundException", "文件未找到"},
                {"System.ArgumentNullException", "参数为空"},
                {"System.ArgumentException", "无效的参数"},
                {"System.TimeoutException", "超时"},
                {"System.ObjectDisposedException", "已释放对象"},
                {"System.Security.SecurityException", "安全性"},
                {"System.Reflection.TargetInvocationException", "目标调用"},
                {"System.PlatformNotSupportedException", "不支持的平台"}
            };
            public static readonly Dictionary<string, string> python = new()
            {
                {"Exception", "异常"},
                {"TypeError", "不正确类型"},
                {"ValueError", "传递给方法的参数具有正确的类型，但值不合适"},
                {"NameError", "尝试访问不存在的变量/名称"},
                {"SyntaxError", "语法错误"},
                {"IndentationError", "缩进错误"},
                {"AttributeError", "尝试访问对象不存在的属性或方法"},
                {"KeyError", "尝试访问字典中不存在的键"},
                {"IndexError", "索引超出序列范围"},
                {"FileNotFoundError", "文件未找到"},
                {"IOException", "输入/输出操作失败"},
                {"DivideByZeroException", "除数为零"},
                {"OverflowException", "数值运算结果太大而无法表示"},
                {"RuntimeException", "运行时错误"},
                {"ImportException", "导入模块失败"},
                {"ModuleNotFoundException", "模块未找到"},
                {"KeyboardInterrupt", "用户中断执行程序s"}
            };
        }
    }
}