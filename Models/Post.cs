using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PostId { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        public Guid? AuthorId { get; set; } = null;
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsDeleted { get; set; } = null;
        public Guid? TopicId { get; set; } = null;

        public virtual Author Author { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
