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
            try
            {
                var result = await _petStoreApiClient.FindPetsByStatusAsync(Status.Available);
                Pets = new List<Pet>(result.Count);
                foreach (var pet in result)
                {
                    Pets.Add(new Pet { Id = pet.Id, Name = pet.Name });
                }
            }
            catch (Exception ex)
            {

                throw;
            }           
        }
    }
}