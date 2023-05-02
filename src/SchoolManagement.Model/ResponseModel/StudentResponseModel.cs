using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.ResponseModel
{
  public static class StudentResponseModel
  {
    public static class Messages
    {
      public const string StudentCreatedSuccessful = "Student created successful";
      public const string StudentUpdatedSuccessful = "Updated successfully";
      public const string StudentByIdSuccessful = "Getting Student by id successful";
      public const string DeleteAdminSuccessful = "deleted successfully";
    }

    public static class ErrorMessages
    {
      public const string StudentCreationFailed = "Student Creation failed";
      public const string StudentUpdateFailed = "Student update failed";
      public const string StudentFail = "Student failed";
      public const string StudentNotExist = "Student des not exist";
      public const string StudentByIdError = "Couldn't get admin by id";
      public const string ForeignKeyNotAvailable = "ID not found in Organization";
    }
  }
}
