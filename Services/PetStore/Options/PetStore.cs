using System.ComponentModel.DataAnnotations;

namespace PetsSample.Services.PetStore.Options;

public class PetStore
{
    [Required]
    public string BaseAddress { get; set; }
}
