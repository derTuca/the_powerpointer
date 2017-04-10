using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace The_Powerpointer.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Picture()
        {
            return View();
        }

        public IActionResult Song()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }
    }
}