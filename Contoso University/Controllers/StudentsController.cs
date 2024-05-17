using Contoso_University.Data;
using Contoso_University.Models.Entities;
using Contoso_University.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Contoso_University.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext context;

        public StudentsController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                LastName = viewModel.LastName,
                FirstMidName = viewModel.FirstMidName,
                EnrollmentDate = viewModel.EnrollmentDate,
            };

            await context.AddAsync(student);

            await context.SaveChangesAsync();

            return RedirectToAction("List", "Students");
        }


        [HttpGet]
        public async Task<IActionResult> List(string sortOrder, string currentFilter,
                                                string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;


            var students = from student in context.Students
                            select student;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString) 
                                            || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            return View(student);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(Student viewModal )
		{   
            var studentToUpdate = await context.Students.FirstOrDefaultAsync(s => s.ID == viewModal.ID);
            
            if (studentToUpdate is not null)
            {
                studentToUpdate.FirstMidName = viewModal.FirstMidName;
                studentToUpdate.LastName =  viewModal.LastName;
                studentToUpdate.EnrollmentDate = viewModal.EnrollmentDate;

                await context.SaveChangesAsync();
            }

            return RedirectToAction("List");
		}


		[HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var student = await context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            return View(student);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var studentToDelete = await context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == id);

            return View(studentToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModal)
        {
            var studentToDelete = await context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ID == viewModal.ID);

            if(studentToDelete is not null)
            {
                context.Students.Remove(viewModal);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        
    }
}
