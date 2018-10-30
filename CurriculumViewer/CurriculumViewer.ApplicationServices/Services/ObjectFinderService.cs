using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CurriculumViewer.ApplicationServices.Services
{
    public class ObjectFinderService<T> : IObjectFinderService<T> where T : class
    {
        /// <summary>
        /// The service used to retrieve the objects
        /// </summary>
        private IGenericService<T> genericService;

        /// <summary>
        /// Cache to keep the items in memory
        /// </summary>
        private ICollection<T> cache;

        /// <summary>
        /// Cached parameters in case we need them
        /// </summary>
        private string[] cachedParams;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="genericService"></param>
        public ObjectFinderService(IGenericService<T> genericService)
        {
            this.genericService = genericService;

            cache = new List<T>();
            cachedParams = new string[0];
        }

        /// <summary>
        /// Return if ids are valid
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool AreIdsValid(string[] ids)
        {
            if (cache == null || this.cachedParams != ids)
            {
                this.RetrieveData(ids);
            }
            return ids.Length == cache.Count;
        }

        /// <summary>
        /// Return if ids are valid
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool AreIdsValid(int[] ids)
        {
            return this.AreIdsValid(Array.ConvertAll(ids, x => x.ToString()));
        }

        /// <summary>
        /// Retrieve objects
        /// If they are cached then return those
        /// If they are cached and no ids are provided throw an exception
        /// If they are not cached and ids are provided retrieve objects
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ICollection<T> GetObjects(string[] ids = null)
        {
            if (cache == null && ids == null)
            {
                throw new ArgumentNullException("Cached values are not set and no parameter is given for the ids");
            }

            if (cache == null || cachedParams != ids)
            {
                cachedParams = ids;
                this.RetrieveData(ids);
            }

            return cache;
        }

        public ICollection<T> GetObjects(int[] ids = null)
        {
            return this.GetObjects(Array.ConvertAll(ids, x => x.ToString()));
        }

        /// <summary>
        /// Retrieve data from service with the ids, then put them in the cache
        /// </summary>
        /// <param name="ids"></param>
        private void RetrieveData(string[] ids)
        {
            List<string> idList = new List<string>(ids);
            Expression<Func<T, bool>>[] filters = new Expression<Func<T, bool>>[] {
                 (x) => DoesArrayContainId(idList, x)
            };
            this.cache = genericService.FindBy(filters).ToList();
        }

        /// <summary>
        /// Does array contain id
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool DoesArrayContainId(List<string> ids, T entity)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty("Id");
            string value = propertyInfo.GetValue(entity).ToString();
            return value != null && ids.Contains(value);
        }
    }
}