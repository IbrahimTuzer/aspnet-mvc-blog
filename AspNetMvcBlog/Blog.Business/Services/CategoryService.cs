using Blog.Business.Services.Abstract;
using Blog.Data;
using Blog.Data.Entity;
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

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();

        }

        public Category GetById(int id)
        {
            return _db.Categories
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public void Insert(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void Update(Category category)
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

        public Category GetBySlug(string slug)
        {
            return _db.Categories.Where(e => e.Slug == slug).FirstOrDefault();
        }

    }
}
