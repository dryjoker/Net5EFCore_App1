using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5EFCore_App1.Data
{
    public class MyTestDbContext : DbContext
    {
        public MyTestDbContext(DbContextOptions<MyTestDbContext> options) : base(options)
        {

        }

        public DbSet<StudentDataModel> Students { get; set; }
        public DbSet<CourseDataModel> Courses { get; set; }
    }
}
