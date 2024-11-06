using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThueDat.Authorization.Users;

namespace ThueDat.Core.Entities
{
    public class ThueDatAudit : Entity<int>, IModificationAudited, IHasDeletionTime
    {
        public long? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(LastModifierUserId))]
        public User LastModifierUser { get; set; }
    }
}
