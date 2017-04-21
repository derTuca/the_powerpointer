using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Powerpointer.Models.AppModels;

namespace The_Powerpointer.Models.ItemViewModels
{
    public class PictureViewModel
    {
        public Picture Picture { get; set; }
        public ICollection<Picture> SuggestedPictures { get; set; }
    }
}
