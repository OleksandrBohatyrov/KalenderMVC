using System;
using System.ComponentModel.DataAnnotations;

namespace KalenderMVC.Models
{
    public class Kasutajad
    {
        [Key]
        public int KasutajaId { get; set; }

        [Required]
        public string Kasutajanimi { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Salasona { get; set; }

        public DateTime Loodud { get; set; } = DateTime.Now;
    }
}
