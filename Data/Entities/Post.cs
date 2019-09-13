using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Post
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "'Title' must be between 5 and 50 characters long.")]
        public String Title { get; set; }

        public String ShortDescription { get; set; }
        public String Description { get; set; }
        public String Meta { get; set; }
        public String UrlSlug { get; set; }
        public Boolean Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }

        public virtual Category Category { get; set;  }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }

}
