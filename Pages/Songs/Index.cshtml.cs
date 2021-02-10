﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mihai_Andreea_project.Data;
using Mihai_Andreea_project.Models;

namespace Mihai_Andreea_project.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly Mihai_Andreea_project.Data.Mihai_Andreea_projectContext _context;

        public IndexModel(Mihai_Andreea_project.Data.Mihai_Andreea_projectContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get; set; }
        public SongData SongD { get; set; }
        public int SongID { get; set; }
        public int GenreID { get; set; }
        public async Task OnGetAsync(int? id, int? genreID)
        {
            SongD = new SongData();

            SongD.Songs = await _context.Song
            .Include(b => b.RecordLabel)
            .Include(b => b.SongGenres)
            .ThenInclude(b => b.Genre)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                SongID = id.Value;
                Song song = SongD.Songs
                .Where(i => i.ID == id.Value).Single();
                SongD.Genres = song.SongGenres.Select(s => s.Genre);
            }
        }
    }

}
