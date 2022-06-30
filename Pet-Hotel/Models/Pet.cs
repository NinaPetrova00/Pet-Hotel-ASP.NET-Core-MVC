using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Hotel.Models
{
    public class Pet
    {
        
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
               ErrorMessage = "Invalid pet name! Pet name should contain only alphabets!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
              ErrorMessage = "Invalid pet type! Pet type should contain only alphabets!")]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$",
              ErrorMessage = "Invalid pet breed! Pet breed should contain only alphabets!")]
        public string Breed { get; set; }

        [Range(1,20)]
        public int Age { get; set; }

        [Required]
        [Display(Name="Pet Owner")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", 
            ErrorMessage = "Invalid pet owner name! Pet owner name should contain only alphabets!")]
        public string PetOwner { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Checked In")]
        public DateTime checkedIn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Checked Out")]
        public DateTime? checkedOut { get; set; }  
    }
}
