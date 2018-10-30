using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Constants
{
    public static class ModuleRoutes
    {
        /* ### MODULES ### */
        public const string GET_MODULES = "get-modules";
        public const string POST_MODULES = "post-modules";

        /* ### MODULE ### */
        public const string GET_MODULE = "get-module";
        public const string PUT_MODULE = "put-module";
        public const string DELETE_MODULE = "delete-module";

        /* ### MODULES EXAMS ### */
        public const string GET_MODULE_EXAMS = "get-module-exams";
        public const string POST_MODULE_EXAMS = "post-module-exams";

        /* ### MODULE EXAMS EXAM ### */
        public const string GET_MODULE_EXAMS_EXAM = "get-module-exam";
        public const string DELETE_MODULE_EXAMS_EXAM = "delete-module-exam";

        /* ### MODULES GOALS ### */
        public const string GET_MODULE_GOALS = "get-module-goals";
        public const string POST_MODULE_GOALS = "post-module-goals";

        /* ### MODULE GOALS GOAL ### */
        public const string GET_MODULE_GOALS_GOAL = "get-module-goal";
        public const string DELETE_MODULE_GOALS_GOAL = "delete-module-goal";

        /* EXPAND IF NEEDED FOR NESTED ROUTES */
    }
}
