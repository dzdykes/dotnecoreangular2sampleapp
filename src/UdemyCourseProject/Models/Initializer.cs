using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyCourseProject.Models
{
    public static class Initializer
    {
        public static void InitializeContext(ProfileContext context)
        {
            context.Database.EnsureCreated();

            if (context.Individuals.Any())
            {
                return;
            }

            var individual = new Individual
            {
                FullName = "Dylan Dykes",
                DateOfBirth = DateTime.Now,
                Address = "3900 West Lynn Ave",
                AspNetUserId = "7dddff33-9fa3-4049-a923-cbeea7d4b882",
                State = "OR",
                City = "Portland",
                ZipCode = "91234"
            };

            context.Individuals.Add(individual);
            context.SaveChanges();

            var organization = new Organization
            {
                OrganizationId = Guid.NewGuid(),
                BusinessName = "IT Group",
                HireDate = DateTime.Now,
                Address = "201 Joiner Street",
                AspNetUserId = "7dddff33-9fa3-4049-a923-cbeea7d4b882",
                State = "WA",
                Profession = "Developer",
                City = "Redmond",
                ZipCode = "83449"
            };

            context.Organizations.Add(organization);
            context.SaveChanges();

            var hobby = new Hobby
            {
                HobbyId = Guid.NewGuid(),
                Name = "Exercise",
                Rating = 5,
                AspNetUserId = "7dddff33-9fa3-4049-a923-cbeea7d4b882"
            };

            context.Hobby.Add(hobby);
            context.SaveChanges();
        }
    }
}
