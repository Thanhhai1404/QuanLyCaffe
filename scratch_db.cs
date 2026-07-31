using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connStr = "Server=localhost;Database=QuanLyCaffe;Integrated Security=True;";
        try
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                Console.WriteLine("Connected!");
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM sys.views WHERE name = 'vw_LichSuHoaDon'", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    Console.WriteLine($"vw_LichSuHoaDon exists: {count > 0}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
