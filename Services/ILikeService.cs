using MyProjectSm.Models;

namespace MyProjectSm.Services
{
    public interface ILikeService
    {
        Response GetAllLike();
        Response AddEditLike(LikeModel like);
    }
}
