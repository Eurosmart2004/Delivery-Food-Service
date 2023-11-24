

namespace DeliveryFood.Data
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Res_Id { get; set; }
        public float Price { get; set; }
    }
    public class FoodSelect
    {
        public Food Food { get; set; }
        public int Count { get; set; }
    }
}
