using SalesOrder.Database.Models.Utilities;

namespace SalesOrder.Database.Models
{
    public class Product : IIdentify, IAudit, IState
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

        public string ProductCode { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion Properties

        #region Navigation

        public ICollection<OrderProduct> OrderProducts { get; set; }

        #endregion Navigation
    }
}