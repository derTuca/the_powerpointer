using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        //public ApplicationUser()
        //{
        //    Songs = new List<UserSong>();
        //    News = new List<UserNews>();
        //    Pictures = new List<UserPicture>();
        //}
        private ICollection<UserNews> _news;
        public virtual ICollection<UserSong> Songs { get; set; }

        public virtual ICollection<UserNews> News
        {
            get { return _news ?? (_news = new Collection<UserNews>()); }
            protected set { _news = value; }
        }
        public virtual ICollection<UserPicture> Pictures { get; set; }
        public byte[] ProfilePicture { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }



    }


}
