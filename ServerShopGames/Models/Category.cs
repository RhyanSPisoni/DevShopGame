using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string NmCategory { get; set; }
        public int FlActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
