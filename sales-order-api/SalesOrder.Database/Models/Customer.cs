using SalesOrder.Database.Models.Utilities;

namespace SalesOrder.Database.Models
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

        #endregion Properties
    }
}