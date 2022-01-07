using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class ShoppingCart
    {
        public int IdShop { get; set; }
        public int IdClient { get; set; }
        public int IdProduct { get; set; }
        public int FlSituation { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
