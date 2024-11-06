using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("phuong_xa")]
public class PhuongXa
{
    [Key]
    public int MaPX { get; set; }

    [StringLength(50)]
    public string Ten { get; set; }

    public int? MaQH { get; set; }

    [ForeignKey("MaQH")]
    public virtual QuanHuyen MaQHNavigation { get; set; }
}
