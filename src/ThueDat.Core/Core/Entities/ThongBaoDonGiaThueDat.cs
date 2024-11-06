using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("thong_bao_don_gia_thue_dat")]
public class ThongBaoDonGiaThueDat : ThueDatAudit
{
    [Required]
    [StringLength(50)]
    public string SoThongBao { get; set; }

    public DateOnly? GhiThuTu { get; set; }

    public DateOnly? GhiThuDen { get; set; }

    public DateOnly? OnDinhDGTu { get; set; }

    public DateOnly? OnDinhDGDen { get; set; }

    [Column(TypeName = "float unsigned")]
    public float? DienTich { get; set; }

    [Column(TypeName = "decimal(16,2) unsigned")]
    public decimal? DonGia { get; set; }

    [Precision(16, 2)]
    public decimal? TienGhiThu { get; set; }

    [StringLength(50)]
    public string ThuaDatSo { get; set; }

    [StringLength(50)]
    public string SoQuyetDinh { get; set; }

    [ForeignKey("SoQuyetDinh")]
    public virtual QuyetDinhChoThueDat SoQuyetDinhNavigation { get; set; }

    [ForeignKey("ThuaDatSo")]
    public virtual ThuaDat ThuaDatSoNavigation { get; set; }
}
