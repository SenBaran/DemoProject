#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QTMusic.Logic.DataContext;
using QTMusic.Logic.Entities.App;

namespace QTMusic.AspMvc.Controllers
{
    public class AlbumsController : Controller
    {
        Logic.Controllers.App.AlbumsController albumsCtrl = new Logic.Controllers.App.AlbumsController();
        Logic.Controllers.App.ArtistsController artistsCtrl = new Logic.Controllers.App.ArtistsController();
        Logic.Controllers.App.GenresController genresCtrl = new Logic.Controllers.App.GenresController();

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            //var projectDbContext = _context.AlbumsSet.Include(a => a.Artist).Include(a => a.Genre);
            return View(await albumsCtrl.GetAllAsync().ConfigureAwait(false));
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var album = await _context.AlbumsSet
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var album = await albumsCtrl.GetByIdAsync(id).ConfigureAwait(false);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ArtistsList = await artistsCtrl.GetAllAsync().ConfigureAwait(false);
            ViewBag.GenresList = await genresCtrl.GetAllAsync().ConfigureAwait(false);
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,GenreId,Title,RowVersion,Id")] Album album)
        {
            if (ModelState.IsValid)
            {
                await albumsCtrl.InsertAsync(album).ConfigureAwait(false);
                await albumsCtrl.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ArtistId"] = new SelectList(_context.ArtistsSet, "Id", "Name", album.ArtistId);
            //ViewData["GenreId"] = new SelectList(_context.GenresSet, "Id", "Name", album.GenreId);
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await albumsCtrl.GetByIdAsync(id).ConfigureAwait(false);
            if (album == null)
            {
                return NotFound();
            }
            //ViewData["ArtistId"] = new SelectList(_context.ArtistsSet, "Id", "Name", album.ArtistId);
            //ViewData["GenreId"] = new SelectList(_context.GenresSet, "Id", "Name", album.GenreId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,GenreId,Title,RowVersion,Id")] Album album)
        {
            var editAlbum = await albumsCtrl.GetByIdAsync(id).ConfigureAwait(false);
            editAlbum.Title = album.Title;
            if (id != editAlbum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await albumsCtrl.UpdateAsync(editAlbum).ConfigureAwait(false);
                    await albumsCtrl.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await AlbumExistsAsync(editAlbum.Id))
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
            //ViewData["ArtistId"] = new SelectList(_context.ArtistsSet, "Id", "Name", album.ArtistId);
            //ViewData["GenreId"] = new SelectList(_context.GenresSet, "Id", "Name", album.GenreId);
            return View(editAlbum);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var album = await _context.AlbumsSet
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);*/
            var album = await albumsCtrl.GetByIdAsync(id).ConfigureAwait(false);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await albumsCtrl.GetByIdAsync(id).ConfigureAwait(false);
            await albumsCtrl.DeleteAsync(id).ConfigureAwait(false);
            await albumsCtrl.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AlbumExistsAsync(int id)
        {
            var album = await albumsCtrl.GetByIdAsync(id).ConfigureAwait(false);
            if(album == null)
            {
                return false;
            }

            return true;
        }
    }
}
