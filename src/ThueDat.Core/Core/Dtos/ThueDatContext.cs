//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
////using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

//namespace ThueDat;

//public partial class ThueDatContext : DbContext
//{
//    public ThueDatContext()
//    {
//    }

//    public ThueDatContext(DbContextOptions<ThueDatContext> options)
//        : base(options)
//    {
//    }


//    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

//    public virtual DbSet<HinhAnh> HinhAnhs { get; set; }

//    public virtual DbSet<NguoiNopThue> NguoiNopThues { get; set; }

//    public virtual DbSet<PhuongXa> PhuongXas { get; set; }

//    public virtual DbSet<QuanHuyen> QuanHuyens { get; set; }

//    public virtual DbSet<QuyetDinhChoThueDat> QuyetDinhChoThueDats { get; set; }

//    public virtual DbSet<ThongBaoDonGiaThueDat> ThongBaoDonGiaThueDats { get; set; }

//    public virtual DbSet<ThongBaoThuHangNam> ThongBaoThuHangNams { get; set; }

//    public virtual DbSet<ThuaDat> ThuaDats { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;port=3306;database=thue_dat;user=lozg;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder
//            .UseCollation("utf8mb4_0900_ai_ci")
//            .HasCharSet("utf8mb4");


//        modelBuilder.Entity<Efmigrationshistory>(entity =>
//        {
//            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");
//        });

//        modelBuilder.Entity<HinhAnh>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.SoQuyetDinhNavigation).WithMany(p => p.HinhAnhs)
//                .HasPrincipalKey(p => p.SoQuyetDinh)
//                .HasForeignKey(d => d.SoQuyetDinh)
//                .HasConstraintName("FK_QDCTD_HA_SQD");
//        });

//        modelBuilder.Entity<NguoiNopThue>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");
//        });

//        modelBuilder.Entity<PhuongXa>(entity =>
//        {
//            entity.HasKey(e => e.MaPx).HasName("PRIMARY");

//            entity.Property(e => e.MaPx).ValueGeneratedNever();

//            entity.HasOne(d => d.MaQhNavigation).WithMany(p => p.PhuongXas).HasConstraintName("FK_QH_PX_MQH");
//        });

//        modelBuilder.Entity<QuanHuyen>(entity =>
//        {
//            entity.HasKey(e => e.MaQh).HasName("PRIMARY");

//            entity.Property(e => e.MaQh).ValueGeneratedNever();
//        });

//        modelBuilder.Entity<QuyetDinhChoThueDat>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasOne(d => d.MaSoThueNavigation).WithMany(p => p.QuyetDinhChoThueDats)
//                .HasPrincipalKey(p => p.MaSoThue)
//                .HasForeignKey(d => d.MaSoThue)
//                .HasConstraintName("FK_NNT_QDCTD_MST");
//        });

//        modelBuilder.Entity<ThongBaoDonGiaThueDat>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasOne(d => d.SoQuyetDinhNavigation).WithMany(p => p.ThongBaoDonGiaThueDats)
//                .HasPrincipalKey(p => p.SoQuyetDinh)
//                .HasForeignKey(d => d.SoQuyetDinh)
//                .HasConstraintName("FK_TD_QDCTD_SQD");

//            entity.HasOne(d => d.ThuaDatSoNavigation).WithMany(p => p.ThongBaoDonGiaThueDats)
//                .HasPrincipalKey(p => p.ThuaDatSo)
//                .HasForeignKey(d => d.ThuaDatSo)
//                .HasConstraintName("FK_TD_TBDGTD_TDS");
//        });

//        modelBuilder.Entity<ThongBaoThuHangNam>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.MaSoThueNavigation).WithMany(p => p.ThongBaoThuHangNams)
//                .HasPrincipalKey(p => p.MaSoThue)
//                .HasForeignKey(d => d.MaSoThue)
//                .HasConstraintName("FK_NNT_TBTHN_MST");
//        });

//        modelBuilder.Entity<ThuaDat>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PRIMARY");

//            entity.HasOne(d => d.SoQuyetDinhNavigation).WithMany(p => p.ThuaDats)
//                .HasPrincipalKey(p => p.SoQuyetDinh)
//                .HasForeignKey(d => d.SoQuyetDinh)
//                .HasConstraintName("FK_QDCTD_TD_SQD");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
