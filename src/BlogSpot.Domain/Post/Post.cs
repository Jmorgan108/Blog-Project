﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BlogSpot
{
    public class Post : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public TagType Tags { get; set; }
        public int Likes { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
