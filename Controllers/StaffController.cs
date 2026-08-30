using Microsoft.AspNetCore.Mvc;
using StaffManagementApp.Filters;
using StaffManagementApp.Models;
using StaffManagementApp.Services;

namespace StaffManagementApp.Controllers
{
    [RequireAdmin]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        //GET: /Staff
        public IActionResult Index()
        {
            var staff = _staffService.GetAll();
            return View(staff);
        }

        //GET: /Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffMember staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            _staffService.Add(staff);
            return RedirectToAction(nameof(Index));
        }

        //GET: /Staff/Edit/5
        public IActionResult Edit(int id)
        {
            var staff = _staffService.GetById(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        //POST: /Staff/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StaffMember staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            var updated = _staffService.Update(id, staff);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        //GET: /Staff/Delete/5
        public IActionResult Delete(int id)
        {
            var staff = _staffService.GetById(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        //POST: /Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _staffService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
