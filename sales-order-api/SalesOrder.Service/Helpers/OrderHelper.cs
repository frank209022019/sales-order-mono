namespace SalesOrder.Service.Helpers
{
    public static class OrderHelper
    {
        /// <summary>
        /// Generates a random 10 character string
        /// </summary>
        public static string GenerateOrderCode()
        {
            // Generate a random 10-letter string
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomString = new string(Enumerable.Repeat(chars, 7)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // Combine the random string and the date to create the order code
            string orderCode = $"ORD{randomString}";

            return orderCode;
        }
    }
}