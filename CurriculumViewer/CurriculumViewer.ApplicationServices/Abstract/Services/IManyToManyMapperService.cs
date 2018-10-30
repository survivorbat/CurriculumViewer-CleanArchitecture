using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumViewer.ApplicationServices.Abstract.Services
{
    /// <summary>
    /// Map entities
    /// </summary>
    /// <typeparam name="P">Parent entity</typeparam>
    /// <typeparam name="M">Mapping entity</typeparam>
    /// <typeparam name="T">Target entity</typeparam>
    public interface IManyToManyMapperService<P, M, T>
    {
        /// <summary>
        /// Get many to many entities
        /// </summary>
        /// <returns></returns>
        ICollection<M> GetMappedEntities(P parent, ICollection<T> targetEntities);
    }
}
