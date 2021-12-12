using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;

namespace ShareMyPaper.Infraestructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
