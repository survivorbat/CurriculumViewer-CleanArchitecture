using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.ApplicationServices.Abstract.Services
{
    public interface IGeneratorService<T>
    {
        void Setup();
        MemoryStream GenerateGuide(int id);
    }
}
