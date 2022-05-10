using System;
using System.ComponentModel.DataAnnotations;


namespace BlogSpot.Posts
{
    public class CreateUpdatePostsDto
    {
        public Guid AuthorId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public TagType Tags { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
