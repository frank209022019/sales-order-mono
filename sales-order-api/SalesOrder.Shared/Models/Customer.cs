using SalesOrder.Shared.Models.Utilities;

namespace SalesOrder.Shared.Models
{
    public class Customer : IIdentify, IAudit, IState
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

        public string CustomerCode { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        #endregion Properties

        #region Navigation

        public virtual ICollection<Order> Orders { get; set; }

        #endregion Navigation
    }
}