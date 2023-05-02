using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Model.ResponseModel
{
  public static class CourseResponseModel
  {
    public static class Messages
    {
      public const string CourseCreatedSuccessful = "Course created successful";
      public const string CourseUpdatedSuccessful = "Updated successfully";
      public const string CourseByIdSuccessful = "Getting admin by id successful";
      public const string DeleteCourseSuccessful = "deleted successfully";
    }

    public static class ErrorMessages
    {
      public const string CourseCreationFailed = "Admin Creation failed";
      public const string CourseUpdateFailed = "Admin update failed";
      public const string CourseFail = "Admin failed";
      public const string CourseNotExist = "Admin does not exist";
      public const string CourseByIdError = "Couldn't get admin by id";
      public const string ForeignKeyNotAvailable = "ID not found in Organization";
    }
  }
}
