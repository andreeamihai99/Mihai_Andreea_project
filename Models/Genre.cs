using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mihai_Andreea_project.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string GenreName { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
    }
}
