namespace IDE
{
    internal enum CodeSenseType
    {
        FIELD,
        FUNC,
        FUNCTION = FUNC,
        METHOD = FUNC,
        KEYWORD,
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
                _ => "null",
            };
        }
    }
}
