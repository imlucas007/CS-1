using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class PedidoRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public PedidoRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Pedido> GetAll()
    {
        var pedidos = new List<Pedido>();
        

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedido";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var pedidoid = reader.GetInt32(0);
            var empregadoid = reader.GetInt32(1);
            var datapedido = reader.GetString(2);
            var peso = reader.GetString(3);
            var codtransportadora = reader.GetInt32(4);
            var pedidoclienteid = reader.GetInt32(5);
            var pedido = ReaderToPedido(reader);
            pedidos.Add(pedido);
        }

        connection.Close();
        
        return pedidos;
    }

    public Pedido Save(Pedido pedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedido VALUES($pedidoid, $empregadoid, $datapedido, $peso, $codtransportadora, $pedidoclienteid)";
        command.Parameters.AddWithValue("$pedidoid", pedido.PedidoId);
        command.Parameters.AddWithValue("$empregadoid", pedido.EmpregadoId);
        command.Parameters.AddWithValue("$datapedido", pedido.DataPedido);
        command.Parameters.AddWithValue("$peso", pedido.Peso);
        command.Parameters.AddWithValue("$codtransportadora", pedido.CodTransportadora);
        command.Parameters.AddWithValue("$pedidoclienteid", pedido.PedidoClienteId);

        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }
    public Pedido GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Pedido WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var pedido = ReaderToPedido(reader);

        connection.Close(); 

        return pedido;
    }
    public Pedido Update(Pedido pedido)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

       var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Pedido VALUES($pedidoid, $empregadoid, $datapedido, $peso, codtransportadora, $pedidoclienteid)";
        command.CommandText = "UPDATE Pedidos SET datapedido = $datapedido, peso = $peso, codtransportadora = $codtransportadora  WHERE (pedidoid = $pedidoid, empregadoid = $empregadoid, pedidoclienteid = $pedidoclienteid)";
        command.Parameters.AddWithValue("$pedidoid", pedido.PedidoId);
        command.Parameters.AddWithValue("$empregadoid", pedido.EmpregadoId);
        command.Parameters.AddWithValue("$datapedido", pedido.DataPedido);
        command.Parameters.AddWithValue("$peso", pedido.Peso);
        command.Parameters.AddWithValue("$codtransportadora", pedido.CodTransportadora);
        command.Parameters.AddWithValue("$pedidoclienteid", pedido.PedidoClienteId);;

        command.ExecuteNonQuery();
        connection.Close();

        return pedido;
    }
    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Computers WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
        connection.Close();
    }
    public bool ExitsById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Computers WHERE (id = $id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }
private Pedido ReaderToPedido(SqliteDataReader reader)
    {
        var pedido = new Pedido(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5));

        return pedido;
    }
}