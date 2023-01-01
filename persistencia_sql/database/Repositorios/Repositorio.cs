using MySql.Data.MySqlClient;
using Database.Repositorios.Interfaces;

namespace Database.Repositorios;

public class Repositorio<T> : IRepositorio<T>
{

    private readonly string? conexao = Environment.GetEnvironmentVariable("DATABASE_URL"); // chamada de string de conexão chumbada no código.

    //métodos
    public void Salvar(T obj)
    {
        
        using(var conn = new MySqlConnection(conexao))
        {
        conn.Open(); //quando é feito um Open, se abre a conexao com o banco de dados

        List<string> colunasArray = new List<string>();
        List<string> valoresArray = new List<string>();
        List<string> updateArray = new List<string>();
        foreach(var prop in typeof(T).GetProperties())
        {
            if(prop.Name == "Id") continue;
            colunasArray.Add(prop.Name);
            valoresArray.Add($"'{prop.GetValue(obj)}'");
            updateArray.Add($"${prop.Name}='{prop.GetValue(obj)}'");
        }
        var colunas = string.Join(",", colunasArray.ToArray());
        var valores = string.Join(",", valoresArray.ToArray());
        var update = string.Join(",", updateArray.ToArray());
        
        var query = $"insert into {typeof(T).Name.ToLower()}s ({colunas})values({valores});";

        var id = Convert.ToInt32(typeof(T).GetProperty("Id")?.GetValue(obj));
        if(id > 0)
        query = $"update {typeof(T).Name.ToLower()}s set {update} where id='{id}';";

        var command = new MySqlCommand(query, conn);
        command.ExecuteNonQuery();

        conn.Close(); //Depois que fizer o que precisa ser feit, deve-se fechar a conexão com o banco de dados

        //conn.Dispose(); //Aqui informamos que o objeto não será mais utilizado, então é disparado uma msg para se fazer uma limpeza nessa item.oba. quando se usa o using e coloca o open e close dentro, ele já faz o dispose automaticamente.

        }
    }

    public List<T> BuscaPorIdOuEmail(string idOuEmail)
    {
        var clientes = new List<T>();
        using(var conn = new MySqlConnection(conexao))
        {
        conn.Open(); //quando é feito um Open, se abre a conexao com o banco de dados

        var query = $"select * from {typeof(T).Name.ToLower()}s where id = '{idOuEmail}' or email like '%{idOuEmail}%'";

        var command = new MySqlCommand(query, conn);
        var dataReader = command.ExecuteReader();
        
        while(dataReader.Read())
        {
            var obj = Activator.CreateInstance<T>();

            foreach(var prop in typeof(T).GetProperties())
            {
                var valor = dataReader[prop.Name].ToString();
                obj?.GetType().GetProperty(prop.Name)?.SetValue(obj,valor);
            }
        }

        conn.Close(); //Depois que fizer o que precisa ser feit, deve-se fechar a conexão com o banco de dados

        }
        return clientes;
    }

    public List<T> Todos()
    {
        return new List<T>();

    }

    public void ApagaPorId(int id)
    {
        using(var conn = new MySqlConnection(conexao))
        {
        conn.Open(); //quando é feito um Open, se abre a conexao com o banco de dados
        
        var query = $"delete from {typeof(T).Name.ToLower()}s where id = {id};";

        var command = new MySqlCommand(query, conn);
        command.ExecuteNonQuery();

        conn.Close(); 

        }
    }

    public T? BuscaPorId(int id)
    {

        var obj = Activator.CreateInstance<T>();
        return obj;
    }


}