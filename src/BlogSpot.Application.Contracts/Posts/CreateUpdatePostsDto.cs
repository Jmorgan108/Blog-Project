using System;
using System.ComponentModel.DataAnnotations;


namespace BlogSpot.Posts
{
    public class CreateUpdatePostsDto
    {
        public Guid UserId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public TagType Tags { get; set; }

        public int Likes { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
