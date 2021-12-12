using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Infraestructure.Persistence
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Institution> Institution { get; set; }
        public DbSet<KnowledgeArea> KnowledgeArea { get; set; }
        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                Email = "admin@admin.com",
                LockoutEnabled = false,
                Role = "admin",
                InstitutionId = null,
                DocumentId = "",
                DocumentExtension = "",
                IsActive = true,
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<ApplicationUser>().HasData(user);


            builder.Entity<IdentityRole>().HasData(
              new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "admin", ConcurrencyStamp = "1", NormalizedName = "admin" },
              new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "institution moderator", ConcurrencyStamp = "2", NormalizedName = "institution moderator" },
              new IdentityRole() { Id = "8f5c7626-e24e-4ff2-a7ea-e36d0d801ae5", Name = "student", ConcurrencyStamp = "3", NormalizedName = "student" }
              );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );

            #region seed areas do conhecimento
            builder.Entity<KnowledgeArea>().HasData(
                 new KnowledgeArea() { Id = 1, Description = "Matemática" },
                 new KnowledgeArea() { Id = 2, Description = "Probabilidade e Estatística" },
                 new KnowledgeArea() { Id = 3, Description = " Ciência da Computação" },
                 new KnowledgeArea() { Id = 4, Description = "Astronomia" },
                 new KnowledgeArea() { Id = 5, Description = "Física" },
                 new KnowledgeArea() { Id = 6, Description = "Química" },
                 new KnowledgeArea() { Id = 7, Description = "GeoCiências" },
                 new KnowledgeArea() { Id = 8, Description = "Oceanografia" },
                 new KnowledgeArea() { Id = 9, Description = "Biologia" },
                 new KnowledgeArea() { Id = 10, Description = "Genética" },
                 new KnowledgeArea() { Id = 11, Description = "Botânica" },
                 new KnowledgeArea() { Id = 12, Description = "Zoologia" },
                 new KnowledgeArea() { Id = 13, Description = "Ecologia" },
                 new KnowledgeArea() { Id = 14, Description = "Morfologia" },
                 new KnowledgeArea() { Id = 15, Description = "Fisiologia" },
                 new KnowledgeArea() { Id = 16, Description = "Bioquímica" },
                 new KnowledgeArea() { Id = 17, Description = "Biofísica" },
                 new KnowledgeArea() { Id = 18, Description = "Farmacologia" },
                 new KnowledgeArea() { Id = 19, Description = "Imunologia" },
                 new KnowledgeArea() { Id = 20, Description = "Microbiologia" },
                 new KnowledgeArea() { Id = 21, Description = "Parasitologia" },
                 new KnowledgeArea() { Id = 22, Description = "Engenharia Civil" },
                 new KnowledgeArea() { Id = 23, Description = "Engenharia de Minas" },
                 new KnowledgeArea() { Id = 24, Description = "Engenharia de Materiais e Metalúrgica" },
                 new KnowledgeArea() { Id = 25, Description = "Engenharia Elétrica" },
                 new KnowledgeArea() { Id = 26, Description = " Engenharia Química" },
                 new KnowledgeArea() { Id = 27, Description = "Engenharia Sanitária" },
                 new KnowledgeArea() { Id = 28, Description = "Engenharia de Produção" },
                 new KnowledgeArea() { Id = 29, Description = "Engenharia Nuclear" },
                 new KnowledgeArea() { Id = 30, Description = "Engenharia de Transportes" },
                 new KnowledgeArea() { Id = 31, Description = "Engenharia Naval e Oceânica" },
                 new KnowledgeArea() { Id = 32, Description = "Engenharia Aeroespacial" },
                 new KnowledgeArea() { Id = 33, Description = "Engenharia Biomédica" },
                 new KnowledgeArea() { Id = 34, Description = "Odontologia" },
                 new KnowledgeArea() { Id = 35, Description = "Farmácia" },
                 new KnowledgeArea() { Id = 36, Description = "Enfermagem" },
                 new KnowledgeArea() { Id = 37, Description = "Nutrição" },
                 new KnowledgeArea() { Id = 38, Description = "Saúde Coletiva" },
                 new KnowledgeArea() { Id = 39, Description = "Fonoaudiologia" },
                 new KnowledgeArea() { Id = 40, Description = "Fisioterapia e Terapia Ocupacional" },
                 new KnowledgeArea() { Id = 41, Description = "Educação Física" },
                 new KnowledgeArea() { Id = 42, Description = "Agronomia" },
                 new KnowledgeArea() { Id = 43, Description = "Engenharia Agrícola" },
                 new KnowledgeArea() { Id = 44, Description = "Zootecnia" },
                 new KnowledgeArea() { Id = 45, Description = "Medicina Veterinária" },
                 new KnowledgeArea() { Id = 46, Description = "Recursos Pesqueiros e Engenharia de Pesca" },
                 new KnowledgeArea() { Id = 47, Description = "Ciência e Tecnologia de Alimentos" },
                 new KnowledgeArea() { Id = 48, Description = "Direito" },
                 new KnowledgeArea() { Id = 49, Description = "Administração" },
                 new KnowledgeArea() { Id = 50, Description = "Economia" },
                 new KnowledgeArea() { Id = 51, Description = "Arquitetura e Urbanismo" },
                 new KnowledgeArea() { Id = 52, Description = "Planejamento Urbano e Regional" },
                 new KnowledgeArea() { Id = 53, Description = "Demografia" },
                 new KnowledgeArea() { Id = 54, Description = "Ciência da Informação" },
                 new KnowledgeArea() { Id = 55, Description = "Museologia" },
                 new KnowledgeArea() { Id = 56, Description = "Comunicação" },
                 new KnowledgeArea() { Id = 57, Description = "Serviço Social" },
                 new KnowledgeArea() { Id = 58, Description = "Economia Doméstica" },
                 new KnowledgeArea() { Id = 59, Description = "Desenho Industrial" },
                 new KnowledgeArea() { Id = 60, Description = "Turismo" },
                 new KnowledgeArea() { Id = 61, Description = "Filosofia" },
                 new KnowledgeArea() { Id = 62, Description = "Sociologia" },
                 new KnowledgeArea() { Id = 63, Description = "Antropologia" },
                 new KnowledgeArea() { Id = 64, Description = "Arqueologia" },
                 new KnowledgeArea() { Id = 65, Description = "História" },
                 new KnowledgeArea() { Id = 66, Description = "Geografia" },
                 new KnowledgeArea() { Id = 67, Description = "Psicologia" },
                 new KnowledgeArea() { Id = 68, Description = "Educação" },
                 new KnowledgeArea() { Id = 69, Description = "Ciência Política" },
                 new KnowledgeArea() { Id = 70, Description = "Teologia" },
                 new KnowledgeArea() { Id = 71, Description = "Lingüística" },
                 new KnowledgeArea() { Id = 72, Description = "Letras" },
                 new KnowledgeArea() { Id = 73, Description = "Artes" }
            );
            #endregion
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(200);
        }
    }
}
