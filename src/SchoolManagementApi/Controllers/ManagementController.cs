using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Model.DTO.ManagementDto;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ManagementController : ControllerBase
  {
    private readonly IManagementService _ManagementServices;

    public ManagementController(IManagementService ManagementServices)
    {
      _ManagementServices = ManagementServices;
    }
    [HttpGet("getManagementById/{id:int}")]
    [ProducesDefaultResponseType(typeof(AdminDto))]
    public async Task<IActionResult> GetManagementById(int id)
    {
      var response = await _ManagementServices.GetAdminByIdAsync(id);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpGet("getManagement")]
    [ProducesDefaultResponseType(typeof(AdminDto))]
    public async Task<IActionResult> GetManagement()
    {
      var response = await _ManagementServices.GetAllAdminAsync();
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpPost("CreateManagement")]
    [ProducesDefaultResponseType(typeof(AdminDto))]
    public async Task<IActionResult> GetUser(AdminDto request)
    {
      var response = await _ManagementServices.CreateAdminAsync(request);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
  }
}
