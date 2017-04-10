using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace The_Powerpointer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public byte[] ProfilePicture { get; set; }

        

    }


}
