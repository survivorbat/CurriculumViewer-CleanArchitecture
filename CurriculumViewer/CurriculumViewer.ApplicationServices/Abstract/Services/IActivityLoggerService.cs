using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumViewer.ApplicationServices.Abstract.Services
{
    public interface IActivityLoggerService
    {
        void Create(string message);
        void Update(string message);
        void Delete(string message);
    }
}
