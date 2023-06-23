using Blog.Business.Dtos;


namespace Blog.Business.Services.Abstract
{
	public interface IPostService
    {
        List<PostDto> GetAll();
        PostDto GetById(int id);
        void Insert(PostDto post);
        void Update(PostDto post);
        void DeleteById(int id);
    }
}
