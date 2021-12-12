using AutoMapper;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;
        private readonly AppDbContext _appDbContext;

        public PostRepository(
            AppDbContext dbContext,
            IStudentRepository studentRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IFileStorageService fileStorageService,
            AppDbContext appDbContext

        ) : base(dbContext)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
            _appDbContext = appDbContext;
        }
        public async Task<Post> CreatePost(PostInputDTO postDto, string userEmail)
        {
            var user = await _studentRepository.FirstAsync(user => user.Email == userEmail);
            var post = _mapper.Map<Post>(postDto);
            var documentId = await _fileStorageService.UploadFileToStorage(postDto.UploadedFile);
            post.ApplicationUserId = user.Id;
            post.DocumentId = documentId;
            await _appDbContext.Post.AddAsync(post);
            await _unitOfWork.Commit();
            return post;
        }
    }
}
