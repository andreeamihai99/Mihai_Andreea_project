using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mihai_Andreea_project.Data;

namespace Mihai_Andreea_project.Models
{
    public class SongGenresPageModel : PageModel
    {
    
 public List<AssignedGenreData> AssignedGenreDataList;
        public void PopulateAssignedGenreData(Mihai_Andreea_projectContext context,
        Song Song)
        {
            var allGenres = context.Genre;
            var songGenre = new HashSet<int>(
            Song.SongGenres.Select(c => c.SongID));
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach (var gen in allGenres)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    GenreID = gen.ID,
                    Name = gen.GenreName,
                    Assigned = songGenre.Contains(gen.ID)
                });
            }
        }
        public void UpdateSongGenres(Mihai_Andreea_projectContext context,
        string[] selectedGenres, Song songToUpdate)
        {
            if (selectedGenres == null)
            {
                songToUpdate.SongGenres = new List<SongGenre>();
                return;
            }
            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var songGenres = new HashSet<int>
            (songToUpdate.SongGenres.Select(c => c.Genre.ID));
            foreach (var gen in context.Genre)
            {
                if (selectedGenresHS.Contains(gen.ID.ToString()))
                {
                    if (!songGenres.Contains(gen.ID))
                    {
                        songToUpdate.SongGenres.Add(
                        new SongGenre
                        {
                            SongID = songToUpdate.ID,
                            GenreID = gen.ID
                        });
                    }
                }
                else
                {
                    if (songGenres.Contains(gen.ID))
                    {
                        SongGenre courseToRemove
                        = songToUpdate
                        .SongGenres
                        .SingleOrDefault(i => i.GenreID == gen.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    } }
