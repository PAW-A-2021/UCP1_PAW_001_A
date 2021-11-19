using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class Pembayaran
    {
        public Pembayaran()
        {
            Customers = new HashSet<Customer>();
        }

        public int IdPembayaran { get; set; }
        public DateTime? TanggalPembayaran { get; set; }
        public string JenisPembayaran { get; set; }
        public string TotalPembayaran { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
