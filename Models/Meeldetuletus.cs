using System;
using System.ComponentModel.DataAnnotations;

namespace KalenderMVC.Models
{
    public class Meeldetuletus
    {
        [Key]
        public int MeeldetuletusId { get; set; }

        [Required]
        public DateTime MeeldetuletuseAeg { get; set; }

        public int SondmusId { get; set; }
        public Sondmus Sondmus { get; set; }
    }
}
