namespace SalesOrder.Shared.Utilities
{
    public class SalesOrderContstants
    {
        #region Database

        public static readonly string DevConnectionStringName = "SalesOrderDEVConnectionString";

        #endregion Database

        #region Users

        public static readonly Guid UserId1 = new("418eca24-a89f-4310-a8a0-6d12dd96dc6a");

        public static readonly string UserCode1 = "USR#1";


        #endregion Users

        #region Categories
        public static readonly Guid CategoryId1 = new("0a027927-135d-4ac0-b55d-efb28d0118e4");
        public static readonly Guid CategoryId2 = new("d6fbcfc5-e4dd-4b66-8098-d56f5e1408a6");
        public static readonly Guid CategoryId3 = new("42be8c07-c7e6-4582-a980-918e769f809d");

        public static readonly string CategoryCode1 = "CAT#1";
        public static readonly string CategoryCode2 = "CAT#2";
        public static readonly string CategoryCode3 = "CAT#3";

        #endregion Categories

        #region Customers

        public static readonly Guid CustomerId1 = new("46798df4-d5b9-4dd8-95a0-f8f8bfb172f8");
        public static readonly Guid CustomerId2 = new("892228bf-8380-419d-9518-a310f74e30c5");

        public static readonly string CustomerCode1 = "CUS#1";
        public static readonly string CustomerCode2 = "CUS#2";

        #endregion Customers

        #region Products
        public static readonly Guid ProductId1 = new("7d0bcb8d-e459-4885-975a-588741fe1905");
        public static readonly Guid ProductId2 = new("760f4974-68d6-4403-aff6-29ef670abd01");
        public static readonly Guid ProductId3 = new("4194ff3b-0c2d-456b-8314-08f7ee3bc8e0");

        public static readonly string ProductCode1 = "PROD#1";
        public static readonly string ProductCode2 = "PROD#2";
        public static readonly string ProductCode3 = "PROD#3";

        #endregion
    }
}