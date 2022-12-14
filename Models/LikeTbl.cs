using System;
using System.Collections.Generic;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class LikeTbl
    {
        public LikeTbl()
        {
            Mergeings = new HashSet<Mergeing>();
        }

        public int UserId { get; set; }
        public int? PostId { get; set; }
        public DateTime? DateOfLike { get; set; }
        public bool? IsActive { get; set; }
        public bool? Like { get; set; }
        public int LikeId { get; set; }

        public virtual UserTbl User { get; set; }
        public virtual ICollection<Mergeing> Mergeings { get; set; }
    }
}
