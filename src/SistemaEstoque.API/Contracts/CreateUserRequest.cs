namespace SistemaEstoque.API.Contracts;

public sealed record CreateUserRequest(string name, string email, string accessLevel, string password);