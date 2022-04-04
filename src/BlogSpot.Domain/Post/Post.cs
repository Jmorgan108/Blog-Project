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
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
        public DateTime PublishDate { get; set; }
        public TagType Tags { get; set; }
        public int Likes { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
