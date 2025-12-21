using SistemaEstoque.Domain.ValueObjects;

namespace SistemaEstoque.Domain.Entities;

public sealed class User
{
    public Guid Id { get; }
    public string Name { get; } = null!;
    public Email Email { get; } = null!;
    public string AccessLevel { get; } = null!;
    public string Password { get; } = null!;

    private User () {}

    public User (Guid id, string name, Email email, string accessLevel, string password) 
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("O nome não pode ser nulo ou vazio");
        if (string.IsNullOrWhiteSpace(password))
            throw new DomainException("A senha não pode ser nula ou vazia");

        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.AccessLevel = accessLevel;
        this.Password = password;
    }

}