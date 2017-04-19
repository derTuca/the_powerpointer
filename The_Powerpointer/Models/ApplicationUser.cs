using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Songs = new List<UserSong>();
            News = new List<UserNews>();
            Pictures = new List<UserPicture>();
        }
        
        public ICollection<UserSong> Songs { get; set; }
        public ICollection<UserNews> News { get; set; }
        public ICollection<UserPicture> Pictures { get; set; }
        public byte[] ProfilePicture { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }



    }


}
