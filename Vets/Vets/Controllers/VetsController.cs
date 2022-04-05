using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vets.Data;
using Vets.Models;

namespace Vets.Controllers
{
    public class VetsController : Controller
    {
        /// <summary>
        /// Attribute refers to the database of the project
        /// </summary>
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public VetsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; 
        }

        // GET: Vets
        public async Task<IActionResult> Index()
        {
            //Does the same thing as the DB command -> select * from Vets
            //And send the data to the view
            return View(await _context.Vet.ToListAsync());
        }

        // GET: Vets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _context.Vet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vet == null)
            {
                return NotFound();
            }

            return View(vet);
        }


        /// <summary>
        /// Opens the View "Create" to create a new Vet
        /// </summary>
        /// <returns></returns>
        
        // GET: Vets/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Vets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Uses data provide by browser when a new Vet is created
        /// </summary>
        /// <param name="vet"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProfessionalLicense,Photo")] Vet vet, IFormFile newPhotoVet)
        {
            ///process the image
            ///if file is null
            ///     -> add a predefined image to vet
            ///else
            ///     if file is not image
            ///         -> send error message to user, asking for image
            ///     else
            ///         -> define the name that the image must have
            ///         -> add the filename to vet data
            ///         -> save the file on the disk
            
            if(newPhotoVet == null)
            {
                vet.Photo = "noVet.png";
            }else if(!(newPhotoVet.ContentType== "image/jpeg" || newPhotoVet.ContentType == "image/pen"))
            {
                //error message
                ModelState.AddModelError("", "Por favor selecione uma fotografia.");
                //resend control to view with data provided by the user
                return View(vet);
            }
            else
            {
                //define image name
                Guid g;
                g = Guid.NewGuid();
                string imageName = vet.ProfessionalLicense + "_" + g.ToString();
                string extensionImage = Path.GetExtension(newPhotoVet.FileName).ToLower();
                imageName += extensionImage;
                //add image name to vet data
                vet.Photo = imageName;
            }

            //validate if data provided by user is good
            if (ModelState.IsValid)
            { 
                //add vet data to database
                _context.Add(vet);

                //commit (DB)
                await _context.SaveChangesAsync();

                //save image file to disk
                //ask the server what address it wants to use
                string addressToStoreFile = _webHostEnvironment.WebRootPath;
                string newImageLocation = Path.Combine(addressToStoreFile, "Photos", vet.Photo);

                //save image file to disk
                using var stream = new FileStream(newImageLocation, FileMode.Create);
                await newPhotoVet.CopyToAsync(stream);

                return RedirectToAction(nameof(Index));
            }
            return View(vet);
        }

        // GET: Vets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _context.Vet.FindAsync(id);
            if (vet == null)
            {
                return NotFound();
            }
            return View(vet);
        }

        // POST: Vets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProfessionalLicense,Photo")] Vet vet)
        {
            if (id != vet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VetExists(vet.Id))
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
            return View(vet);
        }

        // GET: Vets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _context.Vet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vet == null)
            {
                return NotFound();
            }

            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vet = await _context.Vet.FindAsync(id);
            _context.Vet.Remove(vet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VetExists(int id)
        {
            return _context.Vet.Any(e => e.Id == id);
        }
    }
}
