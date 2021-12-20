using System;

namespace Pelikula.API.Model.Izvjestaj
{
    public class IzvjestajOdnosOnlineInstore
    {
        public string Tip{ get; set; }

        public int Count { get; set; }

        public static class IzvjestajOdnosOnlineInstoreTip
        {
            public static readonly string ONLINE = "Online";
            public static readonly string IN_STORE = "In store";
        }
    }

    
}
