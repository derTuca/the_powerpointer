using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Powerpointer.Models
{
    public class MainPageViewModel
    {
        public ICollection<News> News { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public Song Song { get; set; }
        public ApplicationUser User { get; set; }
    }
}
