using Microsoft.EntityFrameworkCore;
using MyProjectSm.Models;
using MyProjectSm.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MyProjectSm.Services
{
    public class PostService : IPostService
    {
        Response response;
        ProjectDbContext projectDb;
        public PostService(Response response, ProjectDbContext projectDb)
        {
            this.response = response;
            this.projectDb = projectDb;
        }
        public Response GetAllPost()
        {
            List<PostModel> list = new List<PostModel>();
            var result = projectDb.PostTbls.ToList();
            foreach (var item in result)
            {
                list.Add(new PostModel
                {
                    PostId=item.PostId,
                    CatId=item.CatId,
                    Title=item.Title,
                    Description=item.Description,
                    PostBy=item.PostBy,
                    CreatedDate=item.CreatedDate,
                    Image=item.Image,

                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = list;
            response.Message = "Success";
            return response;

        }
        public Response AddEditPost(PostModel model)
        {
            if (model.PostId == 0)
            {
                try
                {
                    PostTbl tbl = new PostTbl();
                    tbl.CatId = model.CatId;
                    tbl.Description = model.Description;
                    tbl.PostBy = model.PostBy;
                    tbl.PostId= model.PostId;
                    tbl.CreatedDate = model.CreatedDate;
                    tbl.Image = model.Image;

                    projectDb.PostTbls.Add(tbl);
                    projectDb.SaveChanges();

                    response.StatusCode = 200;
                    response.Version = "V1";
                    response.Data = model;
                    response.Message = "Success";
                }
                catch(Exception ex)
                {
                    response.StatusCode = 400;
                    response.Version = "V1";
                    response.Data = model;
                    response.Message = "Data not Exist";
                }
            }
            else
            {
                var record = projectDb.PostTbls.Where(x => x.PostId == model.PostId).FirstOrDefault();
                record.Description = model.Description;
                record.Image = model.Image;
                projectDb.Entry(record).State = EntityState.Modified;
                projectDb.SaveChanges();
            }
            return response;
        }
        public Response GetPostById(int id)
        {
            List<PostModel> list = new List<PostModel>();
            var service = projectDb.PostTbls.ToList();
            service = service.Where(x => x.CatId == id).ToList();
            foreach (var item in service)
            {
                list.Add(new PostModel
                {
                    PostId = item.PostId,
                    CatId=item.CatId,
                    Title=item.Title,
                    Description=item.Description,
                    PostBy=item.PostBy,
                    CreatedDate=item.CreatedDate,
                    Image=item.Image,
                    
                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = service.FirstOrDefault();
            response.Message = "Success";
            return response;
        }
        public Response PostDelete(int id)
        {
            try
            {
                var service = projectDb.PostTbls.FirstOrDefault(x => x.PostId == id);
                projectDb.PostTbls.Remove(service);

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
