using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net5EFCore_App1.Data;
using Net5EFCore_App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5EFCore_App1.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyTestDbContext _dbContext;
        /// <summary>
        /// 透過建構子注入DbContext
        /// </summary>
        /// <param name="dbContext"></param>
        public StudentController(MyTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 增加學生資訊的頁面-顯示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 增加學生資訊的頁面-提交
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(StudentDataModel model)
        {
            if (ModelState.IsValid)
            {
                StudentDataModel studentData = new StudentDataModel();
                studentData.Id = Guid.NewGuid();
                studentData.Name = model.Name;
                studentData.Age = model.Age;
                studentData.Sex = model.Sex;

                _dbContext.Add(studentData);
                _dbContext.SaveChanges();
                return RedirectToAction("Show");
            }
            return View(model);
        }

        /// <summary>
        /// 顯示查詢出來的學生資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Show()
        {
            var students = await _dbContext.Students.ToListAsync();
            var vm_Student = new List<StudentViewModel>();
            foreach (var stu in students)
            {
                vm_Student.Add(new StudentViewModel() { Id = stu.Id, Name = stu.Name, Age = stu.Age, Sex = stu.Sex, StrSex = stu.Sex ? "男" : "女" });
            }
            return View(vm_Student);
        }

        /// <summary>
        /// 查詢特定單筆資料回填至編輯表單-顯示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new StatusCodeResult(400);
            }
            var student = await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(stu => stu.Id == new Guid(id));
            StudentViewModel vm_Student = new StudentViewModel();
            vm_Student.Id = student.Id;
            vm_Student.Name = student.Name;
            vm_Student.Age = student.Age;
            vm_Student.Sex = student.Sex;
            return View(vm_Student);
        }

        /// <summary>
        /// 編輯更新學生資料-提交
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                StudentDataModel studentData = new StudentDataModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Age = model.Age,
                    Sex = model.Sex
                };

                _dbContext.Update(studentData);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Show));
            }
            return View(model);
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new StatusCodeResult(400);
            }

            var student = _dbContext.Students.Find(new Guid(id));
            _dbContext.Remove(student);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Show));
        }
    }
}
