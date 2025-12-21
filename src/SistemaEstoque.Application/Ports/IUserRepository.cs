using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.ValueObjects;

namespace SistemaEstoque.Application.Ports;

public interface IUserRepository
{
    Task<bool> EmailExists (Email email);
    Task Add (User user);
}