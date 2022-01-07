using System;
using System.Collections.Generic;

#nullable disable

namespace ShopGames.Views
{
    public class ClientView
    {
        public int IdClient { get; set; }
        public string NmClient { get; set; }
        public string NmMail { get; set; }
        public string VlCpf { get; set; }
        public string NmNick { get; set; }
        public string VlPassword { get; set; }
        public byte[] DtRegistration { get; set; }
        public int Active { get; set; } = 1;

    }
}
