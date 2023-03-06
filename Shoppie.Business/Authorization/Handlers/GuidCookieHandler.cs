using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Shoppie.Business.Authorization.Requirements;

namespace Shoppie.Business.Authorization.Handlers;

public class GuidCookieHandler : AuthorizationHandler<GuidCookieRequired>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GuidCookieHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GuidCookieRequired requirement)
    {
        if (context.User.Identity.IsAuthenticated || _httpContextAccessor.HttpContext.Request.Cookies["UserId"] is not null)
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }
        return Task.CompletedTask;
    }
}
