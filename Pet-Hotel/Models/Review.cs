using System.ComponentModel.DataAnnotations;

namespace Pet_Hotel.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
               ErrorMessage = "Invalid name! Name should contain only alphabets!")]
        [Display(Name = "Name")]
        public string Username { get; set; }

        [Display(Name = "Review")]
        public string? Description { get; set; }

        [RegularExpression(@"^[*]{1,5}$",
            ErrorMessage = "Raiting should be between 1 and 5 stars (*)!")]
        public string Rating { get; set; }
    }
}
