using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("thua_dat")]
public class ThuaDat : ThueDatAudit
{
    [Required]
    [StringLength(50)]
    public string ThuaDatSo { get; set; }

    [StringLength(50)]
    public string ToBanDoSo { get; set; }

    [StringLength(250)]
    public string DiaChi { get; set; }

    [StringLength(15)]
    public string SoNha { get; set; }

    [StringLength(100)]
    public string ToaNha { get; set; }

    [Column("Ngo/Hem")]
    [StringLength(50)]
    public string NgoHem { get; set; }

    [Column("Duong/Pho")]
    [StringLength(50)]
    public string DuongPho { get; set; }

    [Column("Thon/Xom/Ap")]
    [StringLength(50)]
    public string ThonXomAp { get; set; }

    [Column("Phuong/Xa")]
    [StringLength(50)]
    public string PhuongXa { get; set; }

    [Column("Quan/Huyen")]
    [StringLength(50)]
    public string QuanHuyen { get; set; }

    [Column("Tinh/ThanhPho")]
    [StringLength(50)]
    public string TinhThanhPho { get; set; }

    [StringLength(250)]
    public string DoanDuong { get; set; }

    [StringLength(50)]
    public string MucDichSuDung { get; set; }

    [StringLength(100)]
    public string NguonGoc { get; set; }

    [Column("ThoiHanThue(nam)")]
    public int? ThoiHanThueNam { get; set; }

    [StringLength(250)]
    public string ViTriThuaDat { get; set; }

    [Column("DienTichDatThue(m2)", TypeName = "float unsigned")]
    public float? DienTichDatThueM2 { get; set; }

    [Column(TypeName = "float unsigned")]
    public float? DienTichNopTien { get; set; }

    [Column(TypeName = "float unsigned")]
    public float? DienTichKhongNopTien { get; set; }

    [StringLength(50)]
    public string ToaDo { get; set; }

    [StringLength(50)]
    public string SoQuyetDinh { get; set; }

    [ForeignKey("SoQuyetDinh")]
    public virtual QuyetDinhChoThueDat SoQuyetDinhNavigation { get; set; }

    public virtual ICollection<ThongBaoDonGiaThueDat> ThongBaoDonGiaThueDats { get; set; } = new List<ThongBaoDonGiaThueDat>();
}
