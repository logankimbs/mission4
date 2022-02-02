using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission4.Models
{
    public class MoviesModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public MoviesCategoryModel Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string Lent_To { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
