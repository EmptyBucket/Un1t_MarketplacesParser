using System;
using System.Threading.Tasks;

namespace ParseZakupki.Client
{
    public interface IClient
    {
        string GetResult(Uri url);

        Task<string> GetResultAsync(Uri url);
    }
}
