using System.IO;

namespace DeliveryFood.Configuration
{
    public static class MySqlConfig
    {
        public static string GetConnectionString()
        {
            string server = "localhost";
            string port = "3306";
            string uid = "root";
            string password = "root";
            string database = "food_delivery_service";

            return $"Server={server};Port={port};Uid={uid};Pwd={password};Database={database};";
        }
    }
}