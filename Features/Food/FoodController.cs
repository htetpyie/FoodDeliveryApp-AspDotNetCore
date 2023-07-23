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
            ViewBag.FoodPagination = _foodService.FoodList(new FoodPaginationRequestModel());
            ViewBag.FoodCategoryList = _foodService.FoodCategoryList;
            return View();
        }
       
    }
}
