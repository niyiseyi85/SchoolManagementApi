using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Common.Model;
using SchoolManagement.Model.DTO.CourseDto;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CourseController : ControllerBase
  {
    private readonly ICourseService _courseServices;

    public CourseController(ICourseService courseServices)
    {
      _courseServices = courseServices;
    }
    [HttpGet("getCourseById/{id:int}")]    
    [ProducesDefaultResponseType(typeof(CourseDto))]
    public async Task<IActionResult> GetCourseById (int id)
    {
      var response = await _courseServices.GetCourseByIdAsync(id);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpGet("getCourse")]
    [ProducesDefaultResponseType(typeof(CourseDto))]
    public async Task<IActionResult> GetCourse ()
    {
      var response = await _courseServices.GetAllCourseAsync();
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
    [HttpPost("CreateCourse")]
    [ProducesDefaultResponseType(typeof(CourseDto))]
    public async Task<IActionResult> GetUser(CourseDto request)
    {
      var response = await _courseServices.CreateCourseAsync(request);
      Result res = Result.Combine(response);
      if (res.IsFailure)
        if (response.Equals(null))
          return BadRequest("Invalid request");
      return Ok(response.Value);
    }
  }
}
