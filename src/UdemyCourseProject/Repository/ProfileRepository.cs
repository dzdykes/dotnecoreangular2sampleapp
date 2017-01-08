using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCourseProject.Models;

namespace UdemyCourseProject.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileContext _context;

        public ProfileRepository(ProfileContext context)
        {
            _context = context;
        }

        public List<Hobby> GetHobbyList(string id)
        {
            var hobbies = _context.Hobby.Where(x => x.AspNetUserId == id).ToList();
            return hobbies;
        }

        public List<Individual> GetIndividualList(string id)
        {

            var individuals = _context.Individuals.Where(x => x.AspNetUserId == id).ToList();
            return individuals;
        }

        public List<Organization> GetOrganizationList(string id)
        {
            var organizations = _context.Organizations.Where(x => x.AspNetUserId == id).ToList();
            return organizations;
        }
    }
}
