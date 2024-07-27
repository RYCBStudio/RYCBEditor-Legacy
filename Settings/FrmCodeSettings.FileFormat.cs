using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace IDE;
public partial class FrmCustomSettings
{
    private readonly RYCBIniProcessor iniProcessor = new(Program.STARTUP_PATH + "\\Tools\\.pylintrc");
    private static readonly IniFile iniFile = new(Program.STARTUP_PATH + "\\Tools\\.pylintrc");

    private readonly List<string> sections = [.. iniFile.Sections];

    private readonly Dictionary<string, string> ChineseTranslations = new()
    {
        { "analyse-fallback-blocks", "分析后备块" },
        { "clear-cache-post-run", "运行后清除缓存" },
        { "enable-all-extensions", "启用所有扩展" },
        { "errors-only", "仅错误" },
        { "exit-zero", "退出需返回零" },
        { "extension-pkg-allow-list", "扩展包允许列表" },
        { "extension-pkg-whitelist", "扩展包白名单" },
        { "fail-on", "失败时" },
        { "fail-under", "失败阈值" },
        { "from-stdin", "来自标准输入" },
        { "ignore", "忽略" },
        { "ignore-paths", "忽略路径" },
        { "ignore-patterns", "忽略模式" },
        { "ignored-modules", "忽略的模块" },
        { "init-hook", "初始化钩子" },
        { "jobs", "任务数" },
        { "limit-inference-results", "推理结果限制" },
        { "load-plugins", "加载插件" },
        { "persistent", "持久化" },
        { "prefer-stubs", "优先使用存根" },
        { "py-version", "Python版本" },
        { "recursive", "递归" },
        { "source-roots", "源根" },
        { "suggestion-mode", "建议模式" },
        { "unsafe-load-any-extension", "不安全加载任何扩展" },
        { "verbose", "详细" },
        { "argument-naming-style", "参数命名风格" },
        { "argument-rgx", "参数正则表达式" },
        { "attr-naming-style", "属性命名风格" },
        { "attr-rgx", "属性正则表达式" },
        { "bad-names", "不良命名" },
        { "bad-names-rgxs", "不良命名正则表达式" },
        { "class-attribute-naming-style", "类属性命名风格" },
        { "class-attribute-rgx", "类属性正则表达式" },
        { "class-const-naming-style", "类常量命名风格" },
        { "class-const-rgx", "类常量正则表达式" },
        { "class-naming-style", "类命名风格" },
        { "class-rgx", "类正则表达式" },
        { "const-naming-style", "常量命名风格" },
        { "const-rgx", "常量正则表达式" },
        { "docstring-min-length", "文档字符串最小长度" },
        { "function-naming-style", "函数命名风格" },
        { "function-rgx", "函数正则表达式" },
        { "good-names", "良好命名" },
        { "good-names-rgxs", "良好命名正则表达式" },
        { "include-naming-hint", "包含命名提示" },
        { "inlinevar-naming-style", "内联变量命名风格" },
        { "inlinevar-rgx", "内联变量正则表达式" },
        { "method-naming-style", "方法命名风格" },
        { "method-rgx", "方法正则表达式" },
        { "module-naming-style", "模块命名风格" },
        { "module-rgx", "模块正则表达式" },
        { "name-group", "名称组" },
        { "no-docstring-rgx", "无文档字符串正则表达式" },
        { "property-classes", "属性类" },
        { "typealias-rgx", "类型别名正则表达式" },
        { "typevar-rgx", "类型变量正则表达式" },
        { "variable-naming-style", "变量命名风格" },
        { "variable-rgx", "变量正则表达式" },
        { "check-protected-access-in-special-methods", "检查特殊方法中的受保护访问" },
        { "defining-attr-methods", "定义属性方法" },
        { "exclude-protected", "排除受保护" },
        { "valid-classmethod-first-arg", "有效的classmethod第一个参数" },
        { "valid-metaclass-classmethod-first-arg", "有效的元类classmethod第一个参数" },
        { "exclude-too-few-public-methods", "排除太少的公共方法" },
        { "ignored-parents", "忽略的父类" },
        { "max-args", "最大参数数" },
        { "max-attributes", "最大属性数" },
        { "max-bool-expr", "最大布尔表达式" },
        { "max-branches", "最大分支数" },
        { "max-locals", "最大局部变量数" },
        { "max-parents", "最大父类数" },
        { "max-public-methods", "最大公共方法数" },
        { "max-returns", "最大返回数" },
        { "max-statements", "最大语句数" },
        { "min-public-methods", "最小公共方法数" },
        { "overgeneral-exceptions", "过度一般化的异常" },
        { "expected-line-ending-format", "预期的行结束格式" },
        { "ignore-long-lines", "忽略的长行(正则表达式)" },
        { "indent-after-paren", "括号后缩进" },
        { "indent-string", "缩进字符串" },
        { "max-line-length", "最大行长度" },
        { "max-module-lines", "最大模块行数" },
        { "single-line-class-stmt", "单行类语句" },
        { "single-line-if-stmt", "单行if语句" },
        { "allow-any-import-level", "允许任何导入级别" },
        { "allow-reexport-from-package", "允许从包重新导出" },
        { "allow-wildcard-with-all", "允许通配符与所有" },
        { "deprecated-modules", "已弃用的模块" },
        { "ext-import-graph", "外部导入图" },
        { "import-graph", "导入图" },
        { "int-import-graph", "内部导入图" },
        { "known-standard-library", "已知标准库" },
        { "known-third-party", "已知第三方库" },
        { "preferred-modules", "首选模块" },
        { "logging-format-style", "日志格式样式" },
        { "logging-modules", "日志模块" },
        { "confidence", "检查等级" },
        { "disable", "禁用的id" },
        { "enable", "启用的id" },
        { "timeout-methods", "超时方法" },
        { "notes", "需要注意的" },
        { "notes-rgx", "需要注意的(正则表达式)" },
        { "REFACTORING", "重构" },
        { "max-nested-blocks", "最大嵌套块数" },
        { "never-returning-functions", "永不返回的函数" },
        { "suggest-join-with-non-empty-separator", "建议使用非空分隔符连接" },
        { "evaluation", "评估" },
        { "msg-template", "消息模板" },
        { "output-format", "输出格式" },
        { "reports", "报告" },
        { "score", "分数" },
        { "ignore-comments", "忽略注释" },
        { "ignore-docstrings", "忽略文档字符串" },
        { "ignore-imports", "忽略导入" },
        { "ignore-signatures", "忽略签名" },
        { "min-similarity-lines", "最小相似行数" },
        { "max-spelling-suggestions", "最大拼写建议数" },
        { "spelling-dict", "拼写字典" },
        { "spelling-ignore-comment-directives", "忽略拼写注释指令" },
        { "spelling-ignore-words", "拼写忽略单词" },
        { "spelling-private-dict-file", "拼写私有字典文件" },
        { "spelling-store-unknown-words", "存储未知单词" },
        { "check-quote-consistency", "检查引号一致性" },
        { "check-str-concat-over-line-jumps", "检查跨行连接" },
        { "contextmanager-decorators", "上下文管理器装饰器" },
        { "generated-members", "生成的成员" },
        { "ignore-none", "忽略None" },
        { "ignore-on-opaque-inference", "忽略不透明推理" },
        { "ignored-checks-for-mixins", "忽略Mixins检查" },
        { "ignored-classes", "已忽略的类" },
        { "missing-member-hint", "缺失成员提示" },
        { "missing-member-hint-distance", "缺失成员提示距离" },
        { "missing-member-max-choices", "缺失成员最大选择数" },
        { "mixin-class-rgx", "Mixin类正则表达式" },
        { "signature-mutators", "签名变更器" },
        { "additional-builtins", "额外的内置函数" },
        { "allow-global-unused-variables", "允许未使用的全局变量" },
        { "allowed-redefined-builtins", "允许重新定义的内置函数" },
        { "callbacks", "回调函数名(需包含该值)" },
        { "dummy-variables-rgx", "虚拟变量正则表达式" },
        { "ignored-argument-names", "已忽略的参数名" },
        { "init-import", "检查__init__文件中不必要的import" },
        { "redefining-builtins-modules", "可重写的预置模块" }
    };

