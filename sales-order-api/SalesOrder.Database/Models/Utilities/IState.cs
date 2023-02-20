using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Database.Models.Utilities
{
    public interface IState
    {
        [Required]
        public bool IsActive { get; set; }
    }
}