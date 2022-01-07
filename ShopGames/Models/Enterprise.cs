using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class Enterprise
    {
        public Enterprise()
        {
            ProductIdDeveloperNavigations = new HashSet<Product>();
            ProductIdProviderNavigations = new HashSet<Product>();
        }

        public int IdEnterprise { get; set; }
        public string NmEnterprise { get; set; }
        public int FlActive { get; set; }

        public virtual ICollection<Product> ProductIdDeveloperNavigations { get; set; }
        public virtual ICollection<Product> ProductIdProviderNavigations { get; set; }
    }
}
