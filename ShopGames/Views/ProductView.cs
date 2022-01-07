using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Views
{
    public class ProductView
    {
        public int IdProduct { get; set; }
        public decimal VlPrice { get; set; }
        public string NmProduct { get; set; }
        public decimal? VlDiscount { get; set; }
        public int VlProdcount { get; set; }
        public string DsText { get; set; }
        public int VlAvaliation { get; set; }
        public string NmDeveloper { get; set; }
        public string NmProvider { get; set; }
        public string NmCategory { get; set; }
        public DateTime DtLauncher { get; set; }
        public int Active { get; set; }

    }
}
