using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class Mobil
    {
        public Mobil()
        {
            Peminjamen = new HashSet<Peminjaman>();
        }

        public int IdMobil { get; set; }
        public string NoPlat { get; set; }
        public int? IdJenisMobil { get; set; }
        public string TahunMobil { get; set; }
        public string WarnaMobil { get; set; }

        public virtual JenisMobil IdJenisMobilNavigation { get; set; }
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }
}
