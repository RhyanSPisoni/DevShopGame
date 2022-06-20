using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Enterprise")]
    public partial class Enterprise
    {
        [Key]
        public int Id_Enterprise { get; set; }
        public string? Nm_Enterprise { get; set; }
        public Product? Product { get; set; }
    }
}
