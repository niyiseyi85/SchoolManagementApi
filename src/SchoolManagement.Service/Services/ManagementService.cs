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
using SchoolManagement.Model.Model;
using SchoolManagement.Model.ResponseModel;
using SchoolManagement.Service.IServices;

namespace SchoolManagement.Service.Services
{
  public class ManagementService : IManagementService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ManagementService(IUnitOfWork unitOfWork, DataContext context, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _context = context;
      _mapper = mapper;
    }
    public async Task<Result<ResponseModel>> CreateAdminAsync(AdminDto request)
    {
      var response = new ResponseModel();
      var adminExist = await _context.Management.FirstOrDefaultAsync(x => x.Email == request.Email);
      if (adminExist == null)
      {
        var admin = _mapper.Map<Management>(request);
        admin.CreatedAt = DateTime.Now;
        await _unitOfWork.ManagementRepository.Add(admin);
        try
        {
          await _unitOfWork.SaveAsync();
          response.IsSuccessful = true;
          response.Message = AdminResponseModel.Messages.AdminCreatedSuccessful;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel>($"{AdminResponseModel.ErrorMessages.AdminCreationFailed} - {ex.Message} : {ex.InnerException}");
        }
      }
      else
      {
        return Result.Failure<ResponseModel>($"{AdminResponseModel.ErrorMessages.AdminCreationFailed}");
      }
      return response;
    }
    public async Task<Result<ResponseModel<List<AdminDto>>>> GetAllAdminAsync()
    {
      var response = new ResponseModel<List<AdminDto>>();
      var course =await _unitOfWork.ManagementRepository.GetAll();
      var mappedCourse = _mapper.Map<List<AdminDto>>(course);
      response.Data = mappedCourse;
      return response;
    }
    public async Task<Result<ResponseModel<AdminDto>>> GetAdminByIdAsync(int Id)
    {
      var response = new ResponseModel<AdminDto>();
      var admin = await _unitOfWork.ManagementRepository.FirstOrDefault(query => query.Id == Id);

      if (admin == null)
      {
        response.IsSuccessful = false;
        response.Message = AdminResponseModel.ErrorMessages.AdminNotExist;
      }
      else
      {
        try
        {
          var result = _mapper.Map<AdminDto>(admin);
          response.IsSuccessful = true;
          response.Message = AdminResponseModel.Messages.AdminByIdSuccessful;
          response.Data = result;
        }
        catch (Exception ex)
        {
          return Result.Failure<ResponseModel<AdminDto>>($"{AdminResponseModel.ErrorMessages.AdminByIdError} - {ex.Message} : {ex.InnerException}");
        }
      }
      return response;
    }
    
  }
}
