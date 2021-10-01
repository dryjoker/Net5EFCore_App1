using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Net5EFCore_App1.Data
{
    public class CourseDataModel
    {
        public Guid Id { get; set; }
        public string Semester { get; set; }
        public string Title { get; set; }

        public Guid StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentDataModel Student { get; set; }
    }
}
