﻿using System;
using System.Collections.Generic;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Models.AppModels
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