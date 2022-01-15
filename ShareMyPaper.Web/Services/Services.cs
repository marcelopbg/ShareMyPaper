using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Application.Mappings;
using ShareMyPaper.Infraestructure.Repositories;
using ShareMyPaper.Infraestructure.Services;
using System.Reflection;

namespace ShareMyPaper.Web.Services
{
    internal static class Services
    {
        internal static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IKnowledgeAreaRepository, KnowledgeAreaRepository>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IInstitutionModeratorRepository, InstitutionModeratorRepository>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ICurrentUserRepository, CurrentUserRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
