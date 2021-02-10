using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mihai_Andreea_project.Data;
using Mihai_Andreea_project.Models;

namespace Mihai_Andreea_project.Pages.RecordLabel
{
    public class IndexModel : PageModel
    {
        private readonly Mihai_Andreea_project.Data.Mihai_Andreea_projectContext _context;

        public IndexModel(Mihai_Andreea_project.Data.Mihai_Andreea_projectContext context)
        {
            _context = context;
        }

        public IList<Mihai_Andreea_project.Models.RecordLabel> RecordLabel { get;set; }

        public async Task OnGetAsync()
        {
            RecordLabel = await _context.RecordLabel.ToListAsync();
        }
    }
}
