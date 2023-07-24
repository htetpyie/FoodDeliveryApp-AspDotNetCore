namespace FoodDeliveryApp
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || string.IsNullOrEmpty(value);
        }
    }
}