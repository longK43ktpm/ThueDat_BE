using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ThueDat.Authorization.Roles;
using ThueDat.Authorization.Users;
using ThueDat.MultiTenancy;
using System.Reflection.Emit;
using ThueDat.Core.Entities;

namespace ThueDat.EntityFrameworkCore
{
    public class ThueDatDbContext : AbpZeroDbContext<Tenant, Role, User, ThueDatDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<HinhAnh> HinhAnhs { get; set; }

        public DbSet<NguoiNopThue> NguoiNopThues { get; set; }

        public DbSet<PhuongXa> PhuongXas { get; set; }

        public DbSet<QuanHuyen> QuanHuyens { get; set; }

        public DbSet<QuyetDinhChoThueDat> QuyetDinhChoThueDats { get; set; }

        public DbSet<ThongBaoDonGiaThueDat> ThongBaoDonGiaThueDats { get; set; }

        public DbSet<ThongBaoThuHangNam> ThongBaoThuHangNams { get; set; }

        public DbSet<ThuaDat> ThuaDats { get; set; }

        public ThueDatDbContext(DbContextOptions<ThueDatDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<HinhAnh>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.SoQuyetDinhNavigation).WithMany(p => p.HinhAnhs)
                    .HasPrincipalKey(p => p.SoQuyetDinh)
                    .HasForeignKey(d => d.SoQuyetDinh)
                    .HasConstraintName("FK_QDCTD_HA_SQD");
            })
            .UseCollation("utf8mb4_bin");

            modelBuilder.Entity<QuyetDinhChoThueDat>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.MaSoThueNavigation).WithMany(p => p.QuyetDinhChoThueDats)
                    .HasPrincipalKey(p => p.MaSoThue)
                    .HasForeignKey(d => d.MaSoThue)
                    .HasConstraintName("FK_NNT_QDCTD_MST");
            })
            ;

            modelBuilder.Entity<ThongBaoDonGiaThueDat>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.SoQuyetDinhNavigation).WithMany(p => p.ThongBaoDonGiaThueDats)
                    .HasPrincipalKey(p => p.SoQuyetDinh)
                    .HasForeignKey(d => d.SoQuyetDinh)
                    .HasConstraintName("FK_TD_QDCTD_SQD");

                entity.HasOne(d => d.ThuaDatSoNavigation).WithMany(p => p.ThongBaoDonGiaThueDats)
                    .HasPrincipalKey(p => p.ThuaDatSo)
                    .HasForeignKey(d => d.ThuaDatSo)
                    .HasConstraintName("FK_TD_TBDGTD_TDS");
            })
            ;

            modelBuilder.Entity<ThongBaoThuHangNam>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.MaSoThueNavigation).WithMany(p => p.ThongBaoThuHangNams)
                    .HasPrincipalKey(p => p.MaSoThue)
                    .HasForeignKey(d => d.MaSoThue)
                    .HasConstraintName("FK_NNT_TBTHN_MST");
            })
            ;

            modelBuilder.Entity<ThuaDat>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasOne(d => d.SoQuyetDinhNavigation).WithMany(p => p.ThuaDats)
                    .HasPrincipalKey(p => p.SoQuyetDinh)
                    .HasForeignKey(d => d.SoQuyetDinh)
                    .HasConstraintName("FK_QDCTD_TD_SQD");
            })
            ;

            base.OnModelCreating(modelBuilder);
        }

    }
}
