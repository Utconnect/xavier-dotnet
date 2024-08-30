using System;
using System.Threading.Tasks;
using Utconnect.Common.Models;
using Utconnect.Teacher.Models;

namespace Utconnect.Teacher.Services.Abstract
{
    /// <summary>
    /// Defines methods for getting teacher data from teacher service.
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Get teacher data by ID.
        /// </summary>
        /// <param name="id">The ID of teacher to get</param>
        /// <returns>A <see cref="Task"/> of <see cref="Result{T}"/> representing the asynchronous operation, with a <see cref="Result{T}"/> containing the teacher data.</returns>
        Task<Result<TeacherResponse>> GetById(Guid id);

        /// <summary>
        /// Get teacher data by UserID.
        /// </summary>
        /// <param name="userId">The UserID of teacher to get</param>
        /// <returns>A <see cref="Task"/> of <see cref="Result{T}"/> representing the asynchronous operation, with a <see cref="Result{T}"/> containing the teacher data.</returns>
        Task<Result<TeacherResponse>> GetByUserId(Guid userId);
    }
}