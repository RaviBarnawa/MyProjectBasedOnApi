using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectSm.Models;
using MyProjectSm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService post;
        LogingService loggin;
        public PostController(IPostService postService)
        {
             post = postService;
           
        }
        [HttpPost]
        [Route("Api/AddEditPost")]
        public Response AddEditPost(PostModel model)
        {
            return post.AddEditPost(model);
        }
        
        [HttpGet]
        [Route("Api/GetPostById")]
        public Response GetPostById(int id)
        {
            return post.GetPostById(id);
        }
        [HttpDelete]
        [Route("Api/PostDelete")]
        public Response PostDelete(int id)
        {
            return post.PostDelete(id);
        }
        [HttpGet]
        [Route("Api/GetAllPost")]
        public Response GetAllPost()
        {
            return post.GetAllPost();
        }
       
    }
}
