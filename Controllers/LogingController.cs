using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectSm.Models;
using MyProjectSm.Services;

namespace MyProjectSm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingController : ControllerBase
    {
        ILogingService logingService;

        public LogingController(ILogingService service)
        {
            logingService = service;
        }
        [HttpPost]
        [Route("Api/Login")]
        public Response Login(LoginVM login)
        {
            return logingService.Login(login);
        }
    }
}
