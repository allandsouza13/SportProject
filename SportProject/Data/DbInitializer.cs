using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportProject.Models; // Update to your correct namespace

namespace SportProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                // If users exist, then the database has been seeded already.
                return;
            }

            // Seed Users
            var users = new User[]
            {
                new User { LastName = "Smith", FirstMidName = "John", EnrollmentDate = DateTime.Parse("2023-01-15") },
                new User { LastName = "Johnson", FirstMidName = "Emily", EnrollmentDate = DateTime.Parse("2023-02-20") },
                new User { LastName = "Williams", FirstMidName = "Michael", EnrollmentDate = DateTime.Parse("2023-03-10") },
                new User { LastName = "Jones", FirstMidName = "Sarah", EnrollmentDate = DateTime.Parse("2023-04-05") },
                new User { LastName = "Brown", FirstMidName = "David", EnrollmentDate = DateTime.Parse("2023-05-15") },
                new User { LastName = "Davis", FirstMidName = "Linda", EnrollmentDate = DateTime.Parse("2023-06-01") },
                new User { LastName = "Miller", FirstMidName = "James", EnrollmentDate = DateTime.Parse("2023-07-10") },
                new User { LastName = "Wilson", FirstMidName = "Karen", EnrollmentDate = DateTime.Parse("2023-08-15") },
                new User { LastName = "Moore", FirstMidName = "Robert", EnrollmentDate = DateTime.Parse("2023-09-20") },
                new User { LastName = "Taylor", FirstMidName = "Nancy", EnrollmentDate = DateTime.Parse("2023-10-25") }
            };

            context.Users.AddRange(users);
            context.SaveChanges(); // Save users to the database

            // Seed Sports
            var sports = new Sport[]
            {
                new Sport { Name = "Football", Description = "A team sport played with a spherical ball." },
                new Sport { Name = "Volleyball", Description = "A team sport where points are scored by hitting a ball over a net." },
                new Sport { Name = "Basketball", Description = "A team sport where points are scored by shooting a ball through a hoop." }
            };

            context.Sports.AddRange(sports);
            context.SaveChanges(); // Save sports to the database

            // Seed Coaches
            var coaches = new Coach[]
            {
                new Coach { LastName = "Johnson", FirstMidName = "Emily", HireDate = DateTime.Parse("2022-01-10") },
                new Coach { LastName = "Williams", FirstMidName = "Michael", HireDate = DateTime.Parse("2021-03-15") },
                new Coach { LastName = "Davis", FirstMidName = "Linda", HireDate = DateTime.Parse("2020-07-01") }
            };

            context.Coaches.AddRange(coaches);
            context.SaveChanges(); // Save coaches to the database

            // Retrieve Sport IDs
            var footballId = context.Sports.Single(s => s.Name == "Football").SportID;
            var volleyballId = context.Sports.Single(s => s.Name == "Volleyball").SportID;
            var basketballId = context.Sports.Single(s => s.Name == "Basketball").SportID;

            // Retrieve Coaches
            var coachJohnson = context.Coaches.Include(c => c.Sports).Single(c => c.LastName == "Johnson");
            var coachWilliams = context.Coaches.Include(c => c.Sports).Single(c => c.LastName == "Williams");
            var coachDavis = context.Coaches.Include(c => c.Sports).Single(c => c.LastName == "Davis");

            // Add sports to coaches
            if (!coachJohnson.Sports.Any(s => s.SportID == footballId))
                coachJohnson.Sports.Add(context.Sports.Single(s => s.SportID == footballId));
            if (!coachJohnson.Sports.Any(s => s.SportID == volleyballId))
                coachJohnson.Sports.Add(context.Sports.Single(s => s.SportID == volleyballId));

            if (!coachWilliams.Sports.Any(s => s.SportID == basketballId))
                coachWilliams.Sports.Add(context.Sports.Single(s => s.SportID == basketballId));

            if (!coachDavis.Sports.Any(s => s.SportID == footballId))
                coachDavis.Sports.Add(context.Sports.Single(s => s.SportID == footballId));
            if (!coachDavis.Sports.Any(s => s.SportID == basketballId))
                coachDavis.Sports.Add(context.Sports.Single(s => s.SportID == basketballId));

            context.SaveChanges(); // Save changes to the database

            // Retrieve User IDs
            var smithId = context.Users.Single(u => u.LastName == "Smith").ID;
            var johnsonId = context.Users.Single(u => u.LastName == "Johnson").ID;
            var williamsId = context.Users.Single(u => u.LastName == "Williams").ID;
            var jonesId = context.Users.Single(u => u.LastName == "Jones").ID;
            var brownId = context.Users.Single(u => u.LastName == "Brown").ID;
            var davisId = context.Users.Single(u => u.LastName == "Davis").ID;
            var millerId = context.Users.Single(u => u.LastName == "Miller").ID;
            var wilsonId = context.Users.Single(u => u.LastName == "Wilson").ID;
            var mooreId = context.Users.Single(u => u.LastName == "Moore").ID;
            var taylorId = context.Users.Single(u => u.LastName == "Taylor").ID;

            // Seed Fixtures
            var fixtures = new Fixture[]
            {
                new Fixture { Title = "Football Match A", FixtureDate = DateTime.Parse("2024-05-10"), SportID = footballId, UserID = smithId, Result = FixtureResult.Pending },
                new Fixture { Title = "Volleyball Game B", FixtureDate = DateTime.Parse("2024-06-15"), SportID = volleyballId, UserID = johnsonId, Result = FixtureResult.Win },
                new Fixture { Title = "Basketball Game C", FixtureDate = DateTime.Parse("2024-07-20"), SportID = basketballId, UserID = williamsId, Result = FixtureResult.Draw },
                new Fixture { Title = "Football Tournament", FixtureDate = DateTime.Parse("2024-08-25"), SportID = footballId, UserID = jonesId, Result = FixtureResult.Draw },
                new Fixture { Title = "Volleyball Championship", FixtureDate = DateTime.Parse("2024-09-30"), SportID = volleyballId, UserID = brownId, Result = FixtureResult.Win },
                new Fixture { Title = "Basketball League", FixtureDate = DateTime.Parse("2024-10-10"), SportID = basketballId, UserID = davisId, Result = FixtureResult.Pending },
                new Fixture { Title = "Football Friendly", FixtureDate = DateTime.Parse("2024-11-15"), SportID = footballId, UserID = millerId, Result = FixtureResult.Win },
                new Fixture { Title = "Volleyball Game C", FixtureDate = DateTime.Parse("2024-12-01"), SportID = volleyballId, UserID = wilsonId, Result = FixtureResult.Pending },
                new Fixture { Title = "Basketball Tournament", FixtureDate = DateTime.Parse("2024-12-15"), SportID = basketballId, UserID = mooreId, Result = FixtureResult.Draw },
                new Fixture { Title = "Football Match B", FixtureDate = DateTime.Parse("2024-12-30"), SportID = footballId, UserID = taylorId, Result = FixtureResult.Win }
            };

            context.Fixtures.AddRange(fixtures);
            context.SaveChanges(); // Save fixtures to the database
        }
    }
}
