using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("nguoi_nop_thue")]
public class NguoiNopThue : ThueDatAudit
{
    [Required]
    [StringLength(14)]
    public string MaSoThue { get; set; }

    [Required]
    [StringLength(250)]
    public string Ten { get; set; }

    [StringLength(250)]
    public string DiaChi { get; set; }

    [StringLength(10)]
    public string SoDienThoai { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    //[Column(TypeName = "enum('Cá nhân','Tổ chức')")]
    public CacLoaiHinh? LoaiHinh { get; set; }

    public virtual ICollection<QuyetDinhChoThueDat> QuyetDinhChoThueDats { get; set; } = new List<QuyetDinhChoThueDat>();

    public virtual ICollection<ThongBaoThuHangNam> ThongBaoThuHangNams { get; set; } = new List<ThongBaoThuHangNam>();
}

public enum CacLoaiHinh
{
    [Description("Cá nhân")]
    CaNhan,
    [Description("Tổ chức")]
    ToChuc
}