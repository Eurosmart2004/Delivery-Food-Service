
using System.Data;
using DeliveryFood.Configuration;
using MySql.Data.MySqlClient;

namespace DeliveryFood.Data
{
    public class Sql
    {
        private string connectionString;
        public Sql()
        {
            connectionString = MySqlConfig.GetConnectionString();
        }
        public List<Restaurant> GetRestaurant()
        {
            List<Restaurant> restaurants = new();
            string queryString = "SELECT * FROM restaurants r " +
                "WHERE available = 1 " +
                "order by name;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Restaurant restaurant = new()
                            {
                                Name = row["Name"].ToString(),
                                ID = int.Parse(row["ID"].ToString())
                            };
                            restaurants.Add(restaurant);
                        }
                        return restaurants;
                    }
                }
            }
        }
        public List<Food> GetFood(int res_id)
        {
            List<Food> foods = new();
            string queryString = $"SELECT f.id, f.price, f.name " +
                $"FROM restaurants r JOIN foods f ON r.id = f.restaurant_id " +
                $"WHERE r.id = '{res_id}';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Food food = new()
                            {
                                Name = row["name"].ToString(),
                                Id = int.Parse(row["ID"].ToString()),
                                Res_Id = res_id,
                                Price = float.Parse(row["price"].ToString()),
                            };
                            foods.Add(food);
                        }
                        return foods;
                    }
                }
            }
        }

        public int GetShipper()
        {
            string queryString = $"select s.id " +
                $"from shippers as s join orders as o on s.id = o.shipper_id " +
                $"group by s.id " +
                $"having count(s.id) = sum(o.status = 'finished');";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        Random random = new Random();
                        int randomNumber = random.Next(dataTable.Rows.Count);
                        int shipperID = int.Parse(dataTable.Rows[randomNumber]["id"].ToString());
                        return shipperID;

                    }
                }
            }
        }
        public void AddOrder(int user_id, int shipper_id, int restaurant_id, string date, float delivery_fee, string food_id_count)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("store_order", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters required by the store_order function
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.Parameters.AddWithValue("@shipper_id", shipper_id);
                    command.Parameters.AddWithValue("@restaurant_id", restaurant_id);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@delivery_fee", delivery_fee);
                    command.Parameters.AddWithValue("@food_id_count", food_id_count);

                    // Execute the command
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public List<Order> GetOrder(string status)
        {
            List<Order> orders = new();
            string queryString;
            switch (status.ToLower())
            {
                case "all":
                    queryString = $"select o.id, u.name as user_name, r.name as restaurant_name, s.name as shipper_name, o.date, group_concat(f.name separator ', ') as foods, o.status from shippers as s join orders as o on s.id = o.shipper_id" +
                $" join users as u on o.user_id = u.id" +
                $" join restaurants as r on r.id = o.restaurant_id" +
                $" join food_order as fo on fo.order_id = o.id" +
                $" join foods as f on f.id = fo.food_id" +
                $" where u.id = 2" +
                $" group by o.id" +
                $" order by o.date desc;";
                    break;
                default:
                    queryString = $"select o.id, u.name as user_name, r.name as restaurant_name, s.name as shipper_name, o.date, group_concat(f.name separator ', ') as foods, o.status from shippers as s join orders as o on s.id = o.shipper_id" +
                $" join users as u on o.user_id = u.id" +
                $" join restaurants as r on r.id = o.restaurant_id" +
                $" join food_order as fo on fo.order_id = o.id" +
                $" join foods as f on f.id = fo.food_id" +
                $" where u.id = 2  AND o.status = '{status.ToLower()}'" +
                $" group by o.id" +
                $" order by o.date desc;";
                    break;
            }
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(queryString, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Order order = new()
                            {
                                RestaurantName = row["restaurant_name"].ToString(),
                                ShipperName = row["shipper_name"].ToString(),
                                DateTime = row["date"].ToString(),
                                FoodList = row["foods"].ToString(),
                                Status = row["status"].ToString()
                            };
                            orders.Add(order);
                        }
                        return orders;
                    }
                }
            }
        }
    }
}
