using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mihai_Andreea_project.Data;
using Mihai_Andreea_project.Models;

namespace Mihai_Andreea_project.Pages.Songs
{
    public class CreateModel : SongGenresPageModel

    {
        private readonly Mihai_Andreea_project.Data.Mihai_Andreea_projectContext _context;

        public CreateModel(Mihai_Andreea_project.Data.Mihai_Andreea_projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RecordLabelID"] = new SelectList(_context.RecordLabel, "ID",
"RecordLabelName");

            var song = new Song();
            song.SongGenres = new List<SongGenre>();
            PopulateAssignedGenreData(_context, song);
            return Page();
        }
        [BindProperty]
        public Song Song { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            var newSong = new Song();
            if (selectedGenres != null)
            {
                newSong.SongGenres = new List<SongGenre>();
                foreach (var gen in selectedGenres)
                {
                    var genToAdd = new SongGenre
                    {
                        GenreID = int.Parse(gen)
                    };
                    newSong.SongGenres.Add(genToAdd);
                }
            }
            if (await TryUpdateModelAsync<Song>(
            newSong,
            "Song",
            i => i.Title, i => i.Artist,
            i => i.ItunesPrice, i => i.ReleasingDate, i => i.RecordLabelID))
            {
                _context.Song.Add(newSong);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedGenreData(_context, newSong);
            return Page();
        }
    }
}
