using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Model.DTO.TeacherDto;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeacherController : ControllerBase
  {
    private readonly ITeacherService _teacherServices;

    public TeacherController(ITeacherService teacherServices)
    {
      _teacherServices = teacherServices;
    }
    [HttpGet("getTeacherById/{id:int}")]
    [ProducesDefaultResponseType(typeof(TeacherDto))]
    public async Task<IActionResult> GetCourseById(int id)
    {
      var response = await _teacherServices.GetTeacherByIdAsync(id);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpGet("getTeacher")]
    [ProducesDefaultResponseType(typeof(TeacherDto))]
    public async Task<IActionResult> GetCourse()
    {
      var response = await _teacherServices.GetAllTeacherAsync();
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpPost("CreateTeacher")]
    [ProducesDefaultResponseType(typeof(TeacherDto))]
    public async Task<IActionResult> GetUser(TeacherDto request)
    {
      var response = await _teacherServices.CreateTeacherAsync(request);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
  }
}
