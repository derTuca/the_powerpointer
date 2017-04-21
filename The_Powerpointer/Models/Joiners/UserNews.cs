using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Powerpointer.Models.AppModels;

namespace The_Powerpointer.Models.Joiners
{
    public class UserNews
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
