using Microsoft.Data.Sqlite;

namespace Aula10DB.Database;

class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateClienteTable();
        CreatePedidoTable();
    }

    private void CreateClienteTable()
    {
        
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Cliente(
                clienteid int not null primary key,
                endereco varchar(100) not null,
                cidade varchar(100) not null,
                regiao varchar(100) not null,
                codigopostal varchar(100) not null,
                pais varchar(100) not null,
                telefone varchar(100) not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }

    private void CreatePedidoTable()
    {
        
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Pedido(
                pedidoid int not null primary key,
                empregadoid int not null,
                datapedido varchar(100) not null,
                peso varchar(100) not null,
                codtransportadora int not null,
                pedidoclienteid int not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }

}
