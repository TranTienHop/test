using DTOs;
using Microsoft.EntityFrameworkCore;

namespace DALs
{
    // DbContext — scaffold kiểu Database First (EF Core Power Tools)
    public class TriThucBooksContext : DbContext
    {
        public DbSet<TheLoaiSach> TheLoaiSaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // LocalDB — chạy script TriThucBooks.sql trước nếu chưa có DB
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=TriThucBooks;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TheLoaiSach>(entity =>
            {
                entity.ToTable("TheLoaiSach");
                entity.HasKey(e => e.MaTL);
                entity.Property(e => e.MaTL).ValueGeneratedOnAdd();
                entity.Property(e => e.TenTheLoai).HasMaxLength(100).IsRequired();
                entity.HasIndex(e => e.TenTheLoai).IsUnique();
                entity.Property(e => e.MoTa).HasMaxLength(255);
                entity.Property(e => e.SoLuongSach).HasDefaultValue(0);
                entity.Property(e => e.NgayTao).HasDefaultValueSql("GETDATE()");
            });
        }
    }
}
