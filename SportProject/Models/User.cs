using SportProject.Models;
namespace ContosoUniversity.Models
{
    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Fixture> Fixtures { get; set; }
    }
}