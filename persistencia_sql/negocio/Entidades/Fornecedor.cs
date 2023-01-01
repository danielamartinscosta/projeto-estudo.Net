namespace Negocio.Entidades;

public record Fornecedor
{
    //propriedades
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }

}