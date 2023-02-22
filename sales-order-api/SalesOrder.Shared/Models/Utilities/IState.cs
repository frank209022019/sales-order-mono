using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Shared.Models.Utilities
{
    public interface IState
    {
        [Required]
        public bool IsActive { get; set; }
    }
}