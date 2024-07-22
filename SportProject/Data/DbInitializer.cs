using System;
using System.Linq;
using ContosoUniversity.Models;
using SportProject.Models; // Update to your correct namespace

namespace SportProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportContext context)
        {
            // Check if there are any existing users
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Users
            var users = new User[]
            {
                new User { ID = 1, LastName = "Smith", FirstMidName = "John", EnrollmentDate = DateTime.Parse("2023-01-15") },
                new User { ID = 2, LastName = "Johnson", FirstMidName = "Emily", EnrollmentDate = DateTime.Parse("2023-02-20") },
                new User { ID = 3, LastName = "Williams", FirstMidName = "Michael", EnrollmentDate = DateTime.Parse("2023-03-10") },
                new User { ID = 4, LastName = "Jones", FirstMidName = "Sarah", EnrollmentDate = DateTime.Parse("2023-04-05") },
                new User { ID = 5, LastName = "Brown", FirstMidName = "David", EnrollmentDate = DateTime.Parse("2023-05-15") },
                new User { ID = 6, LastName = "Davis", FirstMidName = "Linda", EnrollmentDate = DateTime.Parse("2023-06-01") },
                new User { ID = 7, LastName = "Miller", FirstMidName = "James", EnrollmentDate = DateTime.Parse("2023-07-10") },
                new User { ID = 8, LastName = "Wilson", FirstMidName = "Karen", EnrollmentDate = DateTime.Parse("2023-08-15") },
                new User { ID = 9, LastName = "Moore", FirstMidName = "Robert", EnrollmentDate = DateTime.Parse("2023-09-20") },
                new User { ID = 10, LastName = "Taylor", FirstMidName = "Nancy", EnrollmentDate = DateTime.Parse("2023-10-25") }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            // Seed Sports
            var sports = new Sport[]
            {
                new Sport { SportID = 1, Name = "Football", Description = "A team sport played with a spherical ball." },
                new Sport { SportID = 2, Name = "Volleyball", Description = "A team sport where points are scored by hitting a ball over a net." },
                new Sport { SportID = 3, Name = "Basketball", Description = "A team sport where points are scored by shooting a ball through a hoop." }
            };

            context.Sports.AddRange(sports);
            context.SaveChanges();

            // Seed Fixtures
            var fixtures = new Fixture[]
            {
                new Fixture { FixtureID = 1, Title = "Football Match A", FixtureDate = DateTime.Parse("2024-05-10"), SportID = 1, UserID = 1, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 2, Title = "Volleyball Game B", FixtureDate = DateTime.Parse("2024-06-15"), SportID = 2, UserID = 2, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 3, Title = "Basketball Game C", FixtureDate = DateTime.Parse("2024-07-20"), SportID = 3, UserID = 3, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 4, Title = "Football Tournament", FixtureDate = DateTime.Parse("2024-08-25"), SportID = 1, UserID = 4, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 5, Title = "Volleyball Championship", FixtureDate = DateTime.Parse("2024-09-30"), SportID = 2, UserID = 5, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 6, Title = "Basketball League", FixtureDate = DateTime.Parse("2024-10-10"), SportID = 3, UserID = 6, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 7, Title = "Football Friendly", FixtureDate = DateTime.Parse("2024-11-15"), SportID = 1, UserID = 7, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 8, Title = "Volleyball Game C", FixtureDate = DateTime.Parse("2024-12-01"), SportID = 2, UserID = 8, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 9, Title = "Basketball Tournament", FixtureDate = DateTime.Parse("2024-12-15"), SportID = 3, UserID = 9, Result = FixtureResult.Pending },
                new Fixture { FixtureID = 10, Title = "Football Match B", FixtureDate = DateTime.Parse("2024-12-30"), SportID = 1, UserID = 10, Result = FixtureResult.Pending }
            };

            context.Fixtures.AddRange(fixtures);
            context.SaveChanges();
        }
    }
}
