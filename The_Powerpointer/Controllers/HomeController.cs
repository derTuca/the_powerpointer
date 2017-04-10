using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using The_Powerpointer.Data;
using The_Powerpointer.Models;

namespace The_Powerpointer.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        private DateTime _lastUpdated;
        private List<Picture> _selectedPictures;
        private Song _selectedSong;
        private List<News> _selectedNews;

        public HomeController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
            PopulateDatabase();
        }
        public async Task<IActionResult> Index()
        {
           
            MainPageViewModel viewModel = new MainPageViewModel();
            if (_lastUpdated != DateTime.Today)
            {
                var r = new Random();
                _lastUpdated = DateTime.Today;
                var p = _context.Pictures.ToArray();
                var s = _context.Songs.ToArray();
                _selectedPictures = new List<Picture>
                {
                    p[r.Next(p.Length - 1)],
                    p[r.Next(p.Length - 1)]
                };
                _selectedSong = s[r.Next(s.Length - 1)];
                _selectedNews = await GetNews();
            }
           
            viewModel.Song = _selectedSong;
            viewModel.News = _selectedNews;
            viewModel.Pictures = _selectedPictures;
            return View(viewModel);
        }

        private async Task<List<News>> GetNews()
        {
            Program.Client.BaseAddress = new Uri(@"https://newsapi.org/v1/articles?source=bbc-news&sortBy=top&apiKey=8596c1fa77264dae8f8b6dd607356671");
            Program.Client.DefaultRequestHeaders.Accept.Clear();
            Program.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Program.Client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                return obj.GetValue("articles").ToObject<List<News>>();
            }
            return null;
        }

        private void PopulateDatabase()
        {
            if (_context.Pictures.ToList().Count == 0)
            {
                var path = _env.ContentRootPath + @"\Media\Pictures\";
                foreach (var file in Directory.GetFiles(path))
                {
                    string[] a = file.Split('\\');
                    string[] parts = a[a.Length - 1].Split('_');
                    Picture pic = new Picture
                    {
                        Name = parts[0],
                        Author = parts[2].Split('.')[0],
                        Source = path,
                        DateCreated = new DateTime(int.Parse(parts[1]), 1, 1)
                    };
                    _context.Pictures.Add(pic);
                }
                _context.SaveChanges();
            }
            if (_context.Songs.ToList().Count == 0)
            {
                var path = _env.ContentRootPath + @"\Media\Songs\";
                foreach (var file in Directory.GetFiles(path))
                {
                    string[] a = file.Split('\\');
                    string[] parts = a[a.Length - 1].Split('_');
                    Song s = new Song
                    {
                        Name = parts[2].Split('.')[0],
                        Author = parts[0],
                        Source = path,
                        DateCreated = new DateTime(int.Parse(parts[1]), 1, 1)
                    };
                    _context.Songs.Add(s);
                }
                _context.SaveChanges();
            }
        }

      

        public IActionResult Error()
        {
            return View();
        }
    }
}
