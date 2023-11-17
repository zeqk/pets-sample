using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetsSample.DTOs;
using PetStore;
using Pet = PetsSample.DTOs.Pet;

namespace PetsSample.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly PetStoreApiClient _petStoreApiClient;

        public IList<Pet> Pets { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            PetStoreApiClient petStoreApiClient)
        {
            _logger = logger;
            _petStoreApiClient = petStoreApiClient;

        }

        public async Task OnGetAsync()
        {
            var result = await _petStoreApiClient.FindPetsByStatusAsync(Status.Pending);

            Pets = new List<Pet>(result.Count);

            foreach (var item in result)
            {
                Pets.Add(new Pet { Id = item.Id , Name = item.Name });
            }

            //Pets = new List<Pet>(2) { 
            //    new Pet { Id = 1, Name = "Pepe" },
            //    new Pet { Id = 2, Name = "Firulais" },
            //};
           
        }
    }
}