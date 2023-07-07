using Blog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        CategoryDto GetBySlug(string slug);
        void Insert(CategoryDto category);
        void Update(CategoryDto category);
        void DeleteById(int id);
    }
}
