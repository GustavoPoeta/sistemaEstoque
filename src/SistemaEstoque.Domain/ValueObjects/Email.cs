namespace SistemaEstoque.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("O email não pode ser nulo ou vazio");
        if (!value.Contains('@')) 
            throw new DomainException("Email inválido: não possui @");
        
        this.Value = value;
    }

    public override string ToString() => Value;
}