using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumViewer.ApplicationServices.Services
{
    public class ActivityDatabaseLoggerService : IActivityLoggerService
    {
        /// <summary>
        /// Repository that is used to add logs
        /// </summary>
        private IGenericRepository<LogItem> logItemRepository;

        /// <summary>
        /// Initialize repository
        /// </summary>
        /// <param name="logItemRepository"></param>
        public ActivityDatabaseLoggerService(IGenericRepository<LogItem> logItemRepository)
        {
            this.logItemRepository = logItemRepository;
        }

        /// <summary>
        /// Create logitem
        /// </summary>
        /// <param name="message"></param>
        public void Create(string message)
        {
            logItemRepository.Insert(new LogItem() { Message = message, LogType = LogType.Create, CreatedAt = DateTime.Now });
        }

        /// <summary>
        /// Delete logitem
        /// </summary>
        /// <param name="message"></param>
        public void Delete(string message)
        {
            logItemRepository.Insert(new LogItem() { Message = message, LogType = LogType.Delete, CreatedAt = DateTime.Now });
        }

        /// <summary>
        /// Update logitem
        /// </summary>
        /// <param name="message"></param>
        public void Update(string message)
        {
            logItemRepository.Insert(new LogItem() { Message = message, LogType = LogType.Update, CreatedAt = DateTime.Now });
        }
    }
}
