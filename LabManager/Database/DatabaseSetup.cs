using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{

    public DatabaseSetup()
    {
        CreateComputerTable();
        CreateLabTable();
    }

    private void CreateComputerTable()
    {

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            
            CREATE TABLE IF NOT EXISTS Computers(
                id int not null primary key,
                ram varchar(100) not null, 
                processor varchar(100) not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }

    private void CreateLabTable()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Labs(
                id int not null primary key,
                number varchar(10) not null,
                name varchar(100) not null,
                block varchar (5) not null
            );
        "; 

        command.ExecuteNonQuery();
        connection.Close();
    }
}