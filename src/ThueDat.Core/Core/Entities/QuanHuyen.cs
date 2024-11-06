using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ThueDat.Core.Entities;

[Table("quan_huyen")]
public class QuanHuyen
{
    [Key]
    public int MaQH { get; set; }

    [StringLength(50)]
    public string Ten { get; set; }

    public virtual ICollection<PhuongXa> PhuongXas { get; set; } = new List<PhuongXa>();
}
