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

        public IActionResult Index()
        {
            var FoodPagination = _foodService.FoodPagination(new FoodPaginationRequestModel());
            var FoodCategoryList = _foodService.FoodCategoryList;
            var ActiveCategory = 0;
            ViewBag.FoodSectionModel = new FoodSectionModel
            {
                ActiveCategory = 0,
                FoodCategoryList = FoodCategoryList,
                FoodPagination = FoodPagination
            };
            return View();
        }

        public IActionResult FoodSection(FoodPaginationRequestModel request)
        {
            var foodPagination = _foodService.FoodPagination(request);
            var response = new FoodSectionModel
            {
                ActiveCategory = request.FoodCategoryId,
                FoodPagination = foodPagination,
                FoodCategoryList = _foodService.FoodCategoryList
            };
            return View(response);
        }
    }
}
