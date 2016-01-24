using System.Threading.Tasks;

namespace ParseZakupki
{
    public interface IClient
    {
        string GetResult(string url);

        Task<string> GetResultAsync(string url);
    }
}
