using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            PostTbls = new HashSet<PostTbl>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public virtual ICollection<PostTbl> PostTbls { get; set; }
    }
}
