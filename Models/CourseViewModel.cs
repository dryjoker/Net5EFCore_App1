using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net5EFCore_App1.Models
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        [Display(Name="學期")]
        [Required(ErrorMessage ="{0}不可為空")]
        public string Semester { get; set; }

        [Display(Name = "課程名稱")]
        [Required(ErrorMessage = "{0}不可為空")]
        public string Title { get; set; }

        public Guid StudentId { get; set; }
    }
}
