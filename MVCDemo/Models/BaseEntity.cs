﻿using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
