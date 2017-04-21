using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Powerpointer.Models.AppModels;

namespace The_Powerpointer.Models
{
    public class NewsCardViewModel
    {
        public News News { get; set; }
        public bool Favorited { get; set; }
    }
}
