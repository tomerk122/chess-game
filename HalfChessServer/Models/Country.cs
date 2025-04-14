using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HalfChessServer.Models
{
    [AllowAnonymous]
    public class Country
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        public bool? IsPlayer { get; set; }
        // Navigation Property
        public ICollection<Player>? Players { get; set; }
    }
}
