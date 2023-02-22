namespace SalesOrder.Service.Helpers
{
    public static class OrderHelper
    {
        /// <summary>
        /// Generates a random 10 character string with the current date included.
        /// </summary>
        public static string GenerateOrderCode()
        {
            // Generate a random 10-letter string
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomString = new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // Get the current date in the format yyyyMMdd
            string date = DateTime.Today.ToString("yyyyMMdd").ToUpper();

            // Combine the random string and the date to create the order code
            string orderCode = $"{randomString}{date}";

            return orderCode;
        }
    }
}