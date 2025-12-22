using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.Ports;
using SistemaEstoque.Infrastructure.Persistence;

namespace SistemaEstoque.Infrastructure.Repositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;
    
    public AuthRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsAdminKeyValid (string adminKey)
    {
        var isAdminKeyValid = await _context.AdminKeys.AnyAsync(k => k.Key == adminKey && k.Active);
        return isAdminKeyValid;
    }
}