using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseProject.Models;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace UdemyCourseProject.Controllers
{
    [Route("api/[controller]")]
    public class ProfileApiController : Controller
    {
        private readonly ProfileContext _context;

        public ProfileApiController(ProfileContext context)
        {
            _context = context;
        }

        // Create methods
        #region
        [HttpPost]
        public async Task<IActionResult> CreateHobby(Hobby model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            catch (DbException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Unable to Save changes. Please contact System Administrator");
            }

            return RedirectToAction("Index", "LoggedIn", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndividual(Individual model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            catch (DbException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Unable to Save changes. Please contact System Administrator");
            }

            return RedirectToAction("Index", "LoggedIn", model);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization(Organization model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            catch (DbException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Unable to Save changes. Please contact System Administrator");
            }

            return RedirectToAction("Index", "LoggedIn", model);

        }
        #endregion

        // Edit methods
        #region
        [HttpPost]
        public async Task<IActionResult> EditHobby(Guid id, Hobby model)
        {
            if (id != model.HobbyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                } catch(DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.ToString(), "Unable to edit changes. Please contact the system administrator.");
                }
            }

            return RedirectToAction("Index", "LoggedIn", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrganization(Guid id, Organization model)
        {
            if (id != model.OrganizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.ToString(), "Unable to edit changes. Please contact the system administrator.");
                }
            }

            return RedirectToAction("Index", "LoggedIn", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditIndividual(Guid id, Individual model)
        {
            if (id != model.IndividualId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "LoggedIn");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.ToString(), "Unable to edit changes. Please contact the system administrator.");
                }
            }

            return RedirectToAction("Index", "LoggedIn", model);
        }
        #endregion

        // Delete methods
        #region
        [HttpPost]
        public async Task<IActionResult> DeleteHobby(Guid id)
        {
            var model = await _context.Hobby.SingleOrDefaultAsync(x => x.HobbyId == id);

            if(model == null)
            {
                return RedirectToAction("Index", "LoggedIn");
            }

            try
            {
                _context.Hobby.Remove(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "LoggedIn");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Error");

                return RedirectToAction("Index", "LoggedIn");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIndividual(Guid id)
        {
            var model =
                await _context.Individuals.SingleOrDefaultAsync(x => x.IndividualId == id);

            if (model == null)
            {
                return RedirectToAction("Index", "LoggedIn");
            }

            try
            {
                _context.Individuals.Remove(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "LoggedIn");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Error");

                return RedirectToAction("Index", "LoggedIn");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            var model =
                await _context.Organizations.SingleOrDefaultAsync(x => x.OrganizationId == id);

            if (model == null)
            {
                return RedirectToAction("Index", "LoggedIn");
            }

            try
            {
                _context.Organizations.Remove(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "LoggedIn");
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.ToString(), "Error");

                return RedirectToAction("Index", "LoggedIn");
            }
        }

        #endregion

        // Details methods
        #region
        [HttpGet]
        public async Task<IActionResult> DetailHobby(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var model = await _context.Hobby.SingleOrDefaultAsync(x => x.HobbyId == id);

            if(model == null)
            {
                return NotFound();
            }

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailIndividual(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Individuals.SingleOrDefaultAsync(x => x.IndividualId == id);

            if (model == null)
            {
                return NotFound();
            }

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailOrganization(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Organizations.SingleOrDefaultAsync(x => x.OrganizationId == id);

            if (model == null)
            {
                return NotFound();
            }

            return PartialView(model);
        }
        #endregion
    }
}
