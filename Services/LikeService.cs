using Microsoft.EntityFrameworkCore;
using MyProjectSm.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProjectSm.Services
{
    public class LikeService : ILikeService
    {
        Response response;
        ProjectDbContext projectDb;
        public LikeService(Response response , ProjectDbContext projectDb )
        {
            this.response = response;
            this.projectDb = projectDb;
        }
        public Response GetAllLike()
        {
            List<LikeTbl> list = new List<LikeTbl>();
            var Result = projectDb.LikeTbls.ToList();
            foreach (var item in Result)
            {
                list.Add(new LikeTbl {

                    LikeId=item.LikeId,
                    UserId=item.UserId,
                    PostId=item.PostId,
                    DateOfLike=item.DateOfLike,
                    IsActive=item.IsActive,
                    Like=item.Like,
                
                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = projectDb.LikeTbls;
            response.Message = "Success";
            return response;
        }
        public Response AddEditLike(LikeModel like)
        {
            if (like.LikeId == 0)
            {
                try
                {
                    LikeTbl tbl = new LikeTbl();
                   
                    tbl.UserId = like.UserId;
                    tbl.PostId = like.PostId;
                    tbl.Like= like.Like;

                    projectDb.LikeTbls.Add(tbl);
                    projectDb.SaveChanges();
                    var rec = projectDb.PostTbls.Where(x=>x.PostId == like.PostId).FirstOrDefault();
                    if(rec != null)
                    {
                        rec.TotalLikes += like.UserId;
                        projectDb.SaveChanges();
                    }
                   
                    response.StatusCode = 200;
                    response.Version = "V1";
                    response.Data = projectDb.LikeTbls;
                    response.Message = "Success";
                }
                catch(Exception ex)
                {
                    response.StatusCode = 400;
                    response.Version = "V1";
                    response.Message = "Data not Exist";
                }
            }
            else
            {
                var Record = projectDb.LikeTbls.Where(x=>x.LikeId==like.LikeId).FirstOrDefault();
                if (Record != null)
                {
                    if (Record.Like == true)
                    {
                        Record.Like = false ;

                        projectDb.Entry(Record).State = EntityState.Modified;
                        projectDb.SaveChanges();
                    }
                    else
                    {
                        Record.Like= false ;
                        projectDb.Entry(Record).State = EntityState.Modified;
                        projectDb.SaveChanges();
                    }
                    
                }
            }
            return response;
        }
    }
}
