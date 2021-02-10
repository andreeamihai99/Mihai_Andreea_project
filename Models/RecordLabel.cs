using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mihai_Andreea_project.Models
{
    public class RecordLabel
    {
 public int ID { get; set; }
        [Display(Name = "Record Label Name")]
        public string RecordLabelName { get; set; }
public ICollection<Song> Songs { get; set; } //navigation property
 }

    }

