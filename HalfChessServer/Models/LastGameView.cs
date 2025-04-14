using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HalfChessServer.Models
{
    [Keyless]
    public class LastGameView
    {

        public String? Name { get; set; }

        [DisplayName("Last played Date")]
        [DisplayFormat(NullDisplayText = "Never played.")]
        //[DataType(DataType.Date)]
        public DateTime? LastPlayDate { get; set; }
    }

}
