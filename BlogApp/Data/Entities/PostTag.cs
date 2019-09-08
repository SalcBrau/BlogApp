using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogApp.Data.Entities
{
    public class PostTag
    {
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }

        [Required]
        [ForeignKey("Tag")]
        public int TagId { get; set;}

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
