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
        public async Task<IActionResult> FavoriteNews(int id)
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
        public async Task<IActionResult> FavoriteSong(int id)
        {
            var boolAdded = true;
            var detachedUser = await _manager.GetUserAsync(HttpContext.User);
            var user = _context.Users.SingleOrDefault(u => u.Id == detachedUser.Id);
            var userSongs = _context.UserSongs.Where(us => us.ApplicationUserId == detachedUser.Id).ToList();
            try
            {
                var f = userSongs.SingleOrDefault(n => n.SongId == id);
                if (f == null)
                {
                    var song = await _context.Songs.SingleOrDefaultAsync(n => n.Id == id);
                    var us = new UserSong
                    {
                        ApplicationUser = detachedUser,
                        Song = song
                    };
                    _context.UserSongs.Add(us);

                }
                else
                {
                    user.Songs.Remove(f);
                    boolAdded = false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            await _context.SaveChangesAsync();
           
           
            return new ObjectResult(boolAdded);
        }public async Task<IActionResult> FavoritePicture(int id)
        {
            var boolAdded = true;
            var detachedUser = await _manager.GetUserAsync(HttpContext.User);
            var user = _context.Users.SingleOrDefault(u => u.Id == detachedUser.Id);
            var userPictures = _context.UserPictures.Where(up => up.ApplicationUserId == detachedUser.Id).ToList();
            try
            {
                var f = userPictures.SingleOrDefault(n => n.PictureId == id);
                if (f == null)
                {
                    var picture = await _context.Pictures.SingleOrDefaultAsync(n => n.Id == id);
                    var up = new UserPicture
                    {
                        ApplicationUser = detachedUser,
                        Picture = picture
                    };
                    _context.UserPictures.Add(up);

                }
                else
                {
                    user.Pictures.Remove(f);
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