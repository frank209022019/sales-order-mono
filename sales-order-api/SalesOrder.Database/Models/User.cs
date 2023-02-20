using SalesOrder.Database.Models.Utilities;

namespace SalesOrder.Database.Models
{
    public class User : IIdentify, IAudit, IState
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

        public string UserCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion Properties

        #region Navigation

        public virtual ICollection<Order> SalesOrders { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> SalesOrder { get; set; }

        #endregion Navigation
    }
}