using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net5EFCore_App1.Models
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        
        [Display(Name="姓名")]
        [Required(ErrorMessage ="{0}不可為空")]
        public string Name { get; set; }

        [Display(Name="年齡")]
        [Required(ErrorMessage ="{0}不可為空")]
        [Range(18,60,ErrorMessage ="{0}的範圍介於{1}~{2}")]
        public int Age { get; set; }

        [Display(Name="性別")]
        [Required(ErrorMessage ="{0}不可為空")]
        public bool Sex { get; set; }

        [Display(Name = "性別")]
        public string StrSex { get; set; }
    }
}
