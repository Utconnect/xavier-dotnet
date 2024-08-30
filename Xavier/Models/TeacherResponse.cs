using System;
using Utconnect.Common.Models;

namespace Utconnect.Teacher.Models
{
    public class TeacherResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public IdNameModel Department { get; set; } = null!;
        public IdNameModel Faculty { get; set; } = null!;
    }
}