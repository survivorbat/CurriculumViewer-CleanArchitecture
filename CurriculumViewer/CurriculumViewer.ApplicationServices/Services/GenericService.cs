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
    public class GenericService<T> : IGenericService<T> where T: class
    {
        /// <summary>
        /// Repository to utilize
        /// </summary>
        protected readonly IGenericRepository<T> GenericRepository;
        protected readonly IActivityLoggerService activityLogger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="genericRepository">Repository</param>
        public GenericService(IGenericRepository<T> genericRepository, IActivityLoggerService activityLogger)
        {
            this.GenericRepository = genericRepository;
            this.activityLogger = activityLogger;
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item to be deleted</param>
        /// <returns>Returncode</returns>
        public int Delete(T item)
        {
            int result = this.GenericRepository.Delete(item);
            if (result == 1)
            {
                activityLogger.Delete($"Een '{item.GetType().Name}' object is verwijderd. ({GetIdentifier(item)})");
            }
            return result;
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item">Item to be updated</param>
        /// <returns>Returncode</returns>
        public int Update(T item)
        {
            int result = this.GenericRepository.Update(item);
            if (result == 1)
            {
                activityLogger.Update($"Een '{item.GetType().Name}' object is aangepast. ({GetIdentifier(item)})");
            }
            return result;
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <param name="item">Item to be inserted</param>
        /// <returns>Returncode</returns>
        public int Insert(T item)
        {
            int result = this.GenericRepository.Insert(item);
            if (result == 1)
            {
                activityLogger.Create($"Een '{item.GetType().Name}' object is verwijderd. ({GetIdentifier(item)})");
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
        public IEnumerable<T> FindAll(string[] includes = null, int limit = -1, int offset = -1)
        {
            return this.GenericRepository.FindAll(includes, limit, offset);
        }

        /// <summary>
        /// Find objects by filters
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="includes"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(Expression<Func<T, bool>>[] filters = null, string[] includes = null, int limit = -1, int offset = -1)
        {
            return this.GenericRepository.FindBy(filters, includes, limit, offset);
        }

        /// <summary>
        /// Get object by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T FindById(int id, string[] includes = null)
        {
            return this.FindById(id.ToString(), includes);
        }

        /// <summary>
        /// Get object by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T FindById(string id, string[] includes = null)
        {
            return this.GenericRepository.FindById(id, includes);
        }

        /// <summary>
        /// Get name or id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string GetIdentifier(T item)
        {
            Type type = item.GetType();
            return type.GetProperty("FullName")?.GetValue(item, null)?.ToString() ?? type.GetProperty("Name")?.GetValue(item, null)?.ToString() ?? type.GetProperty("Id")?.GetValue(item, null)?.ToString() ?? "Geen voorbeeld";
        }
    }
}
