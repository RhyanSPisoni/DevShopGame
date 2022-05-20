using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Models
{
    public partial class SystemRequirement
    {
        public SystemRequirement()
        {
            ProductSystemReqs = new HashSet<ProductSystemReq>();
        }

        public int IdSystemRequirement { get; set; }
        public string NmRequired { get; set; }
        public int FlActive { get; set; }

        public virtual ICollection<ProductSystemReq> ProductSystemReqs { get; set; }
    }
}
