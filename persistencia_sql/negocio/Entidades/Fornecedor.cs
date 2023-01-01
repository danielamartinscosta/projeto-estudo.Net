using Database.Atributos;

namespace Negocio.Entidades;


[Tabela(Nome = "fornecedor")]
public record Fornecedor
{
    //propriedades
    public int Id { get; set; }
    
    [Coluna(Nome = "razão_social")]
    public string? Nome { get; set; }
    public string? Email { get; set; }

}