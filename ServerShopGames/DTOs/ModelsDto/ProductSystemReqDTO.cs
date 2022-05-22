using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.DTOs.ModelsDto
{
    public partial class ProductSystemReqDTO
    {
        public int IdProductSystemReq { get; set; }
        public int IdProduct { get; set; }
        public int IdSystemRequirement { get; set; }
    }
}
