using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuanLyDoAn.Models
{
    public partial class QuanLyDoAnContext : DbContext
    {
        public QuanLyDoAnContext()
        {
        }

        public QuanLyDoAnContext(DbContextOptions<QuanLyDoAnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<GiangVienInfo> GiangVienInfos { get; set; }
        public virtual DbSet<GiangVienInfo1> GiangVienInfo1s { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<QuanLyDeTai> QuanLyDeTais { get; set; }
        public virtual DbSet<UserAdmin> UserAdmins { get; set; }
        public virtual DbSet<UserSinhVien> UserSinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N9VPULG;Database=QuanLyDoAn;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<GiangVien>(entity =>
            {
                entity.HasKey(e => e.IdGv);

                entity.ToTable("GiangVien");

                entity.Property(e => e.IdGv).HasColumnName("idGV");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdKhoa).HasColumnName("idKhoa");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.TenGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenGV");

                entity.HasOne(d => d.IdKhoaNavigation)
                    .WithMany(p => p.GiangViens)
                    .HasForeignKey(d => d.IdKhoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_khoa");
            });

            modelBuilder.Entity<GiangVienInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GiangVienInfo");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.TenGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenGV");
            });

            modelBuilder.Entity<GiangVienInfo1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GiangVienInfo1");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.TenGv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenGV");

                entity.Property(e => e.TenKhoa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenKhoa");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.IdKhoa);

                entity.ToTable("Khoa");

                entity.Property(e => e.IdKhoa).HasColumnName("idKhoa");

                entity.Property(e => e.TenKhoa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenKhoa");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.IdLop);

                entity.ToTable("Lop");

                entity.Property(e => e.IdLop).HasColumnName("idLop");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grade");
            });

            modelBuilder.Entity<QuanLyDeTai>(entity =>
            {
                entity.HasKey(e => e.IdDeTai);

                entity.ToTable("quanLyDeTai");

                entity.Property(e => e.IdDeTai).HasColumnName("idDeTai");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.FileBaoCao)
                    .IsRequired()
                    .HasColumnName("fileBaoCao");

                entity.Property(e => e.FileMaNguon)
                    .IsRequired()
                    .HasColumnName("fileMaNguon");

                entity.Property(e => e.IdGv).HasColumnName("idGV");

                entity.Property(e => e.MoTa)
                    .IsRequired()
                    .HasColumnName("moTa");

                entity.Property(e => e.Msv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("msv");

                entity.Property(e => e.TenDeTai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenDeTai");

                entity.HasOne(d => d.IdGvNavigation)
                    .WithMany(p => p.QuanLyDeTais)
                    .HasForeignKey(d => d.IdGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gv");

                entity.HasOne(d => d.MsvNavigation)
                    .WithMany(p => p.QuanLyDeTais)
                    .HasForeignKey(d => d.Msv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_msv");
            });

            modelBuilder.Entity<UserAdmin>(entity =>
            {
                entity.ToTable("userAdmin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserSinhVien>(entity =>
            {
                entity.HasKey(e => e.Msv);

                entity.ToTable("userSinhVien");

                entity.Property(e => e.Msv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("msv");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.BithDate)
                    .HasColumnType("date")
                    .HasColumnName("bithDate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IdLop).HasColumnName("idLop");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.IdLopNavigation)
                    .WithMany(p => p.UserSinhViens)
                    .HasForeignKey(d => d.IdLop)
                    .HasConstraintName("FK_lop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
