namespace FoodDeliveryApp.Features.Food
{
    public class FoodSectionModel
    {
        public FoodPaginationResponseModel FoodPagination { get; set; }
        public int ActiveCategory { get; set; }
        public List<FoodCategoryModel> FoodCategoryList { get; set; }
    }
}