using System;
using Volo.Abp.Application.Dtos;

namespace BlogSpot.Posts
{
    public class PostDto : AuditedEntityDto<Guid>
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public TagType Tags { get; set; }
        public int Likes { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
