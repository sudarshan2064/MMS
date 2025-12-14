using System;
using DatabaseConnection;

class Program
{
    static void Main(string[] args)
    {
        using var connection = DatabaseHelper.GetServerConnection();
        try
        {
            connection.Open();
            Console.WriteLine("Connected to MySQL server!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
