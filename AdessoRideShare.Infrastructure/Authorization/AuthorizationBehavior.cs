using MediatR;
using Microsoft.AspNetCore.Http;

namespace AdessoRideShare.Infrastructure.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>, IUserRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated != true)
            {
                throw new Exception("User not authenticated.");
            }

            List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (roleClaims == null)
            {
                throw new Exception("Claims not found.");
            }

            bool isAuthorized = roleClaims.Any(roleClaim => request.UserRoles.Contains(roleClaim));
            if (!isAuthorized)
            {
                throw new Exception("You are not authorized.");
            }

            TResponse response = await next();
            return response;
        }


        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
