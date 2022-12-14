using MyProjectSm.Models;
using System.Collections.Generic;

namespace MyProjectSm.ModelView
{
   
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
       /* public class Comment
        {
            public int commentId { get; set; }
            public int userId { get; set; }
            public string username { get; set; }
            public string comment { get; set; }
            public string commentdate { get; set; }
        }*/

        /*public class Post
        {
            public int PostId { get; set; }
            public int CategoryId { get; set; }
            public string Title { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public string PostedBy { get; set; }
            public string CreatedBy { get; set; }
            public string CreatedDate { get; set; }
            public List<Comment> Comments { get; set; }
            public int TotalLikes { get; set; }
        }*/

        public class Root
        {
            public List<PostTbl> post { get; set; } = new List<PostTbl>();
        }


    
}
