using System.Collections.Generic;
using ParseZakupki.Parameter;

namespace ParseZakupki
{
    public interface IUrlBuilder<T1, T2> where T1 : IParameterType where T2 : IParameter
    {
        string Build(IReadOnlyDictionary<T1, T2> parameters);
    }
}
