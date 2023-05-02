using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.ResponseModel
{
  public static class AdminResponseModel
  {
    public static class Messages
    {
      public const string AdminCreatedSuccessful = "Admin created successful";
      public const string AdminUpdatedSuccessful = "Updated successfully";
      public const string AdminByIdSuccessful = "Getting admin by id successful";
      public const string DeleteAdminSuccessful = "deleted successfully";
    }

    public static class ErrorMessages
    {
      public const string AdminCreationFailed = "Admin Creation failed";
      public const string AdminUpdateFailed = "Admin update failed";
      public const string AdminFail = "Admin failed";
      public const string AdminNotFound = "Admin not existing";
      public const string AdminByIdError = "Couldn't get admin by id";
      public const string AdminNotExist = "admin by id not exist";
      public const string ForeignKeyNotAvailable = "ID not found in Organization";
    }
  }
}
