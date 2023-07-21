using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Features.Food
{
    public class FoodController : Controller
    {
        private readonly FoodService _foodService;

        public FoodController(FoodService foodService)
        {
            _foodService = foodService;
        }

        public IActionResult PopularFood()
        {
            var foodList = _foodService.FoodList;
            var foodCategory = _foodService.FoodCategoryList;
            return View(foodCategory);
        }

    }
}
