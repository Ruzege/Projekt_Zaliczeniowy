using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Zaliczeniowy.Models
{
    public class Oprogramowanie
    {
        [Key]
        public int OprogramowanieId { get; set; }

        public string? Nazwa { get; set; }
        public string? Wersja { get; set; }
        public string? TypLicencji { get; set; }
        public DateTime DataInstalacji { get; set; }

        public int KomputerId { get; set; }

        [ForeignKey("KomputerId")]
        public virtual Komputer Komputer { get; set; } = null!;
    }
}