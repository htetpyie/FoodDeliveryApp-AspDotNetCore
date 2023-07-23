using Newtonsoft.Json;

namespace FoodDeliveryApp.Features.Food
{
    public class FoodService
    {
        public List<FoodCategoryModel> FoodCategoryList =>
            Get<FoodCategoryModel>(JsonData.FoodCategory) ?? new();

        public FoodPaginationResponseModel FoodList(
           FoodPaginationRequestModel request)
        {
            List<FoodModel> foodList = Get<FoodModel>(JsonData.Food) ?? new();
            var response = GetPaginationResponse(foodList, request);
            return response;

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
                TotalPageNo = totalPages
            };
        }
    }
    public static class JsonData
    {
        public static string Food { get; } = @" [
        {
          ""FoodId"": 1,
          ""FoodName"": ""Chicken Burger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 5,
          ""FoodName"": ""Cheese Burger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 6,
          ""FoodName"": ""Royal Cheese Burger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 10,
          ""FoodName"": ""Classic Hamburger"",
          ""FoodPrice"": 24,
          ""FoodCategory"": 1
        },
        {
          ""FoodId"": 2,
          ""FoodName"": ""Vegetarian Pizza"",
          ""FoodPrice"": 115,
          ""FoodCategory"": 2
        },
        {
          ""FoodId"": 3,
          ""FoodName"": ""Double Cheese Margherita"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },
        {
          ""FoodId"": 7,
          ""FoodName"": ""Maxican Green Wave"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 8,
          ""FoodName"": ""Seafood Pizza"",
          ""FoodPrice"": 115,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 9,
          ""FoodName"": ""Thin Cheese Pizza"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 4,
          ""FoodName"": ""Pizza With Mushroom"",
          ""FoodPrice"": 110,
          ""FoodCategory"": 2
        },{
          ""FoodId"": 11,
          ""FoodName"": ""Crunchy Bread"",
          ""FoodPrice"": 35,
          ""FoodCategory"": 3
        },
        {
          ""FoodId"": 12,
          ""FoodName"": ""Delicious Bread"",
          ""FoodPrice"": 35,
          ""FoodCategory"": 3
        },
        {
          ""FoodId"": 13,
          ""FoodName"": ""Loaf Bread"",
          ""FoodPrice"": 35,
          ""FoodCategory"": 3
        }
        ]";

        public static string FoodCategory { get; } = @"[
        {
            ""CategoryId"": 1,
            ""CategoryName"": ""Burger""
        },
        {
            ""CategoryId"": 2,
            ""CategoryName"": ""Pizzia""
        },
        {
            ""CategoryId"": 3,
            ""CategoryName"": ""Bread""
        }
        ]";
    }


}
