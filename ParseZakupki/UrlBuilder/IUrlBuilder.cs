using System.Collections.Generic;
using ParseZakupki.Parameter;

namespace ParseZakupki
{
    public interface IUrlBuilder
    {
        string Build(IReadOnlyDictionary<IParameterType, IParameter> parameters);
    }
}
