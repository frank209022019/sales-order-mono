using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Database.Models.Utilities
{
    public interface IAudit
    {
        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }

        [Required]
        public Guid CreatedById { get; set; }

        public Guid? ModifiedById { get; set; }
        public Guid? DeletedById { get; set; }
    }
}