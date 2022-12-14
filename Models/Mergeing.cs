using System;
using System.Collections.Generic;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class Mergeing
    {
        public int Id { get; set; }
        public int? LikeId { get; set; }
        public int? CommentId { get; set; }
        public int? PostId { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }

        public virtual CategoryTbl Category { get; set; }
        public virtual CommentTbl Comment { get; set; }
        public virtual LikeTbl Like { get; set; }
        public virtual PostTbl Post { get; set; }
        public virtual UserTbl User { get; set; }
    }
}
