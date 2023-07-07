using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Business.Dtos;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services
{
	public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db) {
            _db = db;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _db.Categories.ToList().CategoryListToDtoList();

        }

        public CategoryDto GetById(int id)
        {
            return _db.Categories
                .Where(p => p.Id == id)
                .FirstOrDefault().CategoryToDto();
        }

        public void Insert(CategoryDto category)
        {
            _db.Categories.Add(category.DtoToCategory());
            _db.SaveChanges();
        }

        public void Update(CategoryDto category)
        {
            var oldCategory = _db.Categories.FirstOrDefault(p => p.Id == category.Id);
            if (oldCategory != null)
            {
                _db.Entry(oldCategory).CurrentValues.SetValues(category);
                _db.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var category = _db.Categories.SingleOrDefault(p => p.Id == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }

        public CategoryDto GetBySlug(string slug)
        {
            return _db.Categories.Where(e => e.Slug == slug).FirstOrDefault().CategoryToDto();
        }

    }
}
