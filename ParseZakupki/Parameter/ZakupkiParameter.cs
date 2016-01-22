namespace ParseZakupki.Parameter
{
    public class ZakupkiParameter : IParameter
    {
        public IParameterType Type { get; }

        public string Value { get; }

        public ZakupkiParameter(IParameterType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => Value != null ? $"{Type.Type}={Value}&" : string.Empty;
    }
}
