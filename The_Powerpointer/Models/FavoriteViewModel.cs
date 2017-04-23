using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Models
{
    public class FavoriteViewModel
    {
        public ICollection<UserNews> News { get; set; }
        public List<UserPicture> Pictures { get; set; }
        public List<UserSong> Songs { get; set; }
        public ApplicationUser User { get; set; }
    }
}
