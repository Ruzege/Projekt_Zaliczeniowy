using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Zaliczeniowy.Models
{
    public class Komputer
    {
        [Key]
        public int KomputerId { get; set; }

        public string? Nazwa { get; set; }
        public string? Dzial { get; set; }
        public string? Uzytkownik { get; set; }

        public virtual ObservableCollection<Oprogramowanie> Programy { get; } = new();
    }
}