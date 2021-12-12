using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Application.Interfaces.Repositories;
public interface IPostRepository : IGenericRepository<Post>
{
    public Task<Post> CreatePost(PostInputDTO post, string userEmail);
}
