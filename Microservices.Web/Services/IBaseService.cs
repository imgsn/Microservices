using Microservices.Web.Models;

namespace Microservices.Web.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseDto { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);


    }
}
