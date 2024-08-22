using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesApp.Data;
using JokesApp.Models;
using JokesApp.Sevice;

namespace JokesApp.Controllers
{
    public class WeatherForcastController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public WeatherForcastController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeatherForcastModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherForcastModels.ToListAsync());
        }

        // GET: WeatherForcastModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherForcastModel = await _context.WeatherForcastModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (weatherForcastModel == null)
            {
                return NotFound();
            }

            return View(weatherForcastModel);
        }

        // GET: WeatherForcastModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherForcastModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tempValue,country,cityName")] WeatherForcastModel weatherForcastModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherForcastModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherForcastModel);
        }

        // GET: WeatherForcastModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherForcastModel = await _context.WeatherForcastModels.FindAsync(id);
            if (weatherForcastModel == null)
            {
                return NotFound();
            }
            return View(weatherForcastModel);
        }

        // POST: WeatherForcastModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tempValue,country,cityName")] WeatherForcastModel weatherForcastModel)
        {
            if (id != weatherForcastModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherForcastModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherForcastModelExists(weatherForcastModel.id))
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
            return View(weatherForcastModel);
        }

        // GET: WeatherForcastModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherForcastModel = await _context.WeatherForcastModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (weatherForcastModel == null)
            {
                return NotFound();
            }

            return View(weatherForcastModel);
        }

        // POST: WeatherForcastModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherForcastModel = await _context.WeatherForcastModels.FindAsync(id);
            if (weatherForcastModel != null)
            {
                _context.WeatherForcastModels.Remove(weatherForcastModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherForcastModelExists(int id)
        {
            return _context.WeatherForcastModels.Any(e => e.id == id);
        }
    }
}
