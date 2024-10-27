using Medical_Information_System_API.Classes;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Medical_Information_System_API.Data;

public class DatabaseManager
{
    private string connectionString = "Host=localhost;Username=postgres;Password=123456";

    public void CreateDatabase(string name)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand($"SELECT 1 FROM pg_database WHERE datname = '{name}'", connection)) {
                var exists = command.ExecuteScalar();

                if (exists == null)
                {
                    using (var create = new NpgsqlCommand($"CREATE DATABASE {name}", connection))
                    {
                        create.ExecuteNonQuery();
                    }
                }
            }

            connection.Close();
        }
    }
}
