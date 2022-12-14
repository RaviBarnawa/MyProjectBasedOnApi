using MyProjectSm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Services
{
    public interface IUserService
    {
        Response GetAllUser();
        Response AddEditUser(UserModel user);
        Response GetUserById(int id);
        Response UserDeleteById(int id);
    }
}