    private readonly Dictionary<string, Type> ValueTypes = new(){
        {"analyse-fallback-blocks", typeof(string) },
        {"clear-cache-post-run", typeof(string) },
        {"extension-pkg-allow-list", typeof(object) },
        {"extension-pkg-whitelist", typeof(object) },
        {"fail-on", typeof(object) },
        {"fail-under", typeof(int) },
        {"ignore", typeof(string) },
        {"ignore-paths", typeof(object) },
        {"ignore-patterns", typeof(object) },
        {"ignored-modules", typeof(object) },
        {"jobs", typeof(int) },
        {"limit-inference-results", typeof(int) },
        {"load-plugins", typeof(object) },
        {"persistent", typeof(string) },
        {"prefer-stubs", typeof(string) },
        {"py-version", typeof(float) },
        {"recursive", typeof(string) },
        {"source-roots", typeof(object) },
        {"suggestion-mode", typeof(string) },
        {"unsafe-load-any-extension", typeof(string) },
        {"argument-naming-style", typeof(object) },
        {"attr-naming-style", typeof(object) },
        {"bad-names", typeof(object) },
        {"bad-names-rgxs", typeof(object) },
        {"class-attribute-naming-style", typeof(string) },
        {"class-const-naming-style", typeof(object) },
        {"class-naming-style", typeof(string) },
        {"const-naming-style", typeof(object) },
        {"docstring-min-length", typeof(int) },
        {"function-naming-style", typeof(object) },
        {"good-names", typeof(object) },
        {"good-names-rgxs", typeof(object) },
        {"include-naming-hint", typeof(string) },
        {"inlinevar-naming-style", typeof(string) },
        {"method-naming-style", typeof(object) },
        {"module-naming-style", typeof(object) },
        {"name-group", typeof(object) },
        {"no-docstring-rgx", typeof(object) },
        {"property-classes", typeof(object) },
        {"variable-naming-style", typeof(object) },
        {"check-protected-access-in-special-methods", typeof(string) },
        {"defining-attr-methods", typeof(object) },
        {"exclude-protected", typeof(object) },
        {"valid-classmethod-first-arg", typeof(string) },
        {"valid-metaclass-classmethod-first-arg", typeof(string) },
        {"exclude-too-few-public-methods", typeof(object) },
        {"ignored-parents", typeof(object) },
        {"max-args", typeof(int) },
        {"max-attributes", typeof(int) },
        {"max-bool-expr", typeof(int) },
        {"max-branches", typeof(int) },
        {"max-locals", typeof(int) },
        {"max-parents", typeof(int) },
        {"max-public-methods", typeof(int) },
        {"max-returns", typeof(int) },
        {"max-statements", typeof(int) },
        {"min-public-methods", typeof(int) },
        {"overgeneral-exceptions", typeof(object) },
        {"expected-line-ending-format", typeof(string) },
        {"ignore-long-lines", typeof(object) },
        {"indent-after-paren", typeof(int) },
        {"indent-string", typeof(object) },
        {"max-line-length", typeof(int) },
        {"max-module-lines", typeof(int) },
        {"single-line-class-stmt", typeof(string) },
        {"single-line-if-stmt", typeof(string) },
        {"allow-any-import-level", typeof(object) },
        {"allow-reexport-from-package", typeof(string) },
        {"allow-wildcard-with-all", typeof(string) },
        {"deprecated-modules", typeof(object) },
        {"ext-import-graph", typeof(object) },
        {"import-graph", typeof(object) },
        {"int-import-graph", typeof(object) },
        {"known-standard-library", typeof(object) },
        {"known-third-party", typeof(string) },
        {"preferred-modules", typeof(object) },
        {"logging-format-style", typeof(string) },
        {"logging-modules", typeof(string) },
        {"confidence", typeof(object) },
        {"disable", typeof(object) },
        {"enable", typeof(object) },
        {"timeout-methods", typeof(object) },
        {"notes", typeof(object) },
        {"notes-rgx", typeof(object) },
        {"max-nested-blocks", typeof(int) },
        {"never-returning-functions", typeof(object) },
        {"suggest-join-with-non-empty-separator", typeof(string) },
        {"evaluation", typeof(object) },
        {"msg-template", typeof(object) },
        {"reports", typeof(string) },
        {"score", typeof(string) },
        {"ignore-comments", typeof(string) },
        {"ignore-docstrings", typeof(string) },
        {"ignore-imports", typeof(string) },
        {"ignore-signatures", typeof(string) },
        {"min-similarity-lines", typeof(int) },
        {"max-spelling-suggestions", typeof(int) },
        {"spelling-dict", typeof(object) },
        {"spelling-ignore-comment-directives", typeof(object) },
        {"spelling-ignore-words", typeof(object) },
        {"spelling-private-dict-file", typeof(object) },
        {"spelling-store-unknown-words", typeof(string) },
        {"check-quote-consistency", typeof(string) },
        {"check-str-concat-over-line-jumps", typeof(string) },
        {"contextmanager-decorators", typeof(object) },
        {"generated-members", typeof(object) },
        {"ignore-none", typeof(string) },
        {"ignore-on-opaque-inference", typeof(string) },
        {"ignored-checks-for-mixins", typeof(object) },
        {"ignored-classes", typeof(object) },
        {"missing-member-hint", typeof(string) },
        {"missing-member-hint-distance", typeof(int) },
        {"missing-member-max-choices", typeof(int) },
        {"mixin-class-rgx", typeof(object) },
        {"signature-mutators", typeof(object) },
        {"additional-builtins", typeof(object) },
        {"allow-global-unused-variables", typeof(string) },
        {"allowed-redefined-builtins", typeof(object) },
        {"callbacks", typeof(object) },
        {"dummy-variables-rgx", typeof(object) },
        {"ignored-argument-names", typeof(object) },
        {"init-import", typeof(string) },
        {"redefining-builtins-modules", typeof(object) },
};

