﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareMyPaper.Infraestructure.Persistence;

#nullable disable

namespace ShareMyPaper.Infraestructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211118013132_first-deploy")]
    partial class firstdeploy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserKnowledgeArea", b =>
                {
                    b.Property<string>("ApplicationUsersId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("KnowledgeAreasId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUsersId", "KnowledgeAreasId");

                    b.HasIndex("KnowledgeAreasId");

                    b.ToTable("ApplicationUserKnowledgeArea");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                            ConcurrencyStamp = "1",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                            ConcurrencyStamp = "2",
                            Name = "institution moderator",
                            NormalizedName = "institution moderator"
                        },
                        new
                        {
                            Id = "8f5c7626-e24e-4ff2-a7ea-e36d0d801ae5",
                            ConcurrencyStamp = "3",
                            Name = "student",
                            NormalizedName = "student"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                            RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Value")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ShareMyPaper.Domain.Entities.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Country")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Institution");
                });

            modelBuilder.Entity("ShareMyPaper.Domain.Entities.KnowledgeArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("KnowledgeArea");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Matemática"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Probabilidade e Estatística"
                        },
                        new
                        {
                            Id = 3,
                            Description = " Ciência da Computação"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Astronomia"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Física"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Química"
                        },
                        new
                        {
                            Id = 7,
                            Description = "GeoCiências"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Oceanografia"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Biologia"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Genética"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Botânica"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Zoologia"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Ecologia"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Morfologia"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Fisiologia"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Bioquímica"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Biofísica"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Farmacologia"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Imunologia"
                        },
                        new
                        {
                            Id = 20,
                            Description = "Microbiologia"
                        },
                        new
                        {
                            Id = 21,
                            Description = "Parasitologia"
                        },
                        new
                        {
                            Id = 22,
                            Description = "Engenharia Civil"
                        },
                        new
                        {
                            Id = 23,
                            Description = "Engenharia de Minas"
                        },
                        new
                        {
                            Id = 24,
                            Description = "Engenharia de Materiais e Metalúrgica"
                        },
                        new
                        {
                            Id = 25,
                            Description = "Engenharia Elétrica"
                        },
                        new
                        {
                            Id = 26,
                            Description = " Engenharia Química"
                        },
                        new
                        {
                            Id = 27,
                            Description = "Engenharia Sanitária"
                        },
                        new
                        {
                            Id = 28,
                            Description = "Engenharia de Produção"
                        },
                        new
                        {
                            Id = 29,
                            Description = "Engenharia Nuclear"
                        },
                        new
                        {
                            Id = 30,
                            Description = "Engenharia de Transportes"
                        },
                        new
                        {
                            Id = 31,
                            Description = "Engenharia Naval e Oceânica"
                        },
                        new
                        {
                            Id = 32,
                            Description = "Engenharia Aeroespacial"
                        },
                        new
                        {
                            Id = 33,
                            Description = "Engenharia Biomédica"
                        },
                        new
                        {
                            Id = 34,
                            Description = "Odontologia"
                        },
                        new
                        {
                            Id = 35,
                            Description = "Farmácia"
                        },
                        new
                        {
                            Id = 36,
                            Description = "Enfermagem"
                        },
                        new
                        {
                            Id = 37,
                            Description = "Nutrição"
                        },
                        new
                        {
                            Id = 38,
                            Description = "Saúde Coletiva"
                        },
                        new
                        {
                            Id = 39,
                            Description = "Fonoaudiologia"
                        },
                        new
                        {
                            Id = 40,
                            Description = "Fisioterapia e Terapia Ocupacional"
                        },
                        new
                        {
                            Id = 41,
                            Description = "Educação Física"
                        },
                        new
                        {
                            Id = 42,
                            Description = "Agronomia"
                        },
                        new
                        {
                            Id = 43,
                            Description = "Engenharia Agrícola"
                        },
                        new
                        {
                            Id = 44,
                            Description = "Zootecnia"
                        },
                        new
                        {
                            Id = 45,
                            Description = "Medicina Veterinária"
                        },
                        new
                        {
                            Id = 46,
                            Description = "Recursos Pesqueiros e Engenharia de Pesca"
                        },
                        new
                        {
                            Id = 47,
                            Description = "Ciência e Tecnologia de Alimentos"
                        },
                        new
                        {
                            Id = 48,
                            Description = "Direito"
                        },
                        new
                        {
                            Id = 49,
                            Description = "Administração"
                        },
                        new
                        {
                            Id = 50,
                            Description = "Economia"
                        },
                        new
                        {
                            Id = 51,
                            Description = "Arquitetura e Urbanismo"
                        },
                        new
                        {
                            Id = 52,
                            Description = "Planejamento Urbano e Regional"
                        },
                        new
                        {
                            Id = 53,
                            Description = "Demografia"
                        },
                        new
                        {
                            Id = 54,
                            Description = "Ciência da Informação"
                        },
                        new
                        {
                            Id = 55,
                            Description = "Museologia"
                        },
                        new
                        {
                            Id = 56,
                            Description = "Comunicação"
                        },
                        new
                        {
                            Id = 57,
                            Description = "Serviço Social"
                        },
                        new
                        {
                            Id = 58,
                            Description = "Economia Doméstica"
                        },
                        new
                        {
                            Id = 59,
                            Description = "Desenho Industrial"
                        },
                        new
                        {
                            Id = 60,
                            Description = "Turismo"
                        },
                        new
                        {
                            Id = 61,
                            Description = "Filosofia"
                        },
                        new
                        {
                            Id = 62,
                            Description = "Sociologia"
                        },
                        new
                        {
                            Id = 63,
                            Description = "Antropologia"
                        },
                        new
                        {
                            Id = 64,
                            Description = "Arqueologia"
                        },
                        new
                        {
                            Id = 65,
                            Description = "História"
                        },
                        new
                        {
                            Id = 66,
                            Description = "Geografia"
                        },
                        new
                        {
                            Id = 67,
                            Description = "Psicologia"
                        },
                        new
                        {
                            Id = 68,
                            Description = "Educação"
                        },
                        new
                        {
                            Id = 69,
                            Description = "Ciência Política"
                        },
                        new
                        {
                            Id = 70,
                            Description = "Teologia"
                        },
                        new
                        {
                            Id = 71,
                            Description = "Lingüística"
                        },
                        new
                        {
                            Id = 72,
                            Description = "Letras"
                        },
                        new
                        {
                            Id = 73,
                            Description = "Artes"
                        });
                });

            modelBuilder.Entity("ShareMyPaper.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("DocumentExtension")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DocumentId")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasIndex("InstitutionId");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1f03601e-4650-4d79-b069-a74dc3ae33f2",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@admin.com",
                            NormalizedUserName = "admin@admin.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKbt0lj9xoUk/GftVq9xZx6bDiRStrAxScYCCo5o9tpndcQTg2QvfSJxZib0FxkiDg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bf37e55b-14bb-4c63-9dd4-e668dcb141ba",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com",
                            DocumentExtension = "",
                            DocumentId = "",
                            IsActive = true,
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("ApplicationUserKnowledgeArea", b =>
                {
                    b.HasOne("ShareMyPaper.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ApplicationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShareMyPaper.Domain.Entities.KnowledgeArea", null)
                        .WithMany()
                        .HasForeignKey("KnowledgeAreasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShareMyPaper.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("ShareMyPaper.Domain.Entities.Institution", "Institution")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("InstitutionId");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("ShareMyPaper.Domain.Entities.Institution", b =>
                {
                    b.Navigation("ApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
