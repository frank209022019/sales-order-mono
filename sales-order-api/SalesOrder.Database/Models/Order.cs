using SalesOrder.Database.Models.Utilities;

namespace SalesOrder.Database.Models
{
    #region Order

    public class Order : IIdentify, IAudit, IState
    {
        #region Model-Base

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid CreatedById { get; set; }
        public Guid? ModifiedById { get; set; }
        public Guid? DeletedById { get; set; }
        public bool IsActive { get; set; }

        #endregion Model-Base

        #region Properties

        public string OrderCode { get; set; }
        public int ProductTotal { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }

        #endregion Properties

        #region Navigation

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }

        #endregion Navigation
    }

    #endregion Order

    #region Order-Product

    public class OrderProduct : IIdentify, IAudit, IState
    {
        #region Model-Base

        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid CreatedById { get; set; }
        public Guid? ModifiedById { get; set; }
        public Guid? DeletedById { get; set; }
        public bool IsActive { get; set; }

        #endregion Model-Base

        #region Properties

        public int Quantity { get; set; }
        public decimal CurrentProductPrice { get; set; } //  Includes VAT
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        public string VAT { get; set; }

        #endregion Properties

        #region Navigation

        //public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        //public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        #endregion Navigation
    }

    #endregion Order-Product
}