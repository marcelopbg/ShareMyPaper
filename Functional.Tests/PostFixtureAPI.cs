using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Persistence;
using System.Linq;

namespace Functional.Tests;
class PostFixtureAPI : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<AppDbContext>));

            services.Remove(descriptor);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForPostTests");
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<AppDbContext>();

            var _roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();

            db.Database.EnsureCreated();

            db.KnowledgeArea.Add(new KnowledgeArea() { Description = "Matemática" });
            db.KnowledgeArea.Add(new KnowledgeArea() { Description = "Geografia" });

            db.Institution.Add(new Institution()
            {
                City = "tes",
                Country = "tes",
                Description = "tes",
                State = "test"
            });
            db.SaveChanges();

            _roleManager.CreateAsync(new IdentityRole()
            {
                Name = "student"

            }).Wait();

            var student = new ApplicationUser()
            {
                UserName = "teste@teste2.com",
                NormalizedUserName = "teste@teste2.com",
                NormalizedEmail = "teste@teste2.com",
                Email = "teste@teste2.com",
                LockoutEnabled = false,
                Role = "student",
                InstitutionId = 1,
                DocumentId = "fake-doc",
                DocumentExtension = "fake-ext",
                IsActive = true,
            };
            _roleManager.CreateAsync(new IdentityRole()
            {
                Name = "institution moderator"

            }).Wait();
            var instMod = new ApplicationUser()
            {
                UserName = "teste@instmod.com",
                NormalizedUserName = "teste@instmod.com",
                NormalizedEmail = "teste@instmod.com",
                Email = "teste@instmod.com",
                LockoutEnabled = false,
                Role = "institution moderator",
                InstitutionId = 1,
                DocumentId = "",
                DocumentExtension = "",
                IsActive = true,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            student.PasswordHash = passwordHasher.HashPassword(student, "SecurePass!123");
            _userManager.CreateAsync(student).Wait();
            _userManager.AddToRoleAsync(student, student.Role);

            instMod.PasswordHash = passwordHasher.HashPassword(instMod, "SecurePass!123");
            _userManager.CreateAsync(instMod).Wait();
            _userManager.AddToRoleAsync(instMod, instMod.Role);
        });
    }
}