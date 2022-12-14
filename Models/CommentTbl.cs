using System;
using System.Collections.Generic;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class CommentTbl
    {
        public CommentTbl()
        {
            Mergeings = new HashSet<Mergeing>();
        }

        public int? UserId { get; set; }
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public int? PostId { get; set; }
        public DateTime? CommentDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual PostTbl Post { get; set; }
        public virtual ICollection<Mergeing> Mergeings { get; set; }
    }
}
