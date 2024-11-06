using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("quyet_dinh_cho_thue_dat")]
public class QuyetDinhChoThueDat : ThueDatAudit
{
    [Required]
    [StringLength(50)]
    public string SoQuyetDinh { get; set; }

    public DateOnly? Ngay { get; set; }

    public float? DienTich { get; set; }

    [StringLength(250)]
    public string DiaChi { get; set; }

    public DateOnly? NgayBatDauThue { get; set; }

    public DateOnly? NgayHetHanThue { get; set; }

    //[Column(TypeName = "enum('Trả tiền hàng năm','Trả tiền một lần')")]
    public CacHinhThucTraTien? HinhThucTraTien { get; set; }

    [StringLength(14)]
    public string MaSoThue { get; set; }

    public virtual ICollection<HinhAnh> HinhAnhs { get; set; } = new List<HinhAnh>();

    [ForeignKey("MaSoThue")]
    public virtual NguoiNopThue MaSoThueNavigation { get; set; }

    public virtual ICollection<ThongBaoDonGiaThueDat> ThongBaoDonGiaThueDats { get; set; } = new List<ThongBaoDonGiaThueDat>();

    public virtual ICollection<ThuaDat> ThuaDats { get; set; } = new List<ThuaDat>();
}

public enum CacHinhThucTraTien
{
    [Description("Trả tiền hàng năm")]
    TraTienHangNam = 0,
    [Description("Trả tiền một lần")]
    TraTienMotLan = 1
}