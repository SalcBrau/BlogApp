using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Data.Entities
{
    public class Tag
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String UrlSlug { get; set; }

        public String Description { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
