using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Application.Dtos;

namespace ShareMyPaper.Application.Interfaces.Repositories;
public interface IPostRepository : IGenericRepository<Post>
{
    public Task<Post> CreatePost(PostInputDTO post, string userEmail);
    public Task<PagedResult<Post>> GetPagedPosts(int currentPage, int pageSize, string userEmail);
}
