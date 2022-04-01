using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BlogSpot
{
    public class Post : AuditedAggregateRoot<Guid>
    {
        public int BlogID { get; set; }
        public int UserID { get; set; }
        public DateTime PublishDate { get; set; }
        public Boolean IsPublished { get; set; }
        public TagType Tags { get; set; }
        public int Likes { get; set; }

    }
}
