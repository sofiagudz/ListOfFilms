using ListOfFilms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListOfFilms.Controllers
{
    public class FilmController:Controller
    {
        FilmContext db;
        IWebHostEnvironment _appEnvironment;
        public FilmController(FilmContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return db.Films != null ?
                View(await db.Films.ToListAsync()) :
                Problem("Entity set 'FilmContext.Films' is null");
        }

        //GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || db.Films == null)
            {
                return NotFound();
            }
            var film = await db.Films.FirstOrDefaultAsync(x => x.Id == id);
            if(film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        //GET: Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Director,Genre,Year,Poster,Description")] Film film, IFormFile uploadedFile)
        {
            if(ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    // Путь к папке img
                    string path = "/img/" + uploadedFile.FileName; // имя файла

                    // Сохраняем файл в папку img в каталоге wwwroot
                    // Для получения полного пути к каталогу wwwroot
                    // применяется свойство WebRootPath объекта IWebHostEnvironment
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                    }
                    film.Poster = path;
                }
                db.Add(film);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        //GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.Films == null)
            {
                return NotFound();
            }
            var film = await db.Films.FindAsync(id);
            if(film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Director,Genre,Year,Poster,Description")] Film film, IFormFile uploadedFile)
        {
            if(id != film.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {

                    if (uploadedFile != null)
                    {
                        // Путь к папке Files
                        string path = "/img/" + uploadedFile.FileName; // имя файла

                        // Сохраняем файл в папку Files в каталоге wwwroot
                        // Для получения полного пути к каталогу wwwroot
                        // применяется свойство WebRootPath объекта IWebHostEnvironment
                        using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(fileStream); // копируем файл в поток
                        }
                        film.Poster = path;

                    }
                    db.Update(film);
                    await db.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException){
                    if (!FilmExists(film.Id))
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
            return View(film);
        }

        //GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || db.Films == null)
            {
                return NotFound();
            }
            var film = await db.Films.FirstOrDefaultAsync(m => m.Id == id);
            if(film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(db.Films == null)
            {
                return Problem("Entity set 'FilmContext.Films' is null");
            }
            var film = await db.Films.FindAsync(id);
            if(film != null)
            {
                db.Films.Remove(film);
            }
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return (db.Films?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
