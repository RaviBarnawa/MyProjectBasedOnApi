using Microsoft.EntityFrameworkCore;
using MyProjectSm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Services
{
    public class CategoryService : ICategoryService
    {
        Response response;
        ProjectDbContext projectDb;
        public CategoryService(Response response , ProjectDbContext projectDb)
        {
            this.response = response;
            this.projectDb = projectDb;
           
        }
        public Response GetAllCategory()
        {
            List<CategoryModel> list =new List<CategoryModel>();
            var result = projectDb.CategoryTbls.ToList();
            foreach (var item in result)
            {
                list.Add(new CategoryModel
                { 
                    Id=item.Id,
                    Category=item.Category,
                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = list;
            response.Message = "Success";
            return response;
        }
        public Response AddEditCategory(CategoryModel category)
        {
            if (category.Id == 0)
            {
                try
                {
                    CategoryTbl tbl = new CategoryTbl();
                    tbl.Id = category.Id;
                    tbl.Category = category.Category;

                    projectDb.CategoryTbls.Add(tbl);
                    projectDb.SaveChanges();

                    response.StatusCode = 200;
                    response.Version = "V1";
                    response.Data = projectDb.CategoryTbls;
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
                var Record = projectDb.CategoryTbls.Where(x => x.Id == category.Id).FirstOrDefault();
                Record.Id = category.Id;
                Record.Category = category.Category;
                projectDb.Entry(Record).State = EntityState.Modified;
                projectDb.SaveChanges();
            }
            return response;
        }
        public Response GetCategoryById(int id)
        {
            List<CategoryModel> list = new List<CategoryModel>();
            var service = projectDb.CategoryTbls.ToList();
            service = service.Where(x => x.Id == id).ToList();
            foreach (var item in service)
            {
                list.Add(new CategoryModel 
                { 

                    Id=item.Id,
                    Category=item.Category,
                
                });
            }
            response.StatusCode = 200;
            response.Version = "V1";
            response.Data = service.FirstOrDefault();
            response.Message = "Success";
            return response;
        }
        public Response CategoryDeleteById(int id)
        {
            try
            {
                var service = projectDb.CategoryTbls.FirstOrDefault(x => x.Id == id);
                projectDb.CategoryTbls.Remove(service);

                response.StatusCode = 200;
                response.Version = "V1";
                response.Data = "Data Deleted";
                response.Message = "Success";
            }
            catch(Exception ex)
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
