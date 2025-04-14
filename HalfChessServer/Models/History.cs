using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalfChessServer.Models
{
    [AllowAnonymous]
    public class History
    {
        [Key]
        public int Id { get; set; } // Primary Key

        //[DataType(DataType.Date)]
        [Display(Name = "Started Date")]
        [DisplayFormat(NullDisplayText = "---")]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AtFrom { get; set; }
        //[DataType(DataType.Date)]
        [Display(Name = "Ended Date")]
        [DisplayFormat(NullDisplayText = "---")]

        //[DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AtTo { get; set; }

        [DisplayFormat(NullDisplayText = "Playing...")]
        public string? Result { get; set; }

        // Foreign Key
        public int PlayerId { get; set; }

        // Navigation Property
        public Player? Player { get; set; }
    }
}
