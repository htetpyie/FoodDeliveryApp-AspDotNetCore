namespace FoodDeliveryApp.Features.Food
{
    public class FoodPaginationResponseModel
    {
        public List<FoodModel> FoodList { get; set; } = new List<FoodModel>();
        public int TotalPageNo { get; set; }
    }
}
