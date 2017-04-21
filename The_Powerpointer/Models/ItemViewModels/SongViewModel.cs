using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Powerpointer.Models.ItemViewModels
{
    public class SongViewModel
    {
        public Song Song { get; set; }
        public List<Song> SuggestedSongs { get; set; }
    }
}