    private string GetSection(int index)
    {
        switch (index)
        {
            case var i when i >= 0 && i <= 19:
                return "MAIN";
            case var i when i >= 20 && i <= 39:
                return "BASIC";
            case var i when i >= 40 && i <= 44:
                return "CLASSES";
            case var i when i >= 45 && i <= 56:
                return "DESIGN";
            case 57:
                return "EXCEPTIONS";
            case var i when i >= 58 && i <= 65:
                return "FORMAT";
            case var i when i >= 66 && i <= 75:
                return "IMPORTS";
            case var i when i >= 76 && i <= 77:
                return "LOGGING";
            case var i when i >= 78 && i <= 80:
                return "MESSAGES CONTROL";
            case 81:
                return "METHOD_ARGS";
            case var i when i >= 82 && i <= 83:
                return "MISCELLANEOUS";
            case var i when i >= 84 && i <= 86:
                return "REFACTORING";
            case var i when i >= 87 && i <= 90:
                return "REPORTS";
            case var i when i >= 91 && i <= 95:
                return "SIMILARITIES";
            case var i when i >= 96 && i <= 101:
                return "SPELLING";
            case var i when i >= 102 && i <= 103:
                return "STRING";
            case var i when i >= 104 && i <= 114:
                return "TYPECHECK";
            case var i when i >= 115 && i <= 122:
                return "VARIABLES";
            default:
                return null;
        }
    }

