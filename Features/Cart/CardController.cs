using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Features.Cart
{
    public class CardController : Controller
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
