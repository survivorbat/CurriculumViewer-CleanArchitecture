using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Constants
{
    public static class LearningLineRoutes
    {
        /* ### LEARNINGLINES ### */
        public const string GET_LEARNINGLINES = "get-learninglines";
        public const string POST_LEARNINGLINE = "post-learninglines";

        /* ### LEARNINGLINE ### */
        public const string GET_LEARNINGLINE = "get-learningline";
        public const string PUT_LEARNINGLINE = "put-learningline";
        public const string DELETE_LEARNINGLINE = "delete-learningline";

        /* ### LEARNINGLINE GOALS ### */
        public const string GET_LEARNINGLINE_GOALS = "get-learningline-goals";
        public const string POST_LEARNINGLINE_GOALS = "post-learningline-goals";

        /* ### LEARNINGLINE GOALS GOAL ### */
        public const string GET_LEARNINGLINE_GOALS_GOAL = "get-learningline-goal";
        public const string DELETE_LEARNINGLINE_GOALS_GOAL = "delete-learningline-goal";
    }
}
