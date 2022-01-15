using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareMyPaper.Application.Dtos.Input;
using ShareMyPaper.Application.Dtos.Output;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Application.Interfaces.Services;
using ShareMyPaper.Application.Validators;
using ShareMyPaper.Domain.Entities;

namespace ShareMyPaper.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstitutionsController : ControllerBase
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentUserRepository _currentUser;
    public InstitutionsController(IInstitutionRepository institutionRepository, IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserRepository currentUser)
    {
        _institutionRepository = institutionRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        if (HttpContext.User.IsInRole("institution moderator"))
        {
            return Ok(_mapper.Map<IEnumerable<InstitutionOutputDTO>>(await _institutionRepository.ListAsync(i => i.Id == _currentUser.InstitutionId)));

        }
        return Ok(_mapper.Map<IEnumerable<InstitutionOutputDTO>>(await _institutionRepository.ListAllAsync()));
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> Post(InstitutionInputDTO dto)
    {
        var validationResult = await new InstitutionDTOValidator().ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        var institution = _mapper.Map<Institution>(dto);
        var result = await _institutionRepository.AddAsync(institution);
        await _unitOfWork.Commit();
        return Ok(_mapper.Map<InstitutionOutputDTO>(result));

    }
    [Authorize(Roles = "admin")]
    [HttpDelete]
    [Route("{institutionId}")]
    public async Task<IActionResult> Delete(int institutionId)
    {
        var institution = await _institutionRepository.FirstAsync(i => i.Id == institutionId);
        _institutionRepository.Delete(institution);
        await _unitOfWork.Commit();
        return Ok();
    }

    [Authorize(Roles = "admin, institution moderator")]
    [HttpPut]
    [Route("{institutionId}")]
    public async Task<IActionResult> Put(InstitutionInputDTO dto, [FromRoute] int institutionId)
    {
        var validationResult = await new InstitutionDTOValidator().ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
        }
        if (HttpContext.User.IsInRole("institution moderator"))
        {
            if (_currentUser.InstitutionId != institutionId) return BadRequest();
        }
        var institution = await _institutionRepository.FirstOrDefaultAsync(v => v.Id == institutionId);
        if (institution is not null)
        {
            institution.Description = dto.Description;
            institution.Country = dto.Country;
            institution.City = dto.City;
            institution.State = dto.State;
            _institutionRepository.Update(institution);
            await _unitOfWork.Commit();
            return Ok(institution);
        }
        return BadRequest();
    }
}
