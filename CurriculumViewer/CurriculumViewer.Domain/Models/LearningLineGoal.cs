namespace CurriculumViewer.Domain.Models
{
    public class LearningLineGoal
    {
        public virtual Goal Goal { get; set; }

        public int GoalId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="LearningLine"/> object as learningline-goal
        /// </summary>
        public virtual LearningLine LearningLine { get; set; }

        /// <summary>
        /// Gets or sets the module ID of the learning line id
        /// </summary>
        public int LearningLineId { get; set; }
    }
}
