using System;
using MySql.Data.MySqlClient;

namespace DatabaseConnection
{
    class ReadWriteData
    {
        public static void ReadWrite()
        {
            using var connection = DatabaseHelper.GetDatabaseConnection();
            try
            {
                connection.Open();
                RetrieveAllUsers(connection);
                RetrieveUserById(connection, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RetrieveAllUsers(MySqlConnection connection)
        {
            using var command = new MySqlCommand("SELECT * FROM users;", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"ID: {reader["user_id"]}, " +
                    $"Username: {reader["username"]}, " +
                    $"Email: {reader["email"]}"
                );
            }
        }

        static void RetrieveUserById(MySqlConnection connection, int userId)
        {
            using var command = new MySqlCommand(
                "SELECT * FROM users WHERE user_id=@id;", connection);

            command.Parameters.AddWithValue("@id", userId);

            using var reader = command.ExecuteReader();
            if (reader.Read())
                Console.WriteLine($"User: {reader["username"]}");
            else
                Console.WriteLine("User not found.");
        }
    }
}
