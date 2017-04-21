using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using The_Powerpointer.Data;
using The_Powerpointer.Models.ItemViewModels;

namespace The_Powerpointer.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Picture(int id)
        {
            var picture = _context.Pictures.SingleOrDefault(p => p.Id == id);
            if (picture == null) return NotFound();
            var model = new PictureViewModel
            {
                Picture = picture,
                SuggestedPictures = _context.Pictures.ToList()
            };
            return View(model);
        }

        public IActionResult Song(int id)
        {
            
            var song = _context.Songs.SingleOrDefault(s => s.Id == id);
            if (song == null) return NotFound();
            var model = new SongViewModel
            {
                Song = song,
                SuggestedSongs = _context.Songs.ToList()
            };
            return View(model);
        }

       
    }
}