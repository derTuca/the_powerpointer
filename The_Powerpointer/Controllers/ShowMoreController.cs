using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using The_Powerpointer.Data;

namespace The_Powerpointer.Controllers
{
    public class ShowMoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShowMoreController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Songs()
        {

            return View(_context.Songs.ToList());
        }
    }
}