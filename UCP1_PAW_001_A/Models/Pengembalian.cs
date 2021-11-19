using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class Pengembalian
    {
        public int IdPengembalian { get; set; }
        public DateTime? TanggalPengembalian { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdPeminjaman { get; set; }
        public string KondisiKendaraan { get; set; }

        public virtual Peminjaman IdPeminjamanNavigation { get; set; }
    }
}
