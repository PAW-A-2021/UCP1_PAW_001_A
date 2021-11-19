using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_001_A.Models
{
    public partial class UCPRentMoContext : DbContext
    {
        public UCPRentMoContext()
        {
        }

        public UCPRentMoContext(DbContextOptions<UCPRentMoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<JenisMobil> JenisMobils { get; set; }
        public virtual DbSet<Mobil> Mobils { get; set; }
        public virtual DbSet<Pembayaran> Pembayarans { get; set; }
        public virtual DbSet<Peminjaman> Peminjamen { get; set; }
        public virtual DbSet<Pengembalian> Pengembalians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdPembayaran).HasColumnName("ID_Pembayaran");

                entity.Property(e => e.IdPeminjaman).HasColumnName("ID_Peminjaman");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");

                entity.Property(e => e.Umur)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPembayaranNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdPembayaran)
                    .HasConstraintName("FK_Customer_Pembayaran");
            });

            modelBuilder.Entity<JenisMobil>(entity =>
            {
                entity.HasKey(e => e.IdJenisMobil);

                entity.ToTable("Jenis_Mobil");

                entity.Property(e => e.IdJenisMobil)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Jenis_Mobil");

                entity.Property(e => e.NamaJenisMobil)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Jenis_Mobil");
            });

            modelBuilder.Entity<Mobil>(entity =>
            {
                entity.HasKey(e => e.IdMobil);

                entity.ToTable("Mobil");

                entity.Property(e => e.IdMobil)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Mobil");

                entity.Property(e => e.IdJenisMobil).HasColumnName("ID_Jenis_Mobil");

                entity.Property(e => e.NoPlat)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("No_Plat");

                entity.Property(e => e.TahunMobil)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Tahun_Mobil");

                entity.Property(e => e.WarnaMobil)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Warna_Mobil");

                entity.HasOne(d => d.IdJenisMobilNavigation)
                    .WithMany(p => p.Mobils)
                    .HasForeignKey(d => d.IdJenisMobil)
                    .HasConstraintName("FK_Mobil_Jenis_Mobil");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.ToTable("Pembayaran");

                entity.Property(e => e.IdPembayaran)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pembayaran");

                entity.Property(e => e.JenisPembayaran)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Pembayaran");

                entity.Property(e => e.TanggalPembayaran)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Pembayaran");

                entity.Property(e => e.TotalPembayaran)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Total_Pembayaran");
            });

            modelBuilder.Entity<Peminjaman>(entity =>
            {
                entity.HasKey(e => e.IdPeminjaman);

                entity.ToTable("Peminjaman");

                entity.Property(e => e.IdPeminjaman)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Peminjaman");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdMobil).HasColumnName("ID_Mobil");

                entity.Property(e => e.TanggalPeminjaman)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Peminjaman");

                entity.Property(e => e.TotalPembayaran)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Total_Pembayaran");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Peminjamen)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Peminjaman_Customer");

                entity.HasOne(d => d.IdMobilNavigation)
                    .WithMany(p => p.Peminjamen)
                    .HasForeignKey(d => d.IdMobil)
                    .HasConstraintName("FK_Peminjaman_Mobil");
            });

            modelBuilder.Entity<Pengembalian>(entity =>
            {
                entity.HasKey(e => e.IdPengembalian);

                entity.ToTable("Pengembalian");

                entity.Property(e => e.IdPengembalian)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pengembalian");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdPeminjaman).HasColumnName("ID_Peminjaman");

                entity.Property(e => e.KondisiKendaraan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Kondisi_Kendaraan");

                entity.Property(e => e.TanggalPengembalian)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Pengembalian");

                entity.HasOne(d => d.IdPeminjamanNavigation)
                    .WithMany(p => p.Pengembalians)
                    .HasForeignKey(d => d.IdPeminjaman)
                    .HasConstraintName("FK_Pengembalian_Peminjaman");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
