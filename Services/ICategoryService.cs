using MyProjectSm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm.Services
{
    public interface ICategoryService
    {
        Response GetAllCategory();
        Response AddEditCategory(CategoryModel category);
        Response GetCategoryById(int id);
        Response CategoryDeleteById(int id);
    }
}
