using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5EFCore_App1.Data
{
    public class StudentDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }

        public ICollection<CourseDataModel> Courses { get; set; }
    }
}
