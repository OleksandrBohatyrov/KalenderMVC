using System;
using System.ComponentModel.DataAnnotations;

namespace KalenderMVC.Models
{
    public class Sondmus
    {
        [Key]
        public int SondmusId { get; set; }

        [Required]
        public string Pealkiri { get; set; }

        public string Kirjeldus { get; set; }

        [Required]
        public DateTime AlgusAeg { get; set; }

        [Required]
        public DateTime LoppAeg { get; set; }

        public int KasutajaId { get; set; }
        public Kasutajad Kasutaja { get; set; }
    }
}
