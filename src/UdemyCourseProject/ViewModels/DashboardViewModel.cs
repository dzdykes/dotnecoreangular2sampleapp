using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyCourseProject.Models;

namespace UdemyCourseProject.ViewModels
{
    public class DashboardViewModel
    {
        public List<Individual> Individuals { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
