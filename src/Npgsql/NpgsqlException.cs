﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.BackendMessages;
#if NET45 || NET451
using System.Runtime.Serialization;
#endif

namespace Npgsql
{
    /// <summary>
    /// The exception that is thrown when server-related issues occur.
    /// </summary>
    /// <remarks>
    /// PostgreSQL errors (e.g. query SQL issues, constraint violations) are raised via
    /// <see cref="PostgresException"/> which is a subclass of this class.
    /// Purely Npgsql-related issues which aren't related to the server will be raised
    /// via the standard CLR exceptions (e.g. ArgumentException).
    /// </remarks>
#if NET45 || NET451
    [Serializable]
#endif
    public class NpgsqlException : DbException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlException"/> class.
        /// </summary>
        protected internal NpgsqlException() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (<string>Nothing</string> in Visual Basic) if no inner exception is specified.</param>
        protected internal NpgsqlException(string message, Exception innerException) 
            : base(message, innerException) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected internal NpgsqlException(string message)
            : base(message) { }

        /// <summary>
        /// Same as <see cref="PostgresException.MessageText"/>, for backwards-compatibility with Npgsql 2.x and Hangfire.
        /// </summary>
        /// <remarks>
        /// Until Hangfire fix themselves: https://github.com/frankhommers/Hangfire.PostgreSql/issues/33
        /// </remarks>
        [Obsolete("Use PostgresException.MessageText instead")]
        public string BaseMessage => ((PostgresException)this).MessageText;

        #region Serialization
#if NET45 || NET451
        /// <summary>
        /// Initializes a new instance of the <see cref="NpgsqlException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected internal NpgsqlException(SerializationInfo info, StreamingContext context) : base(info, context) {}
#endif
        #endregion
    }
}
