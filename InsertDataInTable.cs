using System;

namespace DatabaseConnection
{
    class InsertDataInTable
    {
        public static void InsertData()
        {
            using var connection = DatabaseHelper.GetDatabaseConnection();
            try
            {
                connection.Open();

                DatabaseHelper.ExecuteNonQuery(
                    connection,
                    @"INSERT INTO users (username, email, password_hash)
                      VALUES (@username, @email, @passwordHash);",
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@username", "john_doe");
                        cmd.Parameters.AddWithValue("@email", "john.doe@example.com");
                        cmd.Parameters.AddWithValue("@passwordHash", "hashed_password");
                    });

                Console.WriteLine("User inserted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
