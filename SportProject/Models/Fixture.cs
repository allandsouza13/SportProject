using ContosoUniversity.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportProject.Models
{
    public enum FixtureResult
    {
        Win,
        Loss,
        Draw,
        Pending
    }

    public class Fixture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FixtureID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public DateTime FixtureDate { get; set; }

        public int SportID { get; set; }
        public int UserID { get; set; }

        [DisplayFormat(NullDisplayText = "No result")]
        public FixtureResult? Result { get; set; }

        // Navigation properties
        public Sport Sport { get; set; }
        public User User { get; set; }
    }
}
