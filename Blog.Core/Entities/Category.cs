using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Core.Entities
{
    class Category
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        public String UrlSlug { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
