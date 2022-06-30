using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Hotel.Data;
using Pet_Hotel.Models;

namespace Pet_Hotel.Controllers
{
    public class PetsController : Controller
    {
        private readonly Pet_HotelContext _context;

        public PetsController(Pet_HotelContext context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(string petType, string searchName,
                                               string searchBreed,string searchPetOwner)
        {
            var pets = from p in _context.Pet
                       select p;

            // LINQ query that retrieves all the pet types from the database.
            IQueryable<string> petTypeQuery = from p in _context.Pet
                                            orderby p.Type
                                            select p.Type;

            // name
            if (!string.IsNullOrEmpty(searchName))
            {
                pets = pets.Where(x => x.Name!.Contains(searchName));
            }

            // breed
            if (!string.IsNullOrEmpty(searchBreed))
            {
                pets = pets.Where(x => x.Breed!.Contains(searchBreed));
            }

            // pet owner
            if (!String.IsNullOrEmpty(searchPetOwner))
            {
                pets = pets.Where(x => x.PetOwner!.Contains(searchPetOwner));
            }

            // pet type
            if (!String.IsNullOrEmpty(petType))
            {
                pets = pets.Where(x => x.Type == petType);
            }

            var petTypeVM = new PetTypeViewModel
            {
                Types = new SelectList(await petTypeQuery.Distinct().ToListAsync()),
                Pets = await pets.ToListAsync()
            };

            
            return View(petTypeVM);
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pet == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Breed,Age,PetOwner,checkedIn,checkedOut")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pet == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Breed,Age,PetOwner,checkedIn,checkedOut")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
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
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pet == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pet == null)
            {
                return Problem("Entity set 'Pet_HotelContext.Pet'  is null.");
            }
            var pet = await _context.Pet.FindAsync(id);
            if (pet != null)
            {
                _context.Pet.Remove(pet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
          return (_context.Pet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
