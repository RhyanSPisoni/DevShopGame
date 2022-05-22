using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.DTOs.ModelsDto
{
    public partial class ClientDTO
    {
        public int IdClient { get; set; }
        public string NmClient { get; set; }
        public string NmMail { get; set; }
        public string VlCpf { get; set; }
        public string NmNick { get; set; }
        public string VlPassword { get; set; }
        public DateTime DtRegistration { get; set; }
        public int FlActive { get; set; }
    }
}
