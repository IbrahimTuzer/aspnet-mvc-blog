using Blog.Data.Entity;

namespace Blog.Business.Services.Abstract
{
	public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(int id);
        void Insert(Post post);
        void Update(Post post);
        void DeleteById(int id);
    }
}
