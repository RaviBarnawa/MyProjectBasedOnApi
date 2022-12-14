using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectSm.Models;
using MyProjectSm.Services;

namespace MyProjectSm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService Comment;
        public CommentController(ICommentService comment)
        {
            Comment = comment;
        }
        [HttpGet]
        [Route("GetAllComment")]
        public Response GetAllComment()
        {
            return Comment.GetAllComment();
        }
        [HttpPost]
        [Route("AddEditComment")]
        public Response AddEditComment(CommentModel comment)
        {
            return Comment.AddEditComment(comment);
        }
        [HttpDelete]
        [Route("CommentDelete")]
        public Response CommentDelete(int id)
        {
            return Comment.CommentDelete(id);
        }
    }
}
