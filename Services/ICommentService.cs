using MyProjectSm.Models;

namespace MyProjectSm.Services
{
    public interface ICommentService
    {
        Response GetAllComment();
        Response AddEditComment(CommentModel comment);
        Response CommentDelete(int id);
    }
}
