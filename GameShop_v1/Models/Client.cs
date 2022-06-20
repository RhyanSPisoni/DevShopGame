using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace GameShop.Models
{
    [Table("Client")]
    public partial class Client
    {
        [Key]
        public int Id_Client { get; set; }
        public string? Nm_Client { get; set; }
        public string? Nm_Mail { get; set; }
        public string? Vl_Cpf { get; set; }
        public string? Nm_Nick { get; set; }
        public string? Vl_Password { get; set; }
        public DateTime? Dt_Registration { get; set; } = DateTime.Now;
        public List<ShoppingCart>? ShoppingCart { get; set; }
        public List<LibraryUser>? LibraryUser { get; set; }
    }
}
