using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Library_User")]
    public partial class LibraryUser
    {
        [Key]
        public int Id_Library { get; set; }
        public int? Id_Client { get; set; }
        public int? Id_Product { get; set; }
        public DateTime? Dt_Registration { get; set; } = DateTime.Now;
        public Product? Product { get; set;} 
        public Client? Client { get; set;} 
    }
}
