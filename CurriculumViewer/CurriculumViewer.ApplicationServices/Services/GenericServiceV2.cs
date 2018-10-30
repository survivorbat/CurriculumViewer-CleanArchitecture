using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Threading.Tasks;

namespace CurriculumViewer.Services
{
    /// <summary>
    /// This is a generic service for simple functions that only require a CRUD interface
    /// Feel free to create specific services and service interfaces for special cases
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericServiceV2 : IGenericServiceV2
    {
        /// <summary>
        /// Repository to utilize
        /// </summary>
        protected readonly IGenericRepositoryV2 GenericRepository;
        protected readonly IActivityLoggerService activityLogger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="genericRepository">Repository</param>
        public GenericServiceV2(IGenericRepositoryV2 genericRepository, IActivityLoggerService activityLogger)
        {
            this.GenericRepository = genericRepository;
            this.activityLogger = activityLogger;
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item to be deleted</param>
        /// <returns>Returncode</returns>
        public int Delete<T>(T item) where T: class
        {
            int result = this.GenericRepository.Delete<T>(item);
            if (result == 1)
            {
                activityLogger.Delete($"Een '{((T) item).GetType().Name}' object is verwijderd. ({GetIdentifier(item)})");
            }
            return result;
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item">Item to be updated</param>
        /// <returns>Returncode</returns>
        public int Update<T>(T item) where T : class
        {
            int result = this.GenericRepository.Update<T>(item);
            if (result == 1)
            {
                activityLogger.Update($"Een '{((T)item).GetType().Name}' object is aangepast. ({GetIdentifier(item)})");
            }
            return result;
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        /// <returns>Returncode</returns>
        public int Insert<T>(T item) where T : class
        {
            int result = this.GenericRepository.Insert<T>(item);
            if (result == 1)
            {
                activityLogger.Create($"Een '{((T)item).GetType().Name}' object is verwijderd. ({GetIdentifier(item)})");
            }
            return result;
        }

        /// <summary>
        /// Find all objects
        /// </summary>
        /// <param name="includes"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<T> FindAll<T>(string[] includes = null, int limit = -1, int offset = -1) where T : class
        {
            return this.GenericRepository.FindAll<T>(includes, limit, offset);
        }

        /// <summary>
        /// Find objects by filters
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="includes"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy<T>(Expression<Func<T, bool>>[] filters = null, string[] includes = null, int limit = -1, int offset = -1) where T : class
        {
            return this.GenericRepository.FindBy<T>(filters, includes, limit, offset);
        }

        /// <summary>
        /// Get object by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T FindById<T>(int id, string[] includes = null) where T : class
        {
            return this.FindById<T>(id.ToString(), includes);
        }

        /// <summary>
        /// Get object by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T FindById<T>(string id, string[] includes = null) where T : class
        {
            return this.GenericRepository.FindById<T>(id, includes);
        }

        /// <summary>
        /// Get name or id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetIdentifier<T>(T item)
        {
            Type type = item.GetType();
            return type.GetProperty("FullName")?.GetValue(item, null)?.ToString() ?? type.GetProperty("Name")?.GetValue(item, null)?.ToString() ?? type.GetProperty("Id")?.GetValue(item, null)?.ToString() ?? "Geen voorbeeld";
        }
    }
}
