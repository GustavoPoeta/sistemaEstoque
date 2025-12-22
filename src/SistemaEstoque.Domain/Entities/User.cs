using SistemaEstoque.Domain.ValueObjects;

namespace SistemaEstoque.Domain.Entities;

public sealed class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public string AccessLevel { get; private set; } = null!;
    public string Password { get; private set; } = null!;

    public AdminKey? AdminKey { get; private set; } = null;

    private User () {}

    public User (Guid id, string name, Email email, string accessLevel, string password, AdminKey? adminkey = null) 
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
        this.AdminKey = adminkey;
    }

    public bool IsAdmin => AccessLevel == Roles.Admin;
}