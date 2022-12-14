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
    public class UserController : ControllerBase
    {
        IUserService service;

        public UserController(IUserService user)
        {
            service = user;
        }
        [HttpGet]
        [Route("Api/GetAllUser")]
        public Response GetAllUser()
        {
            return service.GetAllUser();
        }
        [HttpPost]
        [Route("Api/AddEditUser")]
        public Response AddEditUser(UserModel user)
        {
            return service.AddEditUser(user);
        }
        [HttpPost]
        [Route("Api/GetUserById")]
        public Response GetUserById(int id)
        {
            return service.GetUserById(id);
        }
        [HttpDelete]
        [Route("Api/")]
        public Response UserDeleteById(int id)
        {
            return service.UserDeleteById(id);
        }
    }
   
}
