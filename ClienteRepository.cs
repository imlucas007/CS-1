using Aula10DB.Database;
using Aula10DB.Models;
using Microsoft.Data.Sqlite;
namespace Aula10DB.Repositories;
class ClienteRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public ClienteRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Cliente> GetAll()
    {
        var clientes = new List<Cliente>();
        

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Cliente";

        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var clienteid = reader.GetInt32(0);
            var endereco = reader.GetString(1);
            var cidade = reader.GetString(2);
            var regiao = reader.GetString(3);
            var codigopostal = reader.GetString(4);
            var pais = reader.GetString(5);
            var telefone = reader.GetString(6);
            var cliente = ReaderToCliente(reader);
            clientes.Add(cliente);
        }

        connection.Close();
        
        return clientes;
    }

    public Cliente Save(Cliente cliente)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Cliente VALUES($clienteid, $endereco, $cidade, $regiao, $codigopostal, $pais, $telefone)";
        command.Parameters.AddWithValue("$clienteid", cliente.ClienteId);
        command.Parameters.AddWithValue("$endereco", cliente.Endereco);
        command.Parameters.AddWithValue("$cidade", cliente.Cidade);
        command.Parameters.AddWithValue("$regiao", cliente.Regiao);
        command.Parameters.AddWithValue("$codigopostal", cliente.CodigoPostal);
        command.Parameters.AddWithValue("$pais", cliente.Pais);
        command.Parameters.AddWithValue("$telefone", cliente.Telefone);

        command.ExecuteNonQuery();
        connection.Close();

        return cliente;
    }
    public Cliente GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Cliente WHERE (clienteid = $clienteid)";
        command.Parameters.AddWithValue("$clienteid", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var cliente = ReaderToCliente(reader);

        connection.Close(); 

        return cliente;
    }
    public Cliente Update(Cliente cliente)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Cliente VALUES($clienteid, $endereco, $cidade, $regiao, codigopostal, $pais, $telefone)";
        command.CommandText = "UPDATE Computers SET endereco = $endereco, cidade = $cidade, regiao = $regiao, codigopostal = $codigopostal, pais = $pais, telefone = $telefone WHERE (clienteid = $clienteid)";
        command.Parameters.AddWithValue("$clienteid", cliente.ClienteId);
        command.Parameters.AddWithValue("$endereco", cliente.Endereco);
        command.Parameters.AddWithValue("$cidade", cliente.Cidade);
        command.Parameters.AddWithValue("$regiao", cliente.Regiao);
        command.Parameters.AddWithValue("$codigopostal", cliente.CodigoPostal);
        command.Parameters.AddWithValue("$pais", cliente.Pais);
        command.Parameters.AddWithValue("$telefone", cliente.Telefone);
        command.ExecuteNonQuery();
        connection.Close();

        return cliente;
    }
    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Computers WHERE (clienteid = $clienteid)";
        command.Parameters.AddWithValue("$clienteid", id);

        command.ExecuteNonQuery();
        connection.Close();
    }
    public bool ExitsById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Cliente WHERE (clienteid = $clienteid)";
        command.Parameters.AddWithValue("$clienteid", id);

        var reader = command.ExecuteReader();
        reader.Read();
        var result = reader.GetBoolean(0);

        return result;
    }
private Cliente ReaderToCliente(SqliteDataReader reader)
    {
        var cliente = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));

        return cliente;
    }
}