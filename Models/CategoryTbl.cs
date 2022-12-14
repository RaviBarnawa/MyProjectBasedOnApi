using System;
using System.Collections.Generic;

#nullable disable

namespace MyProjectSm.Models
{
    public partial class CategoryTbl
    {
        public CategoryTbl()
        {
            Mergeings = new HashSet<Mergeing>();
            PostTbls = new HashSet<PostTbl>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Mergeing> Mergeings { get; set; }
        public virtual ICollection<PostTbl> PostTbls { get; set; }
    }
}
