using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectSm.Models;
using MyProjectSm.Services;

namespace MyProjectSm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        ILikeService Service;
        public LikeController(ILikeService likeService)
        {
            Service = likeService;
        }
        [HttpGet]
        [Route("GetAllLike")]
        public Response GetAllLike()
        {
            return Service.GetAllLike();
        }
        [HttpPost]
        [Route("AddEditLike")]
        public Response AddEditLike(LikeModel like)
        {
            return Service.AddEditLike(like);
        }
    }
}
