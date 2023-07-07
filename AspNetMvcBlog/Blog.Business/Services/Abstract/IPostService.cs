using Blog.Business.Dtos;


namespace Blog.Business.Services.Abstract
{
	public interface IPostService
    {
        IEnumerable<PostDto> GetAll();
        PostDto GetById(int id);
        void Insert(PostDto post);
        void Update(int id,PostDto post);
        void DeleteById(int id);
    }
}
