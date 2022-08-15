using Tiffin.Data;
using Tiffin.Data.Services;
using Tiffin.Data.Static;
using Tiffin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiffin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CooksController : Controller
    {
        private readonly ICooksService _service;

        public CooksController(ICooksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCooks = await _service.GetAllAsync();
            return View(allCooks);
        }


        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cook cook)
        {
            if (!ModelState.IsValid) return View(cook);
            await _service.AddAsync(cook);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cookDetails = await _service.GetByIdAsync(id);
            if (cookDetails == null) return View("NotFound");
            return View(cookDetails);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var cookDetails = await _service.GetByIdAsync(id);
            if (cookDetails == null) return View("NotFound");
            return View(cookDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cook cook)
        {
            if (!ModelState.IsValid) return View(cook);
            await _service.UpdateAsync(id, cook);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var cookDetails = await _service.GetByIdAsync(id);
            if (cookDetails == null) return View("NotFound");
            return View(cookDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cookDetails = await _service.GetByIdAsync(id);
            if (cookDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
