using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pet_Hotel.Models
{
    public class PetTypeViewModel
    {
        public List<Pet>? Pets { get; set; }
        public SelectList? Types { get; set; }
        public string? PetType { get; set; }
        public string? SearchName { get; set; }
        public string? SearchBreed { get; set; }
        public string? SearchPetOwner { get; set; }
    }
}
