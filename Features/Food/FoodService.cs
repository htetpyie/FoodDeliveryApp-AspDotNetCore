using FoodDeliveryApp.DbService;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodDeliveryApp.Features.Food
{
    public class FoodService
    {
        private readonly LiteDbService _db;

        public FoodService(LiteDbService db)
        {
            _db = db;
        }

        public List<FoodCategoryModel> FoodCategoryList =>
            Get<FoodCategoryModel>(JsonData.FoodCategory) ?? new();

        public FoodModel GetFoodById(int id)
        {
            var foodList = Get<FoodModel>(JsonData.Food) ?? new();
            return foodList.FirstOrDefault(x => x.FoodId == id);
        }

        public FoodPaginationResponseModel FoodPagination(
           FoodPaginationRequestModel request)
        {
            List<FoodModel> foodList = Get<FoodModel>(JsonData.Food) ?? new();
            var response = GetPaginationResponse(foodList, request);
            return response;
        }

        public void AddedFoodToCart(FoodSaleDataModel food, int qty)
        {
            if (FoodExists(food.FoodId))
            {
                var foodData = GetFood(food.FoodId);
                int quantity = foodData.Qty + qty;
                foodData.Qty = quantity;

                if (quantity == 0)
                    _db.Delete<FoodSaleDataModel>(food.FoodId);

                else _db.Update(foodData);          
            }
            else
            {
                food.Qty = qty;
                _db.Insert<FoodSaleDataModel>(food);
            }
        }

        public FoodSaleDataModel GetFood(int id)
        {
            return _db.GetOne<FoodSaleDataModel>
                (x => x.FoodId == id);
        }

        public bool FoodExists(int id)
        {
            var food = _db.GetOne<FoodSaleDataModel>
                (x => x.FoodId == id);
            return food != null;
        }

        public List<FoodSaleDataModel> GetAddedFoodList()
        {
            var list = _db.GetList<FoodSaleDataModel>();
            return list;
        }

        public bool DeleteAddedFood(int id)
        {
            var isDeleted = _db.Delete<FoodSaleDataModel>(id);
            return isDeleted;
        }

        public int DeleteAddedFoods()
        {
            var result = _db.DeleteAll<FoodSaleDataModel>();
            return result;
        }

        public List<T>? Get<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<T>?>(jsonStr);
        }

        private FoodPaginationResponseModel GetPaginationResponse(
            List<FoodModel> list,
            FoodPaginationRequestModel request)
        {
            if (request.FoodCategoryId > 0)
            {
                list = list
                    .Where(x => x.FoodCategory == request.FoodCategoryId)
                    .ToList();
            }

            if (!request.SearchParam.IsNullOrEmpty())
            {
                string searchParam = request.SearchParam.Trim().ToLower();
                list = list
                    .Where(x =>
                        x.FoodName.ToLower()
                        .Contains(searchParam))
                    .ToList();
            }

            int count = list.Count;
            int totalPages = count / request.PageSize;
            if (count % request.PageSize > 0) totalPages++;

            list = list
                .Skip(request.Skip)
                .Take(request.PageSize)
                .ToList();

            return new FoodPaginationResponseModel
            {
                FoodList = list,
                TotalPageNo = totalPages,
                SearchParam = request.SearchParam,
                PageNo = request.PageNo,
            };
        }
    }


}
