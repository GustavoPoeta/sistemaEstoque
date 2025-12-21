using SistemaEstoque.Application.Ports;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.ValueObjects;

namespace SistemaEstoque.Application.UseCases;

public sealed class CreateUserUseCase
{
    private readonly IUserRepository _repository;

    public CreateUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync (string name, string email, string accessLevel, string password)
    {
        if (await _repository.EmailExists(new Email(email)))
            throw new ApplicationException("O email já está em uso.");
        
        var user = new User(
            Guid.Empty,
            name,
            new Email(email),
            accessLevel,
            password
        );

        await _repository.Add(user);

        return user.Id;
    }   
}