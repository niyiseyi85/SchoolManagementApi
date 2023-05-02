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
using SchoolManagement.Model.DTO.TeacherDto;
using SchoolManagement.Model.Model;
using SchoolManagement.Model.ResponseModel;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
  public class TeacherService : ITeacherService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TeacherService(IUnitOfWork unitOfWork, DataContext context, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _context = context;
      _mapper = mapper;
    }
    public async Task<Result<ResponseModel>> CreateTeacherAsync(TeacherDto request)
    {
      var response = new ResponseModel();
      var teacherExist = await _context.Teacher.FirstOrDefaultAsync(x => x.Email == request.Email);
      if (teacherExist == null)
      {
        var teacher = _mapper.Map<Teacher>(request);        
        await _unitOfWork.TeacherRepository.Add(teacher);
        try
        {
          await _unitOfWork.SaveAsync();
          response.IsSuccessful = true;
          response.Message = TeacherResponseModel.Messages.TeacherCreatedSuccessful;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel>($"{TeacherResponseModel.ErrorMessages.TeacherCreationFailed} - {ex.Message} : {ex.InnerException}");
        }
      }
      else
      {
        return Result.Failure<ResponseModel>($"{TeacherResponseModel.ErrorMessages.TeacherCreationFailed}");
      }
      return response;
    }
    public async Task<Result<ResponseModel<List<TeacherDto>>>> GetAllTeacherAsync()
    {
      var response = new ResponseModel<List<TeacherDto>>();
      var teachers =await _unitOfWork.TeacherRepository.GetAll();
      var mappedTeacher = _mapper.Map<List<TeacherDto>>(teachers);
      response.Data = mappedTeacher;
      return response;
    }
    public async Task<Result<ResponseModel<TeacherDto>>> GetTeacherByIdAsync(int Id)
    {
      var response = new ResponseModel<TeacherDto>();
      var admin = await _unitOfWork.TeacherRepository.FirstOrDefault(query => query.Id == Id);

      if (admin == null)
      {
        response.IsSuccessful = false;
        response.Message = TeacherResponseModel.ErrorMessages.TeacherNotExist;
      }
      else
      {
        try
        {
          var result = _mapper.Map<TeacherDto>(admin);
          response.IsSuccessful = true;
          response.Message = AdminResponseModel.Messages.AdminByIdSuccessful;
          response.Data = result;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel<TeacherDto>>($"{TeacherResponseModel.ErrorMessages.TeacherByIdError} - {ex.Message} : {ex.InnerException}");
        }
      }
      return response;
    }
  }
}
