using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Common.Model;
using SchoolManagement.Data;
using SchoolManagement.Data.IRepository;
using SchoolManagement.Model.DTO.CourseDto;

using SchoolManagement.Model.Model;
using SchoolManagement.Model.ResponseModel;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
  public class CourseService : ICourseService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, DataContext context, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _context = context;
      _mapper = mapper;
    }
    public async Task<Result<ResponseModel>> CreateCourseAsync(CourseDto request)
    {
      var response = new ResponseModel();
      var adminExist = await _context.Course.FirstOrDefaultAsync(x => x.CousreTitle == request.CousreTitle);
      if (adminExist == null)
      {
        var course = _mapper.Map<Course>(request);
        
        await _unitOfWork.CourseRepository.Add(course);
        try
        {
          await _unitOfWork.SaveAsync();
          response.IsSuccessful = true;
          response.Message = CourseResponseModel.Messages.CourseCreatedSuccessful;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel>($"{CourseResponseModel.ErrorMessages.CourseCreationFailed} - {ex.Message} : {ex.InnerException}");
        }
      }
      else
      {
        return Result.Failure<ResponseModel>($"{CourseResponseModel.ErrorMessages.CourseCreationFailed}");
      }
      return response;
    }
    public async Task<Result<ResponseModel<List<CourseDto>>>> GetAllCourseAsync()
    {
      var response = new ResponseModel<List<CourseDto>>();
      var course =await _unitOfWork.CourseRepository.GetAll();
      var mappedCourse = _mapper.Map<List<CourseDto>>(course);
      response.Data = mappedCourse;
      return response;
    }
    public async Task<Result<ResponseModel<CourseDto>>> GetCourseByIdAsync(int Id)
    {
      var response = new ResponseModel<CourseDto>();
      var course = await _unitOfWork.CourseRepository.FirstOrDefault(query => query.Id == Id);

      if (course == null)
      {
        response.IsSuccessful = false;
        response.Message = CourseResponseModel.ErrorMessages.CourseNotExist;
      }
      else
      {
        try
        {
          var result = _mapper.Map<CourseDto>(course);
          response.IsSuccessful = true;
          response.Message = CourseResponseModel.Messages.CourseByIdSuccessful;
          response.Data = result;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel<CourseDto>>($"{CourseResponseModel.ErrorMessages.CourseByIdError} - {ex.Message} : {ex.InnerException}");
        }
      }
      return response;
    }
  }
}
