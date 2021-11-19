using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class JenisMobil
    {
        public JenisMobil()
        {
            Mobils = new HashSet<Mobil>();
        }

        public int IdJenisMobil { get; set; }
        public string NamaJenisMobil { get; set; }

        public virtual ICollection<Mobil> Mobils { get; set; }
    }
}
