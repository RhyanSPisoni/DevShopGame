using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class ProductSystemReq
    {
        public int IdProductSystemReq { get; set; }
        public int IdProduct { get; set; }
        public int IdSystemRequirement { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual SystemRequirement IdSystemRequirementNavigation { get; set; }
    }
}
