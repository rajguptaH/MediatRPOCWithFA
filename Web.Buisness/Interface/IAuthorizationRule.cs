using Microsoft.AspNetCore.Http;

namespace Web.Buisness.Interface
{
    public interface IAuthorizationRule<in TRequest>
    {
        Task Authorize(TRequest request,CancellationToken cancellationToken,IHttpContextAccessor contex);
    }
}
