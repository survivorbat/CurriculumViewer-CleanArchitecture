using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Constants
{
    public static class CourseRoutes
    {
        /* ### COURSES ### */
        public const string GET_COURSES = "get-courses";
        public const string POST_COURSE = "post-courses";

        /* ### COURSE ### */
        public const string GET_COURSE = "get-course";
        public const string PUT_COURSE = "put-course";
        public const string DELETE_COURSE = "delete-course";

        /* ### COURSES MODULES ### */
        public const string GET_COURSE_MODULES = "get-course-modules";
        public const string POST_COURSE_MODULES = "post-course-modules";

        /* ### COURSE MODULES MODULE ### */
        public const string GET_COURSE_MODULES_MODULE = "get-course-module";
        public const string DELETE_COURSE_MODULES_MODULE = "delete-course-module";
    }
}
