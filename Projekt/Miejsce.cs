using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public enum StrefaCenowa { SuperPromo, Promo, Standard, Specjalna }

    public class Miejsce
    {
        public int MiejsceId { get; set; }
        public int Rzad { get; set; }
        public int Numer { get; set; }
        public bool Zarezerwowane { get; set; }
        public StrefaCenowa Strefa { get; set; } // 👈 NOWE
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; } = null!;
        public int? RezerwacjaId { get; set; }
        public virtual Rezerwacja? Rezerwacja { get; set; }
    }
}
