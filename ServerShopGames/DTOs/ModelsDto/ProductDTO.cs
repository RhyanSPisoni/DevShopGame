using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.DTOs.ModelsDto
{
    public partial class ProductDTO
    {
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
        public virtual ICollection<ProductSystemReqDTO> ProductSystemReqs { get; set; }
    }
}
