using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mihai_Andreea_project.Data;
using Mihai_Andreea_project.Models;

namespace Mihai_Andreea_project.Pages.Songs
{
    public class EditModel : SongGenresPageModel
    {
        private readonly Mihai_Andreea_projectContext _context;

        public EditModel(Mihai_Andreea_project.Data.Mihai_Andreea_projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Song
 .Include(b => b.RecordLabel)
 .Include(b => b.SongGenres).ThenInclude(b => b.Genre)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            if (Song == null)
            {
                return NotFound();
            }
            PopulateAssignedGenreData(_context, Song);
            ViewData["RecordLabelID"] = new SelectList(_context.RecordLabel, "ID",
"RecordLabelName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songToUpdate = await _context.Song
            .Include(i => i.RecordLabel)
            .Include(i => i.SongGenres)
            .ThenInclude(i => i.Genre)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (songToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Song>(
            songToUpdate,
            "Song",
            i => i.Title, i => i.Artist,
            i => i.ItunesPrice, i => i.ReleasingDate, i => i.RecordLabel))
            {
                UpdateSongGenres(_context, selectedGenres, songToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateSongGenres(_context, selectedGenres, songToUpdate);
            PopulateAssignedGenreData(_context, songToUpdate);
            return Page();
        }
    }
}
