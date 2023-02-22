using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Shared.Models.Utilities
{
    public interface IIdentify
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}