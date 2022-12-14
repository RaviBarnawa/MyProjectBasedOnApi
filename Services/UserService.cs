using Microsoft.EntityFrameworkCore;
using MyProjectSm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Services
{
    public class UserService : IUserService
    {
        Response response;
        ProjectDbContext projectDb;

        public UserService(Response response, ProjectDbContext projectDb)
        {
            this.response = response;
            this.projectDb = projectDb;
        }
        public Response GetAllUser()
        {
            List<UserModel> list = new List<UserModel>();
            var result = projectDb.UserTbls.ToList();
            foreach (var item in result)
            {
                list.Add(new UserModel {
                    
                    Id=item.Id,
                    Name=item.Name,
                    Address=item.Address,
                    ContactNo=item.ContactNo,
                    Email=item.Email,
                    Gender=item.Gender,
                    ProfileImage=item.ProfileImage,
                    UserName=item.UserName,
                    Password=item.Password,
                
                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = list;
            response.Message = "Success";
            return response;
        }
        public Response AddEditUser(UserModel user)
        {
            if (user.Id == 0)
            {
                try
                {
                    UserTbl tbl = new UserTbl();
                    tbl.Id = user.Id;
                    tbl.Name = user.Name;
                    tbl.Gender = user.Gender;
                    tbl.Email = user.Email;
                    tbl.Address = user.Address;
                    tbl.ContactNo = user.ContactNo;
                    tbl.ProfileImage = user.ProfileImage;
                    tbl.UserName = user.UserName;
                    tbl.Password = user.Password;

                    projectDb.UserTbls.Add(tbl);
                    projectDb.SaveChanges();

                    response.StatusCode = 200;
                    response.Version = "V1";
                    response.Data = user;
                    response.Message = "Success";
                }
                catch (Exception ex)
                {
                    response.StatusCode = 400;
                    response.Version = "V1";
                    response.Data = user;
                    response.Message = "Data not Exist";
                }
            }
            else
            {
                var Record = projectDb.UserTbls.Where(x => x.Id == user.Id).FirstOrDefault();
                Record.Id = user.Id;
                Record.Name = user.Name;
                Record.Gender = user.Gender;
                Record.Email = user.Email;
                Record.Address = user.Address;
                Record.ContactNo = user.ContactNo;
                Record.ProfileImage = user.ProfileImage;
                Record.UserName = user.UserName;
                Record.Password = user.Password;
                projectDb.Entry(Record).State = EntityState.Modified;
                projectDb.SaveChanges();
            }
            return response;
        }
        public Response GetUserById(int id)
        {
            List<UserModel> list = new List<UserModel>();
            var service = projectDb.UserTbls.ToList();
            service = service.Where(x => x.Id == id).ToList();
            foreach (var item in service)
            {
                list.Add(new UserModel
                {

                    Id = item.Id,
                    Name=item.Name,
                    Address=item.Address,
                    ContactNo=item.ContactNo,
                    Gender=item.Gender,
                    Email=item.Email,
                    ProfileImage=item.ProfileImage,
                    UserName=item.UserName,
                    Password=item.Password,

                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = service.FirstOrDefault();
            response.Message = "Success";
            return response;
        }
        public Response UserDeleteById(int id)
        {
            try
            {
                var service = projectDb.UserTbls.FirstOrDefault(x => x.Id == id);
                projectDb.UserTbls.Remove(service);

                response.StatusCode = 200;
                response.Version = "V1";
                response.Data = "Data Deleted";
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.StatusCode = 400;
                response.Version = "V1";
                response.Data = ex.Message;
                response.Message = "Not Exist User";
            }
            return response;
        }
    }
}
