namespace IDE
{
    internal enum CodeSenseType
    {
        FIELD,
        FUNC,
        FUNCTION = FUNC,
        METHOD = FUNC,
        KEYWORD,
        BUILTIN,
    }

    internal class CodeSense
    {
        private CodeSenseType _type;

        internal CodeSense(CodeSenseType type)
        {
            _type = type;
        }

        internal string GetCodeSenseType()
        {
            return _type switch
            {
                CodeSenseType.FIELD => "field",
                CodeSenseType.FUNC => "function",
                CodeSenseType.KEYWORD => "keyword",
                CodeSenseType.BUILTIN => "builtin",
                _ => "null",
            };
        }
    }
}
