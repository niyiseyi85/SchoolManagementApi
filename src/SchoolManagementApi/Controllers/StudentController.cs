using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Model.DTO.StudentDto;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly IStudentService _studentServices;

    public StudentController(IStudentService studentServices)
    {
      _studentServices = studentServices;
    }
    [HttpGet("getStudentById/{id:int}")]
    [ProducesDefaultResponseType(typeof(StudentDto))]
    public async Task<IActionResult> GetCourseById(int id)
    {
      var response = await _studentServices.GetStudentByIdAsync(id);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpGet("getStudent")]
    [ProducesDefaultResponseType(typeof(StudentDto))]
    public async Task<IActionResult> GetCourse()
    {
      var response = await _studentServices.GetAllStudentAsync();
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpPost("CreateStudent")]
    [ProducesDefaultResponseType(typeof(StudentDto))]
    public async Task<IActionResult> GetUser(StudentDto request)
    {
      var response = await _studentServices.CreateStudentAsync(request);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
  }
}
