using AutoMapper;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Dtos.Output;
using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Application.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationUser, StudentOutputDTO>();
        CreateMap<Institution, InstitutionOutputDTO>();
        CreateMap<KnowledgeArea, KnowledgeAreaOutputDTO>();
        CreateMap<Post, PostInputDTO>();
        CreateMap<PostInputDTO, Post>();
    }
}
