using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_Powerpointer.Models
{
    public interface INews
    {
        string Headline { get; set; }
        string Url { get; set; }
        DateTime DatePublished { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
    }
}
