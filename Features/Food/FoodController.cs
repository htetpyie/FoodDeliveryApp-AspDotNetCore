using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Features.Food
{
    public class FoodController : Controller
    {
        public IActionResult PopularFood()
        {
            return View();
        }

    }
}
