using MyProjectSm.Models;
using System.Linq;

namespace MyProjectSm.Services
{
    public class LogingService : ILogingService
    {

        Response response;
        ProjectDbContext projectDb;
        public LogingService(Response response, ProjectDbContext projectDb)
        {
            this.response = response;
            this.projectDb = projectDb;
        }
        public Response Login(LoginVM login)
        {
            var record = projectDb.UserTbls.FirstOrDefault(x=>x.UserName==login.UserName && x.Password==login.Password);
            if (record == null)
            {
                response.Message = "user not found";
                response.StatusCode = 400;
                response.Data = null;
                response.Version = "1.0";
                
            }
            else
            {
                response.Message = "success";
                response.StatusCode = 200;
                response.Data = record;
                response.Version = "1.0";
            }
            
            return response;
        }
    }
}
