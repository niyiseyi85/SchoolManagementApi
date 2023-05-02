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
using SchoolManagement.Model.DTO.ManagementDto;
using SchoolManagement.Model.DTO.StudentDto;
using SchoolManagement.Model.Model;
using SchoolManagement.Model.ResponseModel;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
  public class StudentService : IStudentService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, DataContext context, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _context = context;
      _mapper = mapper;
    }
    public async Task<Result<ResponseModel>> CreateStudentAsync(StudentDto request)
    {
      var response = new ResponseModel();
      var adminExist = await _context.Student.FirstOrDefaultAsync(x => x.Email == request.Email);
      if (adminExist == null)
      {
        var student = _mapper.Map<Student>(request);
        student.CreatedAt = DateTime.Now;
        await _unitOfWork.StudentRepository.Add(student);
        try
        {
          await _unitOfWork.SaveAsync();
          response.IsSuccessful = true;
          response.Message = StudentResponseModel.Messages.StudentCreatedSuccessful;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel>($"{StudentResponseModel.ErrorMessages.StudentCreationFailed} - {ex.Message} : {ex.InnerException}");
        }
      }
      else
      {
        return Result.Failure<ResponseModel>($"{StudentResponseModel.ErrorMessages.StudentCreationFailed}");
      }
      return response;
    }
    public async Task<Result<ResponseModel<List<StudentDto>>>> GetAllStudentAsync()
    {
      var response = new ResponseModel<List<StudentDto>>();
      var teachers =await _unitOfWork.StudentRepository.GetAll();
      var mappedStudent = _mapper.Map<List<StudentDto>>(teachers);
      response.Data = mappedStudent;
      return response;
    }
    public async Task<Result<ResponseModel<StudentDto>>> GetStudentByIdAsync(int Id)
    {
      var response = new ResponseModel<StudentDto>();
      var admin = await _unitOfWork.TeacherRepository.FirstOrDefault(query => query.Id == Id);

      if (admin == null)
      {
        response.IsSuccessful = false;
        response.Message = StudentResponseModel.ErrorMessages.StudentNotExist;
      }
      else
      {
        try
        {
          var result = _mapper.Map<StudentDto>(admin);
          response.IsSuccessful = true;
          response.Message = StudentResponseModel.Messages.StudentByIdSuccessful;
          response.Data = result;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel<StudentDto>>($"{StudentResponseModel.ErrorMessages.StudentByIdError} - {ex.Message} : {ex.InnerException}");
        }
      }
      return response;
    }
  }
}
