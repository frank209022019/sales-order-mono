﻿using System.ComponentModel.DataAnnotations;

namespace SalesOrder.Database.Models.Utilities
{
    public interface IIdentify
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}