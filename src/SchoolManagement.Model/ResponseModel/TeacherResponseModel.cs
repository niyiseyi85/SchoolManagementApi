using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.ResponseModel
{
  public static class TeacherResponseModel
  {
    public static class Messages
    {
      public const string TeacherCreatedSuccessful = "Admin created successful";
      public const string AdminUpdatedSuccessful = "Updated successfully";
      public const string GetAdminByIdSuccessful = "Getting admin by id successful";
      public const string DeleteAdminSuccessful = "deleted successfully";
    }

    public static class ErrorMessages
    {
      public const string TeacherCreationFailed = "Admin Creation failed";
      public const string TeacherUpdateFailed = "Admin update failed";
      public const string TeacherFail = "Admin failed";
      public const string TeacherNotExist = "Admin not existing";
      public const string TeacherByIdError = "Couldn't get admin by id";
      public const string ForeignKeyNotAvailable = "ID not found in Organization";
    }
  }
}
