using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Powerpointer.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime DateDied { get; set; }
    }
}
