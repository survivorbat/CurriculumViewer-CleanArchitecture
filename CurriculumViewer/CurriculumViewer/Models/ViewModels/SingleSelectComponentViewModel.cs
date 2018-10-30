using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
    public class SingleSelectComponentViewModel
    {
        /// <summary>
        /// Items
        /// </summary>
        public IEnumerable<object> Items { get; set; } = new List<object>();

        /// <summary>
        /// What thing to show
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Name of the input
        /// </summary>
        public string InputName { get; set; }

        public string CurrentValue { get; set; }
    }
}
