using Microsoft.EntityFrameworkCore;
using MyProjectSm.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MyProjectSm.Services
{
    public class CommentService : ICommentService
    {
        Response response;
        ProjectDbContext projectDb;
        public CommentService(Response response, ProjectDbContext projectDb)
        {
            this.response = response;
            this.projectDb = projectDb;

        }
        public Response GetAllComment()
        {
            List<CommentModel> list = new List<CommentModel>();
            var result = projectDb.CommentTbls.ToList();
            foreach (var item in result)
            {
                list.Add(new CommentModel
                {
                    UserId = item.UserId,
                    CommentId = item.CommentId,
                    Comment=item.Comment,
                    PostId = item.PostId,
                    CommentDate = item.CommentDate,
                    UpdatedDate = item.UpdatedDate,
                    IsActive = item.IsActive,
                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = list;
            response.Message = "Success";
            return response;
        }
        public Response AddEditComment(CommentModel comment)
        {
            if (comment.CommentId == 0)
            {
                try
                {
                    CommentTbl tbl = new CommentTbl();
                    tbl.PostId = comment.PostId;
                    tbl.CommentId = comment.CommentId;
                    tbl.CommentDate = comment.CommentDate;
                    tbl.UpdatedDate = comment.UpdatedDate;
                    tbl.Comment = comment.Comment;
                    tbl.UserId = comment.UserId;
                    tbl.IsActive = comment.IsActive;
                    
                    projectDb.CommentTbls.Add(tbl);
                    projectDb.SaveChanges();

                    response.StatusCode = 200;
                    response.Version = "V1";
                    response.Data = projectDb.CommentTbls;
                    response.Message = "Success"; 
                }
                catch (Exception ex)
                {
                    response.StatusCode = 400;
                    response.Version = "V1";

                    response.Message = "Data not Exist";
                }
            }
            else
            {
                var Record = projectDb.CommentTbls.Where(x => x.CommentId == comment.CommentId).FirstOrDefault();
                Record.PostId = comment.PostId;
                Record.CommentId = comment.CommentId;
                Record.CommentDate = comment.CommentDate;
                Record.UpdatedDate = comment.UpdatedDate;
                Record.Comment = comment.Comment;
                Record.UserId = comment.UserId;
                Record.IsActive = comment.IsActive;

                projectDb.Entry(Record).State = EntityState.Modified;
                projectDb.SaveChanges();
            }
            return response;
        }
        
        public Response CommentDelete(int id)
        {
            try
            {
                var service = projectDb.CommentTbls.FirstOrDefault(x => x.CommentId == id);
                projectDb.CommentTbls.Remove(service);

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
