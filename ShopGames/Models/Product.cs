using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class Product
    {
        public Product()
        {
            LibraryUsers = new HashSet<LibraryUser>();
            ProductSystemReqs = new HashSet<ProductSystemReq>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int IdProduct { get; set; }
        public decimal VlPrice { get; set; }
        public string NmProduct { get; set; }
        public decimal? VlDiscount { get; set; }
        public int VlProdcount { get; set; }
        public string DsText { get; set; }
        public int VlAvaliation { get; set; }
        public int IdDeveloper { get; set; }
        public int IdProvider { get; set; }
        public int IdCategory { get; set; }
        public DateTime DtLauncher { get; set; }
        public int FlActive { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual Enterprise IdDeveloperNavigation { get; set; }
        public virtual Enterprise IdProviderNavigation { get; set; }
        public virtual ICollection<LibraryUser> LibraryUsers { get; set; }
        public virtual ICollection<ProductSystemReq> ProductSystemReqs { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
