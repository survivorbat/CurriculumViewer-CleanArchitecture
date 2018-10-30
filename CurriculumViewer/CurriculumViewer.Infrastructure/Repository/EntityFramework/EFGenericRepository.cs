using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CurriculumViewer.Repository.EntityFramework
{
	/// <summary>
	/// Generic repository class that defines specific data operations.
	/// </summary>
	/// <typeparam name="T">Repository class of <see cref="{T}"/></typeparam>
	public class EFGenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected ApplicationDbContext applicationDbContext;

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		protected DbSet<T> entities;

		/// <summary>
		/// Initializes a new instance of the <see cref="EFGenericRepository{T}"/> class.
		/// </summary>
		/// <param name="applicationDbContext">A session with the database and can be used to query and save instances of your entities.</param>
		public EFGenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            entities = applicationDbContext.Set<T>();
		}
		
		/// <summary>
		/// Creates a new object <see cref="{T}"/> in the database.
		/// </summary>
		/// <param name="item">The object <see cref="{T}"/> to create.</param>
		/// <returns>1 if it succeeded to create an new <see cref="{T}"/> object in the database; otherwise 0 or -1.</returns>
		public int Insert(T item)
        {
            // TODO: Add error handling here
            entities.Add(item);
            if (applicationDbContext.SaveChanges() > 0)
            {
                return 1;
            }
            return -1;
        }

		/// <summary>
		/// Updates an existing object <see cref="{T}"/> in the database.
		/// </summary>
		/// <param name="item">The object <see cref="{T}"/> to update.</param>
		/// <returns>1 if it succeeded to update a <see cref="{T}"/> object in the database; otherwise 0 or -1.</returns>
		public int Update(T item)
        {
            /// Get database entry
            PropertyInfo propertyInfo = item.GetType().GetProperty("Id");
            int ItemId = (int) propertyInfo.GetValue(item, null);
            T entityInDatabase = this.entities.Find(ItemId);
            var entry = this.applicationDbContext.Entry(entityInDatabase);
         
            string[] navigations = entry.Navigations.Select(e => e.Metadata.Name).ToArray();

            T ItemWithIncludes = FindById(ItemId, navigations);
            
            foreach (PropertyInfo property in ItemWithIncludes.GetType().GetProperties())
            {
                var value = property.GetValue(item);
                try
                {
                    property.SetValue(ItemWithIncludes, value);
                }
                catch (Exception e)
                {
                    // Leave it
                }
            }
            entry.State = EntityState.Modified;

            if (applicationDbContext.SaveChanges() > 0)
            {
                return 1;
            }
  
            return -1;
        }

		/// <summary>
		/// Deletes an existing object <see cref="{T}"/> in the database.
		/// </summary>
		/// <param name="item">The object <see cref="{T}"/> to delete.</param>
		/// <returns>1 if it succeeded to delete a <see cref="{T}"/> object in the database; otherwise 0 or -1.</returns>
		public int Delete(T item)
        {
            entities.Remove(item);
            applicationDbContext.SaveChanges();
            return 1;
        }
        
        /// <summary>
        /// Find all with includes
        /// </summary>
        /// <param name="includes"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<T> FindAll(string[] includes = null, int limit = -1, int offset = -1)
        {
            IQueryable<T> query = this.entities;
            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (limit > 0 && offset > -1)
            {
                query = query.Skip(offset).Take(limit);
            }

            return query.AsEnumerable();
        }

        /// <summary>
        /// Find by criteria
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="includes"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IEnumerable<T> FindBy(Expression<Func<T, bool>>[] filters = null, string[] includes = null, int limit = -1, int offset = -1)
        {
            IQueryable<T> query = this.entities;
            if (includes != null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            
            if (filters != null)
            {
                foreach (Expression<Func<T, bool>> filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            if (limit > 0 && offset > -1)
            {
                query = query.Skip(offset).Take(limit);
            }

            return query.AsEnumerable();
        }

		/// <summary>
		/// Searches for an element that matches the ID, and returns the first occurrence within the entire <see cref="ICollection{T}"/>.
		/// </summary>
		/// <param name="id">The ID of the object <see cref="{T}"/> to find.</param>
		/// <param name="includes">Expression to include.</param>
		/// <returns>The result of the search.</returns>
		public T FindById(int id, string[] includes = null)
        {
            return this.FindById(id.ToString(), includes);
        }

        /// <summary>
		/// Searches for an element that matches the ID, and returns the first occurrence within the entire <see cref="ICollection{T}"/>.
		/// </summary>
		/// <param name="id">The ID of the object <see cref="{T}"/> to find.</param>
		/// <param name="includes">Expression to include.</param>
		/// <returns>The result of the search.</returns>
        public T FindById(string id, string[] includes = null)
        {
            Expression<Func<T, bool>>[] filters = new Expression<Func<T, bool>>[] {
                 (x) => CheckId(id, x)
            };

            return FindBy(filters, includes).FirstOrDefault();
        }

        /// <summary>
        /// Check the ID since we are using generics
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool CheckId(string id, T entity)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty("Id");
            string value = propertyInfo.GetValue(entity).ToString();
            return value != null && id == value;
        }
    }
}
