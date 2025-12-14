using System;
using MySql.Data.MySqlClient;

namespace DatabaseConnection
{
    class ConnectDatabaseCreateTable
    {
        public static void ConnectDb()
        {
            string databaseName = "ecommerce_db";

            using var connection = DatabaseHelper.GetServerConnection();
            try
            {
                connection.Open();

                DatabaseHelper.ExecuteNonQuery(
                    connection,
                    $"CREATE DATABASE IF NOT EXISTS {databaseName};"
                );

                connection.ChangeDatabase(databaseName);

                DatabaseHelper.ExecuteNonQuery(connection, @"
                    CREATE TABLE IF NOT EXISTS users (
                        user_id INT AUTO_INCREMENT PRIMARY KEY,
                        username VARCHAR(50) NOT NULL,
                        email VARCHAR(100) NOT NULL UNIQUE,
                        password_hash VARCHAR(255) NOT NULL,
                        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                        updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                    );
                ");

                Console.WriteLine("Database & table ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
