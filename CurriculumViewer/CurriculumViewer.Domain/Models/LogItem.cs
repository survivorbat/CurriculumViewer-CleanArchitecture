using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumViewer.Domain.Models
{
    /// <summary>
    /// Types of logmessages
    /// </summary>
    public enum LogType
    {
        Delete = 3,
        Update = 2,
        Create = 1
    }

    public class LogItem
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// LogType
        /// </summary>
        public LogType LogType { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
