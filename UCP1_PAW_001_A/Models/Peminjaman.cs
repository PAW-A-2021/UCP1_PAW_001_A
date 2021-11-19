using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class Peminjaman
    {
        public Peminjaman()
        {
            Pengembalians = new HashSet<Pengembalian>();
        }

        public int IdPeminjaman { get; set; }
        public DateTime? TanggalPeminjaman { get; set; }
        public int? IdMobil { get; set; }
        public int? IdCustomer { get; set; }
        public string TotalPembayaran { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Mobil IdMobilNavigation { get; set; }
        public virtual ICollection<Pengembalian> Pengembalians { get; set; }
    }
}
