using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumViewer.ApplicationServices.Abstract.Services
{
    public interface IObjectFinderService<T>
    {
        /// <summary>
        /// Are the ids provided valid
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool AreIdsValid(string[] ids);

        /// <summary>
        /// Are the ids provided valid
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool AreIdsValid(int[] ids);

        /// <summary>
        /// Return objects
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ICollection<T> GetObjects(string[] ids = null);

        /// <summary>
        /// Return objects
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        ICollection<T> GetObjects(int[] ids = null);
    }
}
