using System;
using System.ComponentModel.DataAnnotations;

namespace SportProject.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int UserCount { get; set; }
    }
}

