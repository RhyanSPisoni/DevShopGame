using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class Client
    {
        public Client()
        {
            LibraryUsers = new HashSet<LibraryUser>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int IdClient { get; set; }
        public string NmClient { get; set; }
        public string NmMail { get; set; }
        public string VlCpf { get; set; }
        public string NmNick { get; set; }
        public string VlPassword { get; set; }
        public DateTime DtRegistration { get; set; } = DateTime.Now;
        public int FlActive { get; set; }

        public virtual ICollection<LibraryUser> LibraryUsers { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
