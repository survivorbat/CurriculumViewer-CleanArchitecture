using CurriculumViewer.ApplicationServices.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CurriculumViewer.ApplicationServices.Services
{
    public class ManyToManyMapperService<P, M, T> : IManyToManyMapperService<P, M, T> where M: new() where T: new() where P: new()
    {
        /// <summary>
        /// Property that needs to be set for the parent
        /// </summary>
        private PropertyInfo idPropertyP;

        /// <summary>
        /// Main property of P
        /// </summary>
        private PropertyInfo mainPropertyP;

        /// <summary>
        /// Main property T
        /// </summary>
        private PropertyInfo mainPropertyT;

        /// <summary>
        /// Property that needs to be set for the target
        /// </summary>
        private PropertyInfo idPropertyT;

        /// <summary>
        /// Type of P
        /// </summary>
        private Type parentType;

        /// <summary>
        /// Type of T
        /// </summary>
        private Type targetType;

        /// <summary>
        /// Type of M
        /// </summary>
        private Type mappingType;

        /// <summary>
        /// Empty constructor to warmup the cache
        /// </summary>
        public ManyToManyMapperService()
        {
            SetCaches();
        }

        /// <summary>
        /// Get a list of mappingentities for the specified list
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="targetEntities"></param>
        /// <returns></returns>
        public ICollection<M> GetMappedEntities(P parent, ICollection<T> targetEntities)
        {
            ICollection<M> result = new List<M>();
            foreach (T entity in targetEntities)
            {
                result.Add(this.ConvertToM(parent, entity));
            }
            return result;
        }

        /// <summary>
        /// Convert parent and entity to mappingentity
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private M ConvertToM(P parent, T entity)
        {
            M result = new M();
            idPropertyP.SetValue(result, parentType.GetProperty("Id").GetValue(parent), null);
            idPropertyT.SetValue(result, targetType.GetProperty("Id").GetValue(entity), null);
            mainPropertyP.SetValue(result, parent);
            mainPropertyT.SetValue(result, entity);
            return result;
        }

        /// <summary>
        /// Set properties of generics
        /// </summary>
        private void SetCaches()
        {
            // Set the types for later use
            parentType = new P().GetType();
            targetType = new T().GetType();
            mappingType = new M().GetType();

            // Get properties of mapping class
            PropertyInfo[] properties = mappingType.GetProperties();

            // Loop through properties to determine the methods
            foreach (PropertyInfo property in properties)
            {
                // Get name of method
                string methodName = property.GetSetMethod().Name.ToLower();

                // If it's part of the parent, set the IdProperty of the parent
                if (methodName.Contains(parentType.Name.ToLower()))
                {
                    if (methodName.ToLower().Contains("id"))
                    {
                        idPropertyP = property;
                    }
                    else
                    {
                        mainPropertyP = property;
                    }
                }
                // Else if it's part of the target, set de IdProperty of the target
                else if (methodName.Contains(targetType.Name.ToLower()))
                {
                    if (methodName.ToLower().Contains("id"))
                    {
                        idPropertyT = property;
                    }
                    else
                    {
                        mainPropertyT = property;
                    }
                }
            }
        }
    }
}
