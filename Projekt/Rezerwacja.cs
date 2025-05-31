using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Rezerwacja
    {
        public int RezerwacjaId { get; set; }
        public string? ImieNazwisko { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<Miejsce> Miejsca { get; set; } = new List<Miejsce>();
    }

}
