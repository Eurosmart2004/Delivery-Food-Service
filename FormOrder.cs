using DeliveryFood.Data;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DeliveryFood
{
    public partial class FormOrder : Form
    {
        Sql sqlQuery;
        List<Restaurant> restaurants;
        List<Food> foods;
        List<FoodSelect> foodSelects;
        List<Order> orders;
        float delivery;
        public FormOrder()
        {
            sqlQuery = new Sql();
            foodSelects = new();
            delivery = 0;
            InitializeComponent();
            LoadRestaurant();
            LoadStatus();
        }

        private void cmbRestaurant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int res_id = restaurants[int.Parse(cmbRestaurant.SelectedIndex.ToString())].ID;
            foods = sqlQuery.GetFood(res_id);
            List<string> foodList = new List<string>();
            foreach (Food food in foods)
            {
                foodList.Add(food.Name);
            }
            cmbFood.DataSource = foodList;
            Random random = new Random();
            delivery = random.Next(20);
            deliveryFee.Text = delivery.ToString();

        }
        private void LoadRestaurant()
        {
            restaurants = sqlQuery.GetRestaurant();
            List<string> res = new List<string>();
            foreach (Restaurant restaurant in restaurants)
            {
                res.Add(restaurant.Name);
            }
            cmbRestaurant.DataSource = res;

        }

        private void addFood_Click(object sender, EventArgs e)
        {
            int id = foods[int.Parse(cmbFood.SelectedIndex.ToString())].Id;
            string name = foods[int.Parse(cmbFood.SelectedIndex.ToString())].Name;
            int count = (int)(quantityNum.Value);
            float price = foods[int.Parse(cmbFood.SelectedIndex.ToString())].Price;
            float totalPrice = price * count;
            ListViewItem item = ExistFood(id);
            if (item != null)
            {
                foreach (FoodSelect foodSelect in foodSelects.ToList())
                {
                    if (foodSelect.Food.Id == id)
                    {
                        count += int.Parse(item.SubItems[2].Text);
                        if (count > 0)
                        {
                            item.SubItems[2].Text = count.ToString();
                            totalPrice = price * count;
                            item.SubItems[4].Text = totalPrice.ToString();
                            foodSelect.Count = count;
                        }
                        else
                        {
                            item.Remove();
                            foodSelects.Remove(foodSelect);
                        }
                    }

                }
            }
            else
            {
                if (count > 0)
                {
                    ListViewItem lvi = new ListViewItem(id.ToString());
                    lvi.SubItems.Add(name.ToString());
                    lvi.SubItems.Add(count.ToString());
                    lvi.SubItems.Add(price.ToString());
                    lvi.SubItems.Add(totalPrice.ToString());
                    listFoodOrder.Items.Add(lvi);
                    FoodSelect foodSelect = new FoodSelect()
                    {
                        Food = foods[int.Parse(cmbFood.SelectedIndex.ToString())],
                        Count = count
                    };
                    foodSelects.Add(foodSelect);
                }
            }


            float total = 0;
            foreach (ListViewItem foodItem in listFoodOrder.Items)
            {
                total += float.Parse(foodItem.SubItems[4].Text);
            }
            if (total > 0)
            {
                total += delivery;
            }
            totalPriceFood.Text = Math.Round(total, 2).ToString();

            //Prevent change restaurant
            if (listFoodOrder.Items.Count > 0)
            {
                cmbRestaurant.Enabled = false;
            }
            else
            {
                cmbRestaurant.Enabled = true;
            }
        }

        private void listFoodOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private ListViewItem ExistFood(int id)
        {
            foreach (ListViewItem item in listFoodOrder.Items)
            {
                if (int.Parse(item.SubItems[0].Text) == id)
                {
                    return item;
                }
            }
            return null;
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            int resID = restaurants[int.Parse(cmbRestaurant.SelectedIndex.ToString())].ID;
            if (listFoodOrder.Items.Count > 0)
            {
                DateTime dateTime = DateTime.ParseExact($"{DateTime.Now}", "MM/dd/yyyy h:mm:ss tt", null);
                string stringDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                StringBuilder stringBuilder = new StringBuilder();
                foreach (FoodSelect foodSelect in foodSelects)
                {
                    int foodID = foodSelect.Food.Id;
                    int foodCount = foodSelect.Count;
                    stringBuilder.Append("{\"id\": ").Append(foodID).Append(", \"count\": ").Append(foodCount).Append("}, ");
                }

                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Length -= 2;
                }

                string foodResult = "[" + stringBuilder.ToString() + "]";
                int shipperID = sqlQuery.GetShipper();
                sqlQuery.AddOrder(2, shipperID, resID, stringDateTime, delivery, foodResult);
                foodSelects.Clear();
                listFoodOrder.Items.Clear();
                cmbRestaurant.Enabled = true;
                totalPriceFood.Text = "0";
            }
            RefreshOrder();
        }
        private void LoadStatus()
        {
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Preparing");
            cmbStatus.Items.Add("Delivering");
            cmbStatus.Items.Add("Finished");
            cmbStatus.SelectedIndex = 0;
            RefreshOrder();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOrder();
        }
        private void RefreshOrder()
        {
            orders = sqlQuery.GetOrder(cmbStatus.SelectedItem.ToString());
            lsvOrder.Items.Clear();
            foreach (Order order in orders)
            {
                ListViewItem item = new(order.RestaurantName);
                item.SubItems.Add(order.ShipperName);
                item.SubItems.Add(order.DateTime);
                item.SubItems.Add(order.FoodList);
                item.SubItems.Add(order.Status);
                lsvOrder.Items.Add(item);
            }
        }
    }
}