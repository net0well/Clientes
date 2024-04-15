using System.Globalization;
using Repositorio;

namespace Cadastro;
class Program
{
    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

    static void Main(string[] args)
    {
        var culture = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        _clienteRepositorio.LerDadosClientes();

        while (true)
        {

            Menu();
            Console.ReadKey();
        }
    }

    static void Menu()
    {
        Console.Clear();

        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("-----------------------");
        Console.WriteLine("1 - Cadastrar Clientes");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Clientes");
        Console.WriteLine("4 - Excluir Clientes");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("-----------------------");

        EscolherOpcao();

    }

    static void EscolherOpcao()
    {
        Console.WriteLine("Escolha uma opção: ");
        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
                {
                    _clienteRepositorio.CadastrarClientes();
                    Menu();
                    break;
                }

            case 2:
                {
                    _clienteRepositorio.ExibirClientes();
                    Menu();
                    break;
                }

            case 3:
                {
                    _clienteRepositorio.EditarClientes();
                    Menu();
                    break;

                }

            case 4:
                {
                    _clienteRepositorio.ExcluirClientes();
                    Menu();
                    break;
                }

            case 5:
                {
                    _clienteRepositorio.GravarDadosClientes();
                    Environment.Exit(0);
                    break;
                }

            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida.");
                    break;
                }
        }
    }

}
