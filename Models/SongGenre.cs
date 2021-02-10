using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mihai_Andreea_project.Models
{
    public class SongGenre
    {
        public int ID { get; set; }
        public int SongID { get; set; }
        public Song Song { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
