using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int id_category { get; set; }
        public string? nm_category { get; set; }
        public Product? Product { get; set; }
    }
}
