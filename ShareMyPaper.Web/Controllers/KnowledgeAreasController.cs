using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Dtos.Output;
using ShareMyPaper.Application.Interfaces.Repositories;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KnowledgeAreasController : ControllerBase
{
    private readonly IKnowledgeAreaRepository _knowledgeAreaRepository;
    private readonly IMapper _mapper;
    public KnowledgeAreasController(IKnowledgeAreaRepository knowledgeAreaRepository, IMapper mapper)
    {
        _knowledgeAreaRepository = knowledgeAreaRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(_mapper.Map<IEnumerable<KnowledgeAreaOutputDTO>>(await _knowledgeAreaRepository.ListAllAsync()));
    }
}
