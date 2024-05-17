using Contoso_University.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contoso_University.Data
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options) { }

        // table names
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3, DepartmentID = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, DepartmentID = 4 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, DepartmentID = 4 },
                new Course { CourseID = 1045, Title = "Calculus", Credits = 4, DepartmentID = 2 },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4, DepartmentID = 2 },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3, DepartmentID = 1 },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4, DepartmentID = 1 }
            );


            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { ID = 2, FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { ID = 3, FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { ID = 4, FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { ID = 5, FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { ID = 6, FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { ID = 7, FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { ID = 8, FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
            );

            // Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 1050, Grade = Grade.A },
                new Enrollment { EnrollmentID = 2, StudentID = 1, CourseID = 4022, Grade = Grade.C },
                new Enrollment { EnrollmentID = 3, StudentID = 1, CourseID = 4041, Grade = Grade.B },
                new Enrollment { EnrollmentID = 4, StudentID = 2, CourseID = 1045, Grade = Grade.B },
                new Enrollment { EnrollmentID = 5, StudentID = 2, CourseID = 3141, Grade = Grade.B },
                new Enrollment { EnrollmentID = 6, StudentID = 2, CourseID = 2021, Grade = Grade.B },
                new Enrollment { EnrollmentID = 7, StudentID = 3, CourseID = 1050 },
                new Enrollment { EnrollmentID = 8, StudentID = 3, CourseID = 4022, Grade = Grade.B },
                new Enrollment { EnrollmentID = 9, StudentID = 4, CourseID = 1050, Grade = Grade.B },
                new Enrollment { EnrollmentID = 10, StudentID = 5, CourseID = 2021, Grade = Grade.B },
                new Enrollment { EnrollmentID = 11, StudentID = 6, CourseID = 2042, Grade = Grade.B }
            );

            // Seed Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { ID = 1, FirstMidName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { ID = 2, FirstMidName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { ID = 3, FirstMidName = "Roger", LastName = "Harui", HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { ID = 4, FirstMidName = "Candace", LastName = "Kapoor", HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { ID = 5, FirstMidName = "Roger", LastName = "Zheng", HireDate = DateTime.Parse("2004-02-12") }
            );

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, Name = "English", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorID = 1 },
                new Department { DepartmentID = 2, Name = "Mathematics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorID = 2 },
                new Department { DepartmentID = 3, Name = "Engineering", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorID = 3 },
                new Department { DepartmentID = 4, Name = "Economics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorID = 4 }
            );


            // Seed OfficeAssignments
            modelBuilder.Entity<OfficeAssignment>().HasData(
                new OfficeAssignment { InstructorID = 2, Location = "Smith 17" },
                new OfficeAssignment { InstructorID = 3, Location = "Gowan 27" },
                new OfficeAssignment { InstructorID = 4, Location = "Thompson 304" }
            );

            // Seed CourseAssignments
            modelBuilder.Entity<CourseAssignment>().HasData(
                new CourseAssignment { CourseID = 1050, InstructorID = 4 },
                new CourseAssignment { CourseID = 1050, InstructorID = 3 },
                new CourseAssignment { CourseID = 4022, InstructorID = 5 },
                new CourseAssignment { CourseID = 4041, InstructorID = 5 },
                new CourseAssignment { CourseID = 1045, InstructorID = 2 },
                new CourseAssignment { CourseID = 3141, InstructorID = 3 },
                new CourseAssignment { CourseID = 2021, InstructorID = 1 },
                new CourseAssignment { CourseID = 2042, InstructorID = 1 }
            );


   
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }
	}
}
