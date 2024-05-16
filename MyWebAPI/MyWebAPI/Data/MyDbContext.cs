using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new
                {
                    e.MaDH,
                    e.MaHH
                });
                entity.HasOne(e => e.DonHang)
                .WithMany(entity => entity.DonHangChiTiets)
                .HasForeignKey(e => e.MaDH)
                .HasConstraintName("FK_DonHangCT_DonHang");
                entity.HasOne(e => e.HangHoa)
                .WithMany(entity => entity.DonHangChiTiets)
                .HasForeignKey(e => e.MaHH)
                .HasConstraintName("FK_DonHangCT_HangHoa");
            
            });
            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.HoTen).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(130);
            });
        }
    }
}
