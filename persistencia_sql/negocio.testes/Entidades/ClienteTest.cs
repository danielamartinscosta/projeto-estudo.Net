using Negocio.Entidades;


namespace negocio.testes.Entidades;

[TestClass]
public class ClienteTest
{
    [TestMethod]
    public void TestandoPropriedades() 
    {
        //testa os sets de propriedades
        var cliente = new Cliente(); 
        cliente.Id = 1;
        cliente.Nome = "Leo";
        cliente.Email = "leo@gmail.com";

        //testa os gets de propriedades
        Assert.AreEqual(1, cliente.Id);
        Assert.AreEqual("Leo", cliente.Nome);
        Assert.AreEqual("leo@gmail.com", cliente.Email);



    }
}