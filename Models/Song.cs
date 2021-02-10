using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mihai_Andreea_project.Models
{
    public class Song
    { 
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Song Title")]
        public string Title { get; set; }
        /*[RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", 
            ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"),*/
            [Required, StringLength(50,
    MinimumLength = 3)]
        public string Artist { get; set; }
        [Display(Name = "Itunes price")]
        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal ItunesPrice { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Releasing Date")]
        public DateTime ReleasingDate { get; set; }
        public int RecordLabelID { get; set; }
        public RecordLabel RecordLabel { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
    }


}
