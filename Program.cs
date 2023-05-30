using Microsoft.Data.Sqlite;
using Aula10DB.Database;
using Aula10DB.Repositories;
using Aula10DB.Models;
var databaseConfig = new DatabaseConfig();
var databaseSetup = new DatabaseSetup(databaseConfig);
var clienteRepository = new ClienteRepository(databaseConfig);
var pedidoRepository = new PedidoRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];
if(modelName == "Cliente")
{
    if(modelAction == "Listar")
    {
        Console.WriteLine("Cliente List");
        foreach (var cliente in clienteRepository.GetAll())
        {
            Console.WriteLine($"{cliente.ClienteId}, {cliente.Endereco}, {cliente.Cidade}, {cliente.Regiao}, {cliente.CodigoPostal}, {cliente.Pais}, {cliente.Telefone}");
        }
    }

    if(modelAction == "Inserir")
    {
        Console.WriteLine("Cliente Inserido");
        var id = Convert.ToInt32(args[2]);
        string endereco = args[3];
        string cidade = args[4];
        string regiao = args[5];
        string codigopostal = args[6];
        string pais = args[7];
        string telefone = args[8];
    
        var cliente = new Cliente(id, endereco, cidade, regiao, codigopostal, pais, telefone);
        clienteRepository.Save(cliente);
    }

}

if(modelName == "Pedido")
{
    if(modelAction == "Listar")
    {
        Console.WriteLine("Pedido List");
        foreach (var pedido in pedidoRepository.GetAll())
        {
            Console.WriteLine($"{pedido.PedidoId}, {pedido.EmpregadoId}, {pedido.DataPedido}, {pedido.Peso}, {pedido.CodTransportadora}, {pedido.PedidoClienteId}");
        }
    }

    if(modelAction == "Inserir")
    {
        Console.WriteLine("Pedido New");
        var id = Convert.ToInt32(args[2]);
        int pedidoid = Convert.ToInt32(args[3]);
        int empregadoid = Convert.ToInt32(args[4]);
        string datapedido = args[5];
        string peso = args[6];
        int codtransportadora = Convert.ToInt32(args[7]);
        int pedidoclienteid = Convert.ToInt32(args[8]);
        var pedido = new Pedido(pedidoid, empregadoid, datapedido, peso, codtransportadora, pedidoclienteid);
        pedidoRepository.Save(pedido);
    }

}