using ParseZakupki.Parameter.Common;

namespace ParseZakupki.UrlBuilder
{
    public interface IUrlBuilder
    {
        string Build(IParameter parameter);
    }
}
