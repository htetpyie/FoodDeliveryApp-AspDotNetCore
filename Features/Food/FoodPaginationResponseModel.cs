namespace FoodDeliveryApp.Features.Food
{
    public class FoodPaginationResponseModel
    {
        public List<FoodModel> FoodList { get; set; } = new List<FoodModel>();
        public int TotalPageNo { get; set; }
        public string SearchParam { get; set; } 
    }

    public class FoodPaginationRequestModel
    {
        public int FoodCategoryId { get; set; } = 0;
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public string SearchParam { get; set; } = "";
        public int Skip { get => (PageNo - 1) * PageSize; }
    }
}
