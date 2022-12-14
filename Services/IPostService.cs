using MyProjectSm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Services
{
   public interface IPostService
    {
        Response AddEditPost(PostModel model);
        Response GetPostById(int id);
        Response PostDelete(int id);
        Response GetAllPost();

    }
}
