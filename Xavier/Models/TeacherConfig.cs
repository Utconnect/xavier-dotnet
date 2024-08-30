using Utconnect.Common.Configurations.Models;

namespace Utconnect.Teacher.Models
{
    public class TeacherConfig : ISiteConfig
    {
        public string Url { get; set; } = default!;
    }
}