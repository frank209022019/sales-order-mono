using SalesOrder.Shared.Models.Utilities;

namespace SalesOrder.Shared.Models
{
    public class Category : IIdentify, IAudit, IState
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

        public string CategoryCode { get; set; }

        public string Description { get; set; }

        #endregion Properties

        #region Navigation

        public virtual List<Order> Orders { get; set; }

        #endregion Navigation
    }
}