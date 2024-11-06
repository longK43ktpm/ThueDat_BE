using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("thong_bao_thu_hang_nam")]
public class ThongBaoThuHangNam : ThueDatAudit
{
    [StringLength(50)]
    public string SoThongBao { get; set; }

    public DateOnly? ThoiGianGhiThuTu { get; set; }

    public DateOnly? ThoiGianGhiThuDen { get; set; }

    public int? SoThangGhiThu { get; set; }

    [StringLength(14)]
    public string MaSoThue { get; set; }

    [StringLength(50)]
    public string SoMienGiam { get; set; }

    [ForeignKey("MaSoThue")]
    public virtual NguoiNopThue MaSoThueNavigation { get; set; }
}
