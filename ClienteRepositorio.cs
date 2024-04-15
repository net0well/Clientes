using System.Text.Json.Serialization;
using Cadastro;

namespace Repositorio;

public class ClienteRepositorio
{
  public List<Clientes> clientes = new List<Clientes>();

  public void GravarDadosClientes()
  {
    var json = System.Text.Json.JsonSerializer.Serialize(clientes);

    File.WriteAllText("clientes.json", json);
  }
  public void LerDadosClientes()
  {
    if (File.Exists("clientes.json"))
    {


      var dados = File.ReadAllText("clientes.json");
      var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Clientes>>(dados);

      clientes.AddRange(clientesArquivo);
    }
  }



  public void ExcluirClientes()
  {
    Console.Clear();

    Console.WriteLine("Inform o código do cliente: ");
    var codigo = Console.ReadLine();

    var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

    if (cliente == null)
    {
      Console.WriteLine("Cliente não encontrado! [ENTER]");
      Console.ReadKey();
      return;
    }

    ImprimirCliente(cliente);

    clientes.Remove(cliente);

    Console.WriteLine("Cliente removido com sucesso. [ENTER]");
    Console.ReadKey();

  }

  public void EditarClientes()
  {
    Console.Clear();

    Console.WriteLine("Inform o código do cliente: ");
    var codigo = Console.ReadLine();

    var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

    if (cliente == null)
    {
      Console.WriteLine("Cliente não encontrado! [ENTER]");
      Console.ReadKey();
      return;
    }

    ImprimirCliente(cliente);

    Console.WriteLine("Nome do Cliente: ");
    var nome = Console.ReadLine();
    Console.Write(Environment.NewLine);

    Console.WriteLine("Data de Nascimento: ");
    var dataNascimento = DateTime.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    Console.WriteLine("Desconto: ");
    var desconto = decimal.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    cliente.Nome = nome;
    cliente.Desconto = desconto;
    cliente.DataNascimento = dataNascimento;
    cliente.CadastradoEm = DateTime.Now;

    Console.WriteLine("Cliente alterado com sucesso! [ENTER]");
    ImprimirCliente(cliente);
    Console.ReadKey();

  }

  public void CadastrarClientes()
  {
    Console.Clear();

    Console.WriteLine("Nome do Cliente: ");
    var nome = Console.ReadLine();
    Console.Write(Environment.NewLine);

    Console.WriteLine("Data de Nascimento: ");
    var dataNascimento = DateTime.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    Console.WriteLine("Desconto: ");
    var desconto = decimal.Parse(Console.ReadLine());
    Console.Write(Environment.NewLine);

    var cliente = new Clientes();

    cliente.Id = clientes.Count + 1;
    cliente.Nome = nome;
    cliente.Desconto = desconto;
    cliente.DataNascimento = dataNascimento;
    cliente.CadastradoEm = DateTime.Now;

    clientes.Add(cliente);

    Console.WriteLine("Clientes cadastrado com sucesso! [ENTER]");
    ImprimirCliente(cliente);
    Console.ReadKey();


  }

  public void ImprimirCliente(Clientes clientes)
  {
    Console.WriteLine("ID...............: " + clientes.Id);
    Console.WriteLine("Nome.............: " + clientes.Nome);
    Console.WriteLine("Desconto.........: " + clientes.Desconto.ToString("0.00"));
    Console.WriteLine("Data Nascimento..: " + clientes.DataNascimento);
    Console.WriteLine("Data Cadastro....: " + clientes.CadastradoEm);
    Console.WriteLine("------------------");

  }

  public void ExibirClientes()
  {
    Console.Clear();

    foreach (var cliente in clientes)
    {
      ImprimirCliente(cliente);
    }

    Console.ReadKey();

  }
}