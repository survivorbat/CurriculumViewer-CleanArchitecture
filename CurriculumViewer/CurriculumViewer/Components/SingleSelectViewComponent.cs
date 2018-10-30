using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Components
{
    public class SingleSelectViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(IEnumerable<object> items, ListComponentFieldTypes expression, string inputName, string currentValue)
        {
            return Task.FromResult<IViewComponentResult>(View(new SingleSelectComponentViewModel {
                InputName = inputName,
                Expression = expression.ToString(),
                Items = items,
                CurrentValue = currentValue
            }));
        }
    }
}
