using Contoso_University.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Contoso_University.Models.SchoolViewModels
{
    public class AddStudentViewModel
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

