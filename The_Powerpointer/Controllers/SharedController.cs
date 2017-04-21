using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using The_Powerpointer.Data;

namespace The_Powerpointer.Controllers
{
    public class SharedController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public SharedController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GetSong(int id)
        {
            if (Request.Headers["x-requested-with"] == "XMLHttpRequest")
            {
                var song = _context.Songs.SingleOrDefault(s => s.Id == id);
                if (song == null) return NotFound();
                return PartialView("_SongPlayer", song);
            }
            return BadRequest();
        }
    }
}