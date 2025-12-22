using SistemaEstoque.Application.Ports;

namespace SistemaEstoque.Application.UseCases;

public sealed class VerifyAdminkeyUseCase
{
    private IAuthRepository _repository;

    public VerifyAdminkeyUseCase (IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync (string adminKey)
    {
        return await _repository.IsAdminKeyValid(adminKey);
    }
}