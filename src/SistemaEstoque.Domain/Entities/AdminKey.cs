using System.Data.Common;

namespace SistemaEstoque.Domain.Entities;

public sealed class AdminKey
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Key { get; private set; } = String.Empty;
    public bool Active { get; private set; }

    private AdminKey() {}
    public AdminKey (Guid id, Guid userId, string key, bool active)
    {
        this.Id = id;
        this.UserId = userId;
        this.Key = key;
        this.Active = active;
    }

    public void Deactivate ()
    {
        Active = false;
    }
}