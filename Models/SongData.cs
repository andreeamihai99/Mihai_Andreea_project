using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mihai_Andreea_project.Models
{
    public class SongData
    {
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<SongGenre> SongGenres { get; set; }
    }
}
