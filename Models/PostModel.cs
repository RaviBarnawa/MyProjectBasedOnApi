using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public int CatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Image { get; set; }



    }
}
