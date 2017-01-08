using System.Collections.Generic;
using UdemyCourseProject.Models;

namespace UdemyCourseProject.Repository
{
    public interface IProfileRepository
    {
        List<Hobby> GetHobbyList(string id);
        List<Organization> GetOrganizationList(string id);
        List<Individual> GetIndividualList(string id);
    }
}
