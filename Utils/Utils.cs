using Microsoft.Win32;

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
                RegistryKey fileTypeKey = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
                string relationName = regInfo.ExtendName.Substring(1,
                                                                   regInfo.ExtendName.Length - 1).ToUpper() + "_FileType";
                fileTypeKey.SetValue("", relationName);
                fileTypeKey.Close();

                //HKEY_CLASSES_ROOT/PYCN_FileType
                RegistryKey relationKey = Registry.ClassesRoot.CreateSubKey(relationName);
                relationKey.SetValue("", regInfo.Description);

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/DefaultIcon
                RegistryKey iconKey = relationKey.CreateSubKey("DefaultIcon");
                iconKey.SetValue("", regInfo.IconPath);

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell
                RegistryKey shellKey = relationKey.CreateSubKey("Shell");

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/Open
                RegistryKey openKey = shellKey.CreateSubKey("Open");

                //HKEY_CLASSES_ROOT/PYCN_FileType/Shell/Open/Command
                RegistryKey commandKey = openKey.CreateSubKey("Command");
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

                string extendName = regInfo.ExtendName;
                string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
                RegistryKey relationKey = Registry.ClassesRoot.OpenSubKey(relationName, true);
                relationKey.SetValue("", regInfo.Description);
                RegistryKey iconKey = relationKey.OpenSubKey("DefaultIcon", true);
                iconKey.SetValue("", regInfo.IconPath);
                RegistryKey shellKey = relationKey.OpenSubKey("Shell");
                RegistryKey openKey = shellKey.OpenSubKey("Open");
                RegistryKey commandKey = openKey.OpenSubKey("Command", true);
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
                FileTypeRegInfo regInfo = new FileTypeRegInfo(extendName);

                string relationName = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
                RegistryKey relationKey = Registry.ClassesRoot.OpenSubKey(relationName);
                regInfo.Description = relationKey.GetValue("").ToString();
                RegistryKey iconKey = relationKey.OpenSubKey("DefaultIcon");
                regInfo.IconPath = iconKey.GetValue("").ToString();
                RegistryKey shellKey = relationKey.OpenSubKey("Shell");
                RegistryKey openKey = shellKey.OpenSubKey("Open");
                RegistryKey commandKey = openKey.OpenSubKey("Command");
                string temp = commandKey.GetValue("").ToString();
                regInfo.ExePath = temp.Substring(0, temp.Length - 3);
                return regInfo;
            }

            /// <summary>  
            /// 指定文件类型是否已经注册  
            /// </summary>          
            public static bool FileTypeRegistered(string extendName)
            {
                RegistryKey softwareKey = Registry.ClassesRoot.OpenSubKey(extendName);
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
            public static readonly string[] pycn = new string[] { "and", "as", "assert", "async", "await", "break", "捕获", "捕获异常", "遍历", "不是", "不", "continue", "class", "尝试运行", "尝试", "抽象资源处理逻辑", "抽象处理逻辑", "抽象", "当", "定义", "定义方法", "定义函数", "打断循环", "等候", "等待", "断言", "当作", "def", "del", "elif", "else", "except", "finally", "for", "from", "否则", "否则如果", "非本地变量", "非本地化变量", "global", "或", "或者", "if", "import", "in", "is", "假", "快速", "空", "lambda", "->", "匿名函数", "nonlocal", "not", "or", "抛出", "pass", "raise", "return", "如果", "若捕获异常", "删除", "使变量全局", "使变量全局化", "try", "通过", "跳过并继续", "while", "with", "yield", "异步", "异步操作", "抑或", "占位语句", "占位符", "作为", "真" };
            public static readonly string[] python = new string[] { "False", "None", "True", "and", "as", "assert", "async", "await", "break", "class", "continue", "def", "del", "elif", "else", "except", "finally", "for", "from", "global", "if", "import", "in", "is", "lambda", "nonlocal", "not", "or", "pass", "raise", "return", "try", "while", "with", "yield" };
            public static readonly string[] cs = new string[] { "add", "and", "alias", "ascending", "args", "async", "await", "by", "descending", "dynamic", "equals", "from", "get", "global", "group", "init", "into", "join", "let", "nameof", "nint", "not", "notnull", "nuint", "on", "or", "orderby", "partial", "record", "remove", "select", "set", "unmanaged", "value", "var", "when", "where", "with", "yield", "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
        }

        public static class SpecialDefs
        {
            public static readonly string[] pycn = new string[] { "__dir__", "__getattr__", "__abs__", "__del__", "__hex__", "__int__", "__len__", "__add__", "__aenter__", "__aexit__", "__aiter__", "__await__", "__bool__", "__bytes__", "__call__", "__ceil__", "__class_getitem__", "__cmp__", "__coerce__", "__complex__", "__contains__", "__copy__", "__deepcopy__" };
            public static readonly string[] python = pycn;
            public static readonly string[] cs = new string[] { "#define", "#undef", "#if", "#else", "#elif", "#endif", "#line", "#error", "#warning", "#region", "#endregion" };
        }
    }
}