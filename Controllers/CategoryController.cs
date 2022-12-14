using Microsoft.AspNetCore.Cors;
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
    [EnableCors("MyPolicy")]
    public class CategoryController : ControllerBase
    {

        
        ICategoryService Category;
        public CategoryController(ICategoryService category)
        {
            Category = category;
        }
        
        [HttpGet]
        [Route("Api/GetAllCategory")]
        [EnableCors("MyPolicy")]
        public Response GetAllCategory()
        {
            return Category.GetAllCategory();
        }
        [EnableCors("MyPolicy")]
        [HttpPost]
        [Route("Api/AddEditCategory")]
        public Response AddEditCategory(CategoryModel category)
        {
            return Category.AddEditCategory(category);
        }
        [HttpPost]
        [Route("Api/GetCategoryById")]
        [EnableCors("*")]
        public Response GetCategoryById(int id)
        {
            return Category.GetCategoryById(id);
        }
        [HttpDelete]
        [Route("Api/CategoryDeleteById")]
        public Response CategoryDeleteById(int id)
        {
            return Category.CategoryDeleteById(id);
        }
    }
}
