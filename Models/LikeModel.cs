using System;

namespace MyProjectSm.Models
{
    public class LikeModel
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; }
  
       
        public bool? Like { get; set; }

        
    }
}
