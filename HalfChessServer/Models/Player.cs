using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HalfChessServer.Models
{
    [AllowAnonymous]
    public class Player
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "You must input a player ID.")]
        [Range(1, 1000, ErrorMessage = "You must input integer AtFrom 1 AtTo 1000")]
        [DisplayName("Player ID")]
        public int PlayerNumber { get; set; }


        [Required(ErrorMessage = "You must input a player first name.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Minimum length is 2 characters.")]
        [DisplayName("Player Name")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "You must input a phone number.")]
        [Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number [example: 123-123-1234].")]
        public String? PhoneNumber { get; set; }

        [DisplayName("Registed Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistedDate { get; set; }

        [DisplayName("Quantity of games")]
        public int Quantity { get; set; }

        // Foreign Key
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        // Navigation Property
        public Country? Country { get; set; }

        public ICollection<History>? Histories { get; set; }
    }

}
