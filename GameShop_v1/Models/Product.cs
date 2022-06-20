using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Id_Product { get; set; }
        public decimal? Vl_Price { get; set; }
        public string? Nm_Product { get; set; }
        public decimal? Vl_Discount { get; set; }
        public int? Vl_Prodcount { get; set; }
        public string? Ds_Text { get; set; }
        public int? Vl_Avaliation { get; set; }
        public int? Id_Developer { get; set; }
        public int? Id_Provider { get; set; }
        public int? Id_Category { get; set; }
        public DateTime? Dt_Launcher { get; set; }
        public List<Enterprise>? Enterprise { get; set;} 
        public List<Category>? Category { get; set;} 
        public List<ProductSystemReq>? ProductSystemReq { get; set; }
        public List<ShoppingCart>? ShoppingCart { get; set; }
        public List<LibraryUser>? LibraryUser { get; set; }
    }
}
