using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Powerpointer.Models.AppModels;

namespace The_Powerpointer.Models.ItemViewModels
{
    public class SongViewModel
    {
        public Song Song { get; set; }
        public List<Song> SuggestedSongs { get; set; }
    }
}
