using Negocio.Servicos;
using Database.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;



namespace Web.Controllers;

//[Route("/clientes")] //define uma rota específica para esse controlador
public class ClientesController : Controller
{

    private static ClienteServico clienteServico = new ClienteServico(new Repositorio<Cliente>());
    
    public IActionResult Index()
    {
        ViewBag.clientes = clienteServico.Todos();  //viewag(mochila de visualização)
        return View();
    }

    public IActionResult Novo()
    {
        return View();
    }


    public IActionResult Cadastrar([FromForm] Cliente cliente)
    {
        if(string.IsNullOrEmpty(cliente.Nome))
        {
            ViewBag.erro = "O nome não pode ser vazio";
            return View();
        }

        clienteServico.Salvar(cliente);

        return Redirect("/clientes");
    }

[Route("/clientes/{id}/editar")]
    public IActionResult Editar([FromRoute] int id)
    {
    
        ViewBag.cliente = clienteServico.BuscaPorId(id);
        return View();
    }

    [Route("/clientes/{id}/atualizar")]
    public IActionResult Atualizar([FromRoute] int id, [FromForm] Cliente cliente)
    {
        cliente.Id = id;
        clienteServico.Salvar(cliente);
        return Redirect("/clientes");
    }


[Route("/clientes/{id}/apagar")] // {id} id coringa
    public IActionResult Apagar([FromRoute] int id)
    {

        clienteServico.ApagaPorId(id);

        return Redirect("/clientes");
    }
}
