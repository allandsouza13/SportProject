using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportProject.Models
{
    public class Sport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SportID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(80, MinimumLength = 3)]
        public string Description { get; set; }

        // Navigation Property for Coaches
        public ICollection<Coach> Coaches { get; set; } = new List<Coach>();

        // Collection of Fixtures
        public ICollection<Fixture> Fixtures { get; set; } = new List<Fixture>();
    }
}
