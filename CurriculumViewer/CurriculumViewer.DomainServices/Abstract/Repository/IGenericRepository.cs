using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CurriculumViewer.Abstract.Repository
{
	/// <summary>
	/// Generic repository class that defines specific data operations.
	/// </summary>
	/// <typeparam name="T">Repository class of <see cref="{T}"/></typeparam>
	public interface IGenericRepository<T> where T: class
    {
		/// <summary>
		/// Gets a <see cref="IQueryable{T}"/> that represents all <see cref="{T}"/>.
		/// </summary>
		/// <param name="includes">Expression to include.</param>
		/// <returns>Retrieves all the elements that match the conditions defined by the specified expression.</returns>
		IEnumerable<T> FindAll(string[] includes = null, int limit = 0, int offset = 0);

		/// <summary>
		/// Find items with filters
		/// </summary>
		/// <param name="filters">Expression to filter on.</param>
		/// <param name="includes">Expression to include.</param>
		/// <returns>Retrieves all the elements that match the conditions defined by the specified expression.</returns>
		IEnumerable<T> FindBy(Expression<Func<T, bool>>[] filters = null, string[] includes = null, int limit = 0, int offset = 0);

		/// <summary>
		/// Searches for an element that matches the ID, and returns the first occurrence within the entire <see cref="ICollection{T}"/>.
		/// </summary>
		/// <param name="id">The ID of the object <see cref="{T}"/> to find.</param>
		/// <param name="includes">Expression to include.</param>
		/// <returns>The result of the search.</returns>
		T FindById(int id, string[] includes = null);

        /// <summary>
		/// Searches for an element that matches the ID, and returns the first occurrence within the entire <see cref="ICollection{T}"/>.
		/// </summary>
		/// <param name="id">The ID of the object <see cref="{T}"/> to find.</param>
		/// <param name="includes">Expression to include.</param>
		/// <returns>The result of the search.</returns>
		T FindById(string id, string[] includes = null);

        /// <summary>
        /// Creates an new object <see cref="{T}"/> in the database.
        /// </summary>
        /// <param name="item">The object <see cref="{T}"/> to create.</param>
        /// <returns>1 if it succeeded to update a <see cref="{T}"/> object in the database; otherwise 0 or -1.</returns>
        int Insert(T item);

		/// <summary>
		/// Updates an existing object <see cref="{T}"/> in the database.
		/// </summary>
		/// <param name="item">The object <see cref="{T}"/> to update.</param>
		/// <returns>1 if it succeeded to update a <see cref="{T}"/> object in the database; otherwise 0 or -1.</returns>
		int Update(T item);

		/// <summary>
		/// Deletes an existing object <see cref="{T}"/> in the database.
		/// </summary>
		/// <param name="item">The object <see cref="{T}"/> to delete.</param>
		/// <returns>1 if it succeeded to delete a <see cref="{T}"/> object in the database; otherwise 0 or -1.</returns>
		int Delete(T item);
    }
}
