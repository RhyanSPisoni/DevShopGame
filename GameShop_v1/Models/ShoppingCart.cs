using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Shopping_Cart")]
    public partial class ShoppingCart
    {
        [Key]
        public int Id_Shop { get; set; }
        public Client? Client { get; set; }
        public int? Id_Client { get; set; }
        public int? Id_Product { get; set; }
        public Product? Product { get; set; }
        public bool? fl_situation { get; set; } = true;
    }
}
