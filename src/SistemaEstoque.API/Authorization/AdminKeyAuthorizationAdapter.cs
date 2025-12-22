using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using SistemaEstoque.Application.UseCases;

namespace SistemaEstoque.API.Authorization;

public sealed class AdminKeyAuthorizationAdapter : AuthorizationHandler<AdminKeyRequirement>
{
    private const string HeaderName = "X-ADMIN-KEY";
    private readonly VerifyAdminkeyUseCase _useCase;

    public AdminKeyAuthorizationAdapter(VerifyAdminkeyUseCase useCase)
    {
        _useCase = useCase;
    }

    protected override async Task HandleRequirementAsync (AuthorizationHandlerContext context, AdminKeyRequirement requirement)
    {
        if (context.Resource is not HttpContext httpContext)
            return;
        if (!httpContext.Request.Headers.TryGetValue(HeaderName, out var key))
            return;

        var isValid = await _useCase.ExecuteAsync(key!);

        if (isValid) 
            context.Succeed(requirement);

    } 
}