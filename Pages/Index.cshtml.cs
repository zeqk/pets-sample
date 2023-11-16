using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetsSample.DTOs;

namespace PetsSample.Pages
{
    public class IndexModel : PageModel
    {

       private readonly ILogger<IndexModel> _logger;

        public IList<Pet> Pets { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Pets = new List<Pet>(2) { 
                new Pet { Id = 1, Name = "Pepe" },
                new Pet { Id = 2, Name = "Firulais" },
            };
           
        }
    }
}