using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRealKente.Data;
using TheRealKente.Models;


namespace TheRealKente.Controllers
{
    public class KentesController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;


        // GET: Kentes
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kentes.ToListAsync());
        }

        // GET: Kentes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kente = await _context.Kentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kente == null)
            {
                return NotFound();
            }


            return View(kente);
        }

        // GET: Kentes/Create
        [Authorize]
        public IActionResult Create()

        {
            return View();
        }

        // POST: Kentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("KenteID,Description,StockQuantity,KentePrice,ProductImageURL")] Kente kente)
        {
            if (id == null)
            {
                var Productfound = await _context.Kentes.FirstOrDefaultAsync(k => k.KenteID == kente.KenteID);
                if (Productfound != null)
                {
                    TempData["Alert"] = Productfound.KenteID + " already exists, stock has not been updated";
                    return RedirectToAction("Index");
                }

                await _context.Kentes.AddAsync(kente);
                TempData["Alert"] = kente.KenteID  + " has been added to the stock, stock successfully updated";



            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Kentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kente = await _context.Kentes.FindAsync(id);
            if (kente == null)
            {
                return NotFound();
            }
            return View(kente);
        }

        // POST: Kentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName ("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            //if (id != kente.Id)
            //{
            //return NotFound();
            //}
            if (id == null)
            {
                return NotFound();

            }

            var products = await _context.Kentes.FirstOrDefaultAsync(k => k.Id == id);
            if (await TryUpdateModelAsync<Kente>(
                products,
                "",
                k => k.KenteID, k => k.Description,  k => k.StockQuantity, k=> k.KentePrice, k => k.ProductImageURL))
            {
                try
                {
                    TempData["Alert"] = products.KenteID + " has been successfully updated";
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Changes made have not been saved. " + 
                        "Try again, and if the problem persists, " +
                        " see your system administrator.");

                }
                           
            }
            return View(products);
            //products.KenteID = kente.KenteID;
            //
            //_context.Update(kente);






        }






        //if (ModelState.IsValid)
        //{
        //try
        //{

        //_context.Update(kente);//



        //}
        //catch (DbUpdateConcurrencyException)
        //{
        //if (!KenteExists(kente.Id))
        //{
        //return NotFound();



        // GET: Kentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kente = await _context.Kentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kente == null)
            {
                return NotFound();
            }

            return View(kente);
        }

        // POST: Kentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kente = await _context.Kentes.FindAsync(id);
            if (kente != null)
            {
                _context.Kentes.Remove(kente);
            }
            TempData["Alert"] = kente.KenteID + " has been deleted sucessfully";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool KenteExists(int id)
        //{
        //return _context.Kentes.Any(e => e.Id == id);
        //}
    }
}
