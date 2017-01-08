using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UdemyCourseProject.Models;
using UdemyCourseProject.ViewModels;
using UdemyCourseProject.Repository;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UdemyCourseProject.Controllers
{
    public class LoggedInController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfileRepository _profileRepository;
        // GET: /<controller>/
        public LoggedInController(UserManager<ApplicationUser> userManager, IProfileRepository profileRepository)
        {
            _userManager = userManager;
            _profileRepository = profileRepository;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var hobbies = _profileRepository.GetHobbyList(userId);

            var individual = _profileRepository.GetIndividualList(userId);

            var organization = _profileRepository.GetOrganizationList(userId);

            var model = new DashboardViewModel()
            {
                Individuals = individual,
                Organizations = organization,
                Hobbies = hobbies
            };

            return View(model);
        }
    }
}
