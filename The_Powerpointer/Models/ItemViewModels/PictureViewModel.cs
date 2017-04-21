using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Powerpointer.Models.ItemViewModels
{
    public class PictureViewModel
    {
        public Picture Picture { get; set; }
        public ICollection<Picture> SuggestedPictures { get; set; }
    }
}
