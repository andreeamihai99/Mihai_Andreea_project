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
    public class DeleteModel : PageModel
    {
        private readonly Mihai_Andreea_project.Data.Mihai_Andreea_projectContext _context;

        public DeleteModel(Mihai_Andreea_project.Data.Mihai_Andreea_projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mihai_Andreea_project.Models.RecordLabel RecordLabel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecordLabel = await _context.RecordLabel.FirstOrDefaultAsync(m => m.ID == id);

            if (RecordLabel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecordLabel = await _context.RecordLabel.FindAsync(id);

            if (RecordLabel != null)
            {
                _context.RecordLabel.Remove(RecordLabel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