    private void InitializeFileFormat()
    {
        PylintrcLists.Items.Clear();
        foreach (var i in sections)
        {
            foreach (var item in iniFile.GetKeys(i))
            {
                if (item.StartsWith("#"))
                {
                    continue;
                }

                PylintrcLists.Items.Add(item);
            }
        }
    }

    private string _previousQuery;
    private int _currentIndex = -1;

    private void SearchBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            var searchText = SearchBox.Text.ToLower();
            var found = false;

            if (searchText == _previousQuery)
            {
                _currentIndex++;
                if (_currentIndex >= PylintrcLists.Items.Count)
                {
                    _currentIndex = 0;
                }
            }
            else
            {
                _currentIndex = 0;
            }

            for (var i = _currentIndex; i < PylintrcLists.Items.Count; i++)
            {
                var item = PylintrcLists.Items[i].ToString().ToLower();
                if (item.Contains(searchText))
                {
                    PylintrcLists.SelectedItem = PylintrcLists.Items[i];
                    found = true;
                    _currentIndex = i;
                    break;
                }
            }

            if (found)
            {
                SearchStatus.Text = "Found";
                SearchStatus.Symbol = 61452;
                SearchStatus.SymbolColor = Color.PaleGreen;
                SearchStatus.Show();
                SearchBox.Focus();
            }
            else
            {
                SearchStatus.Text = "Not Found";
                SearchStatus.Symbol = 61453;
                SearchStatus.SymbolColor = Color.Firebrick;
                SearchStatus.Show();
                SearchBox.Focus();
            }

            _previousQuery = searchText;
        }
    }

    private void GotoPylint(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("https://www.pylint.org");
    }

    private void UpdateIndex(object sender, EventArgs e)
    {
        TBOriginName.Text = PylintrcLists.SelectedItem.ToString();
        TBChineseName.Text = ChineseTranslations[PylintrcLists.SelectedItem.ToString()];
        var value = iniProcessor.Read<string>(GetSection(PylintrcLists.SelectedIndex), TBOriginName.Text);
        if (value == "yes" || value == "no")
        {
            TBPylintValue.Disable();
            SetItemsToYesNo();
            CBoxOptions.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            CBoxOptions.Text = value;
            CBoxOptions.Enable();
        }
        else if (value == "PascalCase" || value == "snake_case" || value == "UPPER_CASE")
        {
            TBPylintValue.Disable();
            SetItemsToNamingStyles();
            CBoxOptions.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            CBoxOptions.Text = value;
            CBoxOptions.Enable();
        }
        else if (value == "CRLF" || value == "LF")
        {
            TBPylintValue.Disable();
            SetItemsToLineEndingFormat();
            CBoxOptions.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            CBoxOptions.Text = value;
            CBoxOptions.Enable();
        }
        else
        {
            CBoxOptions.Disable();
            TBPylintValue.Enable();
            TBPylintValue.Text = value;
        }
    }


    private void GotoPEP8(object sender, LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start("https://peps.python.org/pep-0008/");
    }

    private void SetItemsToYesNo()
    {
        CBoxOptions.Items.Clear();
        CBoxOptions.Items.AddRange(["yes", "no"]);
    }
    private void SetItemsToNamingStyles()
    {
        CBoxOptions.Items.Clear();
        CBoxOptions.Items.AddRange(["PascalCase", "snake_case", "UPPER_CASE"]);
    }

    private void SetItemsToLineEndingFormat()
    {
        CBoxOptions.Items.Clear();
        CBoxOptions.Items.AddRange(["CRLF", "LF"]);
    }
}
