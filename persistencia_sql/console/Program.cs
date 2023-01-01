using ConsoleApp.UI;



while (true)
{
    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Atualizar Cliente");
    Console.WriteLine("3 - Listar Cliente");
    Console.WriteLine("4 - Sair");

    var sair = false;
    var opcao = Console.ReadLine();

    switch(opcao)
    {
        case "1":
        ClientesUI.Cadastrar();
        break;
        case "2":
        ClientesUI.Atualizar();
        break;
        case "3":
        ClientesUI.Mostrar();
        break;
        default:
        sair = true;
        break;
    }

    if(sair) break;

}
