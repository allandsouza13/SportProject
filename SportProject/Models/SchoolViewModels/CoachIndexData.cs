using System.Collections.Generic;

namespace SportProject.Models.SportViewModels
{
    public class CoachIndexData
    {
        public IEnumerable<Coach> Coaches { get; set; }
        public IEnumerable<Sport> Sports { get; set; }
        public IEnumerable<Fixture> Fixtures { get; set; }
    }
}
