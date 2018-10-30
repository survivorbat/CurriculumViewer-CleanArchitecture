using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Components
{
    public class MultiSelectViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(IEnumerable<object> items, ListComponentFieldTypes expression, string inputName, string[] currentValues)
        {
            MultiSelectComponentViewModel list = new MultiSelectComponentViewModel()
            {
                Items = items ?? new List<object>(),
                Expression = expression.ToString() ?? ListComponentFieldTypes.Name.ToString(),
                InputName = inputName ?? "",
                CurrentValues = currentValues ?? new string[0]
            };
            return Task.FromResult<IViewComponentResult>(View(list));
        }
    }
}
