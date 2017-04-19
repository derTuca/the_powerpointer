using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<ApplicationUser> _manager;
        private static DateTime _lastUpdated;
        private static List<Picture> _selectedPictures;
        private static Song _selectedSong;
        private static List<News> _selectedNews;
        private static bool _doneNews = false;

        public HomeController(ApplicationDbContext context, IHostingEnvironment env, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _env = env;
            _manager = manager;
            
        }
        public async Task<IActionResult> Index()
        {

            MainPageViewModel viewModel = new MainPageViewModel();
            if (_lastUpdated != DateTime.Today)
            {
                await PopulateDatabase();
                var r = new Random();
                _lastUpdated = DateTime.Today;
                var s = _context.Songs.ToArray();
                _selectedPictures = SelectPictures();
                _selectedSong = s[r.Next(s.Length - 1)];
                
            }
            _selectedNews = await GetShortenedNews();
            viewModel.Song = _selectedSong;
            viewModel.News = _selectedNews;
            viewModel.Pictures = _selectedPictures;
            return View(viewModel);
        }

        public async Task<IActionResult> TenYearsAgo()
        {
          
            _context.SaveChanges();
            var news = _context.News.Where(n => n.DatePublished.Year == DateTime.Today.Year - 10 &&
                                                n.DatePublished.Month == DateTime.Today.Month);
            return View(news.Any() ? news : await AddNytNewsToDb());
            
        }

     

        private async Task<IEnumerable<News>> AddNytNewsToDb()
        {
           
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year - 10;
            var url = $"https://api.nytimes.com/svc/archive/v1/{year}/{month}.json?api-key=494e2fab7c1740319ebee4cfd9359b0f";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<JObject>(content);
            var l = obj["response"]["docs"].ToObject<IEnumerable<NYTNews>>();
            foreach (var n in l)
            {
                _context.News.Add(new News
                {
                    Url = n.Url,
                    DatePublished = n.DatePublished,
                    Description = n.Description,
                    Headline = n.Headline,
                    ImageUrl = n.Media.Any() ? $"https://nytimes.com/{(n.Media.FirstOrDefault(p => p.Subtype == "wide") ?? n.Media.First()).Url}" : ""
                });
            }
            await _context.SaveChangesAsync();
            return await _context.News.ToListAsync();
            
        }
       

        public async Task<IActionResult> FavoritePosts()
        {
            var u = await _manager.GetUserAsync(HttpContext.User);
            var user = _context.UserNews.Where(un => un.ApplicationUserId == u.Id).ToList();
            foreach (var userNewse in user)
            {
                userNewse.News = _context.News.SingleOrDefault(p => p.Id == userNewse.NewsId);
            }
            var model = new FavoriteViewModel()
            {
                News = user
            };
            return View(model);
        }

        private List<Picture> SelectPictures()
        {
            var selectedNumbers = new List<int>();
            var p = _context.Pictures.ToList();
            var r = new Random();
            var l = new List<Picture>();
            int k = 2;
            for (int i = 0; i < k; i++)
            {
                var j = r.Next(p.Count - 1);
                if (selectedNumbers.Contains(j)) k++;
                else
                {
                    selectedNumbers.Add(j);
                    l.Add(p[j]);
                }
            }
            return l;
        }

        [Route("/more/{type}")]
        public async Task<IActionResult> ShowMoreList(int? type)
        {
            var viewModel = new ShowMoreViewModel();
            switch (type)
            {
                case 0:
                    viewModel.News = await _context.News.Where(n => n.DatePublished == DateTime.Today).ToListAsync();
                    break;
                case 1:
                    viewModel.Songs = _context.Songs.ToList();
                    break;
                default:
                    viewModel.Pictures = _context.Pictures.ToList();
                    break;
            }
            return View(viewModel);
        }

        private async Task<List<News>> GetShortenedNews()
        {
            //TODO: Inca contine chestii repetitive
            var chosenNumbers = new List<int>();
            var r = new Random();
            var l = await _context.News.Where(n => n.DatePublished.Date == DateTime.Today.Date).ToListAsync();
            var lr = new List<News>();
            int k = (l.Count > 3) ? 4 : l.Count;
            for (int i = 0; i < k; i++)
            {
                var j = r.Next(l.Count - 1);
                if (chosenNumbers.Contains(j)) k++;
                else
                {
                    lr.Add(l[j]);
                    chosenNumbers.Add(j);
                }
                
            }
            return lr;
            
        }
        private async Task GetNews()
        {
            if (!_doneNews)
            {
                Program.Client.DefaultRequestHeaders.Accept.Clear();
                Program.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _doneNews = true;
            }
            
            var response = await Program.Client.GetAsync(@"https://newsapi.org/v1/articles?source=cnn&sortBy=top&apiKey=8596c1fa77264dae8f8b6dd607356671");
            if (response.IsSuccessStatusCode)
            {
                
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var l = obj.GetValue("articles").ToObject<List<News>>();
                foreach (var n in l)
                {
                    _context.News.Add(n);
                }
                await _context.SaveChangesAsync();
               
            }
           
        }

        private async Task PopulateDatabase()
        {
            await GetNews();   
            if (_context.Pictures.ToList().Count == 0)
            {
                var path = _env.ContentRootPath + @"\wwwroot\media\pictures\";
                foreach (var file in Directory.GetFiles(path))
                {
                    string[] a = file.Split('\\');
                    string[] parts = a[a.Length - 1].Split('_');
                    Picture pic = new Picture
                    {
                        Name = parts[0],
                        Author = parts[2].Split('.')[0],
                        Source = Path.GetFileName(file),
                        DateCreated = new DateTime(int.Parse(parts[1]), 1, 1)
                    };
                    _context.Pictures.Add(pic);
                }
                _context.SaveChanges();
            }
            if (_context.Songs.ToList().Count == 0)
            {
                var path = _env.ContentRootPath + @"\wwwroot\media\songs\";
                foreach (var file in Directory.GetFiles(path))
                {
                    string[] a = file.Split('\\');
                    string[] parts = a[a.Length - 1].Split('_');
                    Song s = new Song
                    {
                        Name = parts[2].Split('.')[0],
                        Author = parts[0],
                        Source = Path.GetFileName(file),
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
