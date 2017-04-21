using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace The_Powerpointer.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public byte[] Image { get; set; }
        [Display(Name = "Select new profile picture")]
        public IFormFile ProfilePicture { get; set; }
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }


        public bool BrowserRemembered { get; set; }
    }
}
