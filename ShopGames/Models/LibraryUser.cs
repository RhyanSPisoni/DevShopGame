using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class LibraryUser
    {
        public int IdLibrary { get; set; }
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public byte[] DtRegistration { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
