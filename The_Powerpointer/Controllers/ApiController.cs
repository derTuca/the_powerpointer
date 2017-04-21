using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using The_Powerpointer.Data;
using The_Powerpointer.Models;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Controllers
{
    //[Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly ApplicationDbContext _context;

        public ApiController(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }
       
       // [HttpGet("{id}", Name = "MarkFavorite")]
        public async Task<IActionResult> Favorite(int id)
        {
            var boolAdded = true;
            var detachedUser = await _manager.GetUserAsync(HttpContext.User);
            var user = _context.Users.SingleOrDefault(u => u.Id == detachedUser.Id);
            var userNews = _context.UserNews.Where(un => un.ApplicationUserId == detachedUser.Id).ToList();
            try
            {
                var f = userNews.SingleOrDefault(n => n.NewsId == id);
                if (f == null)
                {
                    var news = await _context.News.SingleOrDefaultAsync(n => n.Id == id);
                    var un = new UserNews
                    {
                        ApplicationUser = detachedUser,
                        News = news
                    };
                    user.News.Add(un);

                }
                else
                {
                    user.News.Remove(f);
                    boolAdded = false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            await _context.SaveChangesAsync();
           
           
            return new ObjectResult(boolAdded);
        }
    }

    
}