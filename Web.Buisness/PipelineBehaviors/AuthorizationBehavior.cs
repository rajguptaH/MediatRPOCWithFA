using MediatR;
using Microsoft.AspNetCore.Http;
using Web.Buisness.Interface;

namespace Web.Buisness.PipelineBehaviors
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IAuthorizationRule<TRequest> _authorizationHandler;
        private readonly IHttpContextAccessor _contextAccessor;
        public AuthorizationBehavior(IAuthorizationRule<TRequest> authorizationRule,IHttpContextAccessor context)
        {
            _authorizationHandler = authorizationRule;
            _contextAccessor = context;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await _authorizationHandler.Authorize(request, cancellationToken, _contextAccessor);
            // Continue to the next handler in the pipeline
            return await next();
        }
    }
}
