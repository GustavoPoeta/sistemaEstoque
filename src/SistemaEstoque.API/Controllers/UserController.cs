using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.API.Contracts;
using SistemaEstoque.Application.UseCases;

namespace SistemaEstoque.API.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController : ControllerBase
{
    private readonly CreateUserUseCase _useCase;

    public UserController (CreateUserUseCase useCase)
    {
        _useCase = useCase;
    }

    [Authorize(Policy = "AdminKeyRequirement")]
    [HttpPost]
    [Route("add")]    
    public async Task<IActionResult> Add([FromBody] CreateUserRequest request)
    {
        var userId = await _useCase.ExecuteAsync(
            request.name,
            request.email,
            request.accessLevel,
            request.password
        );

        return Created();
    }
}