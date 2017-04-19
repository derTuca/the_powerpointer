using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public virtual ICollection<UserSong> Users { get; set; }
    }
}
