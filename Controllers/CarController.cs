using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealershipApp.Data;
using CarDealershipApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarDealershipApp.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Car
        public async Task<IActionResult> Index(int currentPageIndex, string selectedMake)
        {
            var makes = await _context.CarModel.Select(c => c.Make).Distinct().ToListAsync();
            ViewBag.Makes = new SelectList(makes);

            return _context.CarModel != null ?
                View(PaginatedCars(currentPageIndex, selectedMake)) :
                Problem("Entity set 'ApplicationDbContext.CarModel'  is null.");
        }


        private CarModel PaginatedCars(int currentPage, string selectedMake)
        {
            int maxRows = 10;
            var carsQuery = _context.CarModel.AsQueryable();

            if (!string.IsNullOrEmpty(selectedMake))
            {
                carsQuery = carsQuery.Where(c => c.Make == selectedMake);
            }

            var cars = carsQuery.ToList();

            CarModel cModel = new CarModel();

            cModel.CarList = cars.OrderBy(customer => customer.Id)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows).ToList();

            double pageCount = (double)((decimal)cars.Count() / Convert.ToDecimal(maxRows));
            cModel.PageCount = (int)Math.Ceiling(pageCount);

            cModel.CurrentPageIndex = currentPage;

            return cModel;
        }


        // GET: Car/ShowSearchForm
        //[Authorize]
        //public Task<IActionResult> ShowSearchForm()
        //{
        //    return Task.FromResult<IActionResult>(View());

        //}

        // GET: Car/ShowSearchResults
        //[Authorize]
        //public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        //{
        //    var carModels = await _context.CarModel
        //                                 .Where(j => j.Make.Contains(SearchPhrase))
        //                                 .ToListAsync();

        //    var viewModel = new CarModel 
        //    {
        //        CarList = carModels
        //    };

        //    return View("Index", viewModel);
        //}



        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarModel == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // GET: Car/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,CarModelYear,Price")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }

        // GET: Car/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarModel == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }
            return View(carModel);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,CarModelYear,Price")] CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelExists(carModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }

        // GET: Car/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarModel == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // POST: Car/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarModel'  is null.");
            }
            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel != null)
            {
                _context.CarModel.Remove(carModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelExists(int id)
        {
          return (_context.CarModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
