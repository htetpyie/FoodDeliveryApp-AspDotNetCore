namespace FoodDeliveryApp.Features.Cart
{
    public class ReceiptResponseModel
    {
        public CartHeadDataModel Head { get; set; }
        public List<CartDetailDataModel> Details { get; set; }
    }
}
