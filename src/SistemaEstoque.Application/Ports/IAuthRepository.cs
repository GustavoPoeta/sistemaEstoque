namespace SistemaEstoque.Application.Ports;

public interface IAuthRepository
{
    Task<bool> IsAdminKeyValid (string adminKey);   
}