using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Constants
{
    public static class TeacherRoutes
    {
        /* ### TEACHERS ### */
        public const string GET_TEACHERS = "get-teachers";
        public const string POST_TEACHER = "post-teachers";

        /* ### TEACHER ### */
        public const string GET_TEACHER = "get-teacher";
        public const string PUT_TEACHER = "put-teacher";
        public const string DELETE_TEACHER = "delete-teacher";

        /* ### TEACHER COURSES ### */
        public const string GET_TEACHER_COURSES = "get-teacher-courses";

        /* ### TEACHER COURSES COURSE ### */
        public const string GET_TEACHER_COURSES_COURSE = "get-teacher-course";

        /* ### TEACHER EXAMS ### */
        public const string GET_TEACHER_EXAMS = "get-teacher-exams";

        /* ### TEACHER EXAMS EXAM ### */
        public const string GET_TEACHER_EXAMS_EXAM = "get-teacher-exam";

        /* ### TEACHER MODULES ### */
        public const string GET_TEACHER_MODULES = "get-teacher-modules";

        /* ### TEACHER MODULES MODULE ### */
        public const string GET_TEACHER_MODULES_MODULE = "get-teacher-module";

        /* EXPAND IF NEEDED FOR NESTED ROUTES */
    }
}
