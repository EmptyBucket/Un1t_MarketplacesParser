using System.Collections.Generic;

namespace ParseZakupki
{
    public interface IUrlBuilder
    {
        string Build(IReadOnlyDictionary<IParameterType, Parameter.Parameter> parameters);
    }
}
