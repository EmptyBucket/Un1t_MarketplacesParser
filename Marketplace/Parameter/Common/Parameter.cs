namespace ParseZakupki.Parameter.Common
{
    public class Parameter
    {
        public IParameterType Type { get; }

        public string Value { get; }

        public Parameter(IParameterType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => Value != null ? $"{Type.Type}={Value}&" : string.Empty;
    }
}
