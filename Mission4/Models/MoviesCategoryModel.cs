using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission4.Models
{
    public class MoviesCategoryModel
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string Category { get; set; }
    }
}
