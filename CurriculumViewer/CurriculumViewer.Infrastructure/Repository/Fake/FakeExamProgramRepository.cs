using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CurriculumViewer.Repository.Fake
{
	/// <summary>
	/// Fake repository class that defines specific data operations.
	/// </summary>
	/// <typeparam name="T">Repository class of study years.</typeparam>
	public class FakeExamProgramRepository //: IGenericRepository<StudyYear>
    {
        /// <summary>
        /// Fake data
        /// </summary>
        private static readonly IEnumerable<ExamProgram> Data = new List<ExamProgram>() {
            new ExamProgram()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            },
            new ExamProgram()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            }
        };

		/// <summary>
		/// Deletes an existing study year in the database.
		/// </summary>
		/// <param name="item">The study year to delete.</param>
		/// <returns>1 if it succeeded to delete a study year in the database; otherwise 0 or -1.</returns>
		public int Delete(ExamProgram item)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Gets a <see cref="IQueryable{T}"/> that represents all study years.
		/// </summary>
		/// <param name="includes">Expression to include.</param>
		/// <returns>Retrieves all the elements that match the conditions defined by the specified expression.</returns>
		public IQueryable<ExamProgram> FindAll(Expression<Func<ExamProgram, object>>[] includes = null)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Gets a <see cref="IQueryable{T}"/> that represents all study years.
		/// </summary>
		/// <param name="includes">Expression to include.</param>
		/// <returns>Retrieves all the elements that match the conditions defined by the specified expression.</returns>
		public IQueryable<ExamProgram> FindBy(Expression<Func<ExamProgram, bool>>[] filter = null, Expression<Func<ExamProgram, object>>[] includes = null)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Searches for an study year that matches the ID, and returns the first occurrence within the entire <see cref="ICollection{T}"/>.
		/// </summary>
		/// <param name="id">The ID of the study year to find.</param>
		/// <param name="includes">Expression to include.</param>
		/// <returns>The result of the search.</returns>
		public ExamProgram FindById(int id, Expression<Func<ExamProgram, object>>[] includes = null)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Creates a new study year in the database.
		/// </summary>
		/// <param name="item">The study year to create.</param>
		/// <returns>1 if it succeeded to create an new study year in the database; otherwise 0 or -1.</returns>
		public int Insert(ExamProgram item)
        {
            throw new NotImplementedException();
        }

		/// <summary>
		/// Updates an study year in the database.
		/// </summary>
		/// <param name="item">The study year to update.</param>
		/// <returns>1 if it succeeded to update a study year in the database; otherwise 0 or -1.</returns>
		public int Update(ExamProgram item)
        {
            throw new NotImplementedException();
        }
    }
}
