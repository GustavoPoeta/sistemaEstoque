using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Application.Ports;
using SistemaEstoque.Domain.Entities;
using SistemaEstoque.Domain.ValueObjects;
using SistemaEstoque.Infrastructure.Persistence;

namespace SistemaEstoque.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> EmailExists(Email email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Value == email.Value);
    }

    public async Task Add (User user)
    {   
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}