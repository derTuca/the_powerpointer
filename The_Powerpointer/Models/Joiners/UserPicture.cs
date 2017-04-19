using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Powerpointer.Models.Joiners
{
    public class UserPicture
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
