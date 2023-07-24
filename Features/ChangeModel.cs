using FoodDeliveryApp.Features.Food;

namespace FoodDeliveryApp.Features
{
    public static class ChangeModel
    {
        public static FoodSaleDataModel Change(this FoodModel model)
        {
            if (model == null)
            {
                return new();
            }

            return new FoodSaleDataModel
            {
                SaleId = new Guid(),
                FoodId = model.FoodId,
                FoodName = model.FoodName,
                FoodPhoto = model.FoodPhoto,
                FoodPrice = model.FoodPrice,
            };
        }
    }
}