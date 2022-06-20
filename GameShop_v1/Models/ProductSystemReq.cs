using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Product_System_Req")]
    public partial class ProductSystemReq
    {
        [Key]
        public int Id_Product_System_Req { get; set; }
        public int? Id_System_Requirement { get; set; }
        public SystemRequirement? SystemRequirement { get; set; }
        public int? Id_Product { get; set; }
        public Product? Product { get; set; }
    }
}
