using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogApp.Core.Entities
{
    class PostTag
    {
        [Required]
        [ForeignKey("Post")]
        public Guid PostId { get; set; }

        [Required]
        [ForeignKey("Tag")]
        public Guid TagId { get; set;}

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
