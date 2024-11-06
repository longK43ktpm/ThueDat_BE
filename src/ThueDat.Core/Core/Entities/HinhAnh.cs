using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("hinh_anh")]
public class HinhAnh : ThueDatAudit
{
    [StringLength(250)]
    public string Path { get; set; }

    [StringLength(250)]
    public string MoTa { get; set; }

    [StringLength(50)]
    public string SoQuyetDinh { get; set; }

    [ForeignKey("SoQuyetDinh")]
    public virtual QuyetDinhChoThueDat SoQuyetDinhNavigation { get; set; }
}
