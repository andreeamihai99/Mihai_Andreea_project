using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mihai_Andreea_project.Data;
using Mihai_Andreea_project.Models;

namespace Mihai_Andreea_project.Pages.RecordLabel
{
    public class CreateModel : PageModel
    {
        private readonly Mihai_Andreea_project.Data.Mihai_Andreea_projectContext _context;

        public CreateModel(Mihai_Andreea_project.Data.Mihai_Andreea_projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RecordLabelID"] = new SelectList(_context.Set<Mihai_Andreea_project.Models.RecordLabel>(), "ID", "RecordLabelName");
            return Page();
        }

        [BindProperty]
        public Mihai_Andreea_project.Models.RecordLabel RecordLabel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecordLabel.Add(RecordLabel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
