namespace Database.Repositorios.Interfaces;

public interface IRepositorio<T>
{
    void Salvar(T cliente);
    List<T> BuscaPorIdOuEmail(string idOuEmail);

    List<T> Todos();

    void ApagaPorId(int id);
    T? BuscaPorId(int id);
}