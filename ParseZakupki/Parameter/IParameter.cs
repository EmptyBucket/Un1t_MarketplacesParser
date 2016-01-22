namespace ParseZakupki.Parameter
{
    public interface IParameter
    {
        IParameterType Type { get; }

        string Value { get; }
    }
}
