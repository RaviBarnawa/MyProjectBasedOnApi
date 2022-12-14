using System;
using System.Collections.Generic;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class PostTbl
    {
        public PostTbl()
        {
            CommentTbls = new HashSet<CommentTbl>();
            Mergeings = new HashSet<Mergeing>();
        }

        public int PostId { get; set; }
        public int CatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PostBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? TotalLikes { get; set; }
        public string Comments { get; set; }

        public virtual CategoryTbl Cat { get; set; }
        public virtual ICollection<CommentTbl> CommentTbls { get; set; }
        public virtual ICollection<Mergeing> Mergeings { get; set; }
    }
}
