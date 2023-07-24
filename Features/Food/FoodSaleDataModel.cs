using LiteDB;

namespace FoodDeliveryApp.Features.Food
{
    public class FoodSaleDataModel
    {
        public Guid SaleId { get; set; }
        [BsonId]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public decimal FoodPrice { get; set; }
        public string FoodPhoto { get; set; }
        public int Qty { get; set; }
    }
}
