using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("System_Requirement")]
    public partial class SystemRequirement
    {
        [Key]
        public int Id_System_Requirement { get; set; }
        public string? Nm_Required { get; set; }
        public List<ProductSystemReq>? ProductSystemReq { get; set; }
    }
}
