using Azure;
using Blog.Data;
using Blog.Business.Dtos;
using Microsoft.EntityFrameworkCore;
using Blog.Business.Services.Abstract;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Blog.Data.Entity;

namespace Blog.Business.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _db;

        public PostService(AppDbContext db)
        {
            // Post koleksiyonunu başlatma veya veritabanından veri çekme işlemleri burada yapılabilir
            _db = db;
        }

        public IEnumerable<PostDto> GetAll()
        {
            var a = _db.Posts.Include(p => p.Categories).Include(p => p.User).ToList().PostListToDtoList();
            return a;
        }

        public PostDto GetById(int id)
        {
            return _db.Posts
                .Include(p => p.Categories)
                .Include(p => p.User)
                .Where(p => p.Id == id)
                .FirstOrDefault().PostToDto();
        }

        public void Insert(PostDto post)
        {
            _db.Posts.Add(post.DtoToPost());
            _db.SaveChanges();
        }
        /*
        public void Update(int id, PostDto post)
        {
            if (post.Id != id) return;

            var oldPost = _db.Posts.Include(p => p.Categories).FirstOrDefault(p => p.Id == id);
            if (oldPost != null)
            {
                oldPost.Content = post.Content;
                oldPost.Title = post.Title;
                oldPost.UpdatedAt = DateTime.Now;
                oldPost.UserId = post.UserId == null ? post.UserId : oldPost.UserId;
                oldPost.Categories.Clear();
                if (post.Categories != null)
                {
                    oldPost.Categories = post.Categories.DtoListToCategoryList();
                }
                _db.Entry(oldPost).State = EntityState.Modified;
                _db.SaveChanges();
            }
            

            //_db.Entry(post.DtoToPost()).State = EntityState.Modified;
            //_db.SaveChanges();
        }*/

        public void Update(int id, PostDto dto)
        {
            var existingPost = _db.Posts.Include(p => p.Categories).FirstOrDefault(p => p.Id == id);

            if (existingPost != null)
            {
                existingPost.Content = dto.Content;
                existingPost.Title = dto.Title;
                existingPost.UpdatedAt = DateTime.Now;

                if (dto.Categories != null)
                {
                    // Ensure the Categories collection is instantiated
                    if (existingPost.Categories == null)
                    {
                        existingPost.Categories = new List<Category>();
                    }
                    else
                    {
                        existingPost.Categories.Clear(); // Clear existing categories
                    }

                    foreach (var categoryDto in dto.Categories)
                    {
                        var category = _db.Categories.FirstOrDefault(c => c.Id == categoryDto.Id);

                        if (category != null)
                        {
                            existingPost.Categories.Add(category);
                        }
                    }
                }

                _db.SaveChanges();
            }
        }



        public void DeleteById(int id)
        {
            var post = _db.Posts.SingleOrDefault(p => p.Id == id);
            if (post != null)
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();
            }
        }

    }
}