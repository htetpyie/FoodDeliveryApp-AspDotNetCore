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

        public ActionResult Index()
        {
            ViewBag.FoodList = _foodService.FoodList;
            ViewBag.FoodCategoryList = _foodService.FoodCategoryList;
            return View();
        }

        public IActionResult PopularFood()
        {
            ViewBag.FoodList = _foodService.FoodList;
            ViewBag.FoodCategoryList = _foodService.FoodCategoryList;
            return View();
        }

    }
}
