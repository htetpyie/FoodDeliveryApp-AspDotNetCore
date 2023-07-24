using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

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

        [HttpPost]
        public IActionResult AddToCart(int foodId, int qty)
        {
            var food = _foodService.GetFoodById(foodId);
            FoodSaleDataModel model = food.Change();

            _foodService.AddedFoodToCart(model, qty);
            int count = GetCartItems();

            return Json(count);
        }

        public IActionResult Cart()
        {
            var cardList = _foodService.GetAddedFoodList();
            return View(cardList);
        }

        [HttpPost]
        public IActionResult GetFoodCount()
        {
            int count = GetCartItems();
            return Json(count);
        }

        public IActionResult Checkout()
        {
            var foodList = _foodService.GetAddedFoodList();
            _foodService.DeleteAddedFoods();
            return View(foodList);
        }

        public IActionResult CartSection()
        {
            var foodList = _foodService.GetAddedFoodList();
            return View(foodList);
        }

        [HttpPost]
        public IActionResult DeleteFood(int foodId) 
        {
            bool isSuccess = _foodService.DeleteAddedFood(foodId);
            return Json(isSuccess);
        }

        private int GetCartItems()
        {
            var foodList = _foodService.GetAddedFoodList();
            int count = foodList.Sum(x => x.Qty);
            return count;
        }
    }
}
