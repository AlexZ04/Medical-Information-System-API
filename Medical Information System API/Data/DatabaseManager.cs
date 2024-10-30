using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Models;
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

    public List<SpecialityModel> GetSpecList()
    {
        List<SpecialityModel> list = new List<SpecialityModel>() {
                    new SpecialityModel("Акушер-гинеколог"),
                    new SpecialityModel("Анестезиолог-реаниматолог"),
                    new SpecialityModel("Дерматовенеролог"),
                    new SpecialityModel("Инфекционист"),
                    new SpecialityModel("Кардиолог"),
                    new SpecialityModel("Невролог"),
                    new SpecialityModel("Онколог"),
                    new SpecialityModel("Отоларинголог"),
                    new SpecialityModel("Офтальмолог"),
                    new SpecialityModel("Психиатр"),
                    new SpecialityModel("Психолог"),
                    new SpecialityModel("Рентгенолог"),
                    new SpecialityModel("Стоматолог"),
                    new SpecialityModel("Терапевт"),
                    new SpecialityModel("УЗИ-специалист"),
                    new SpecialityModel("Уролог"),
                    new SpecialityModel("Хирург"),
                    new SpecialityModel("Эндокринолог"),
                };

        return list;
    }
}
