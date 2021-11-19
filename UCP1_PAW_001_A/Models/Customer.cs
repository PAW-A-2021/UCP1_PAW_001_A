using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Peminjamen = new HashSet<Peminjaman>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string NoHp { get; set; }
        public string Alamat { get; set; }
        public string Umur { get; set; }
        public int? IdPembayaran { get; set; }
        public int? IdPeminjaman { get; set; }

        public virtual Pembayaran IdPembayaranNavigation { get; set; }
        public virtual ICollection<Peminjaman> Peminjamen { get; set; }
    }
}
