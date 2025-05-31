using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Sala
    {
        public int SalaId { get; set; }
        public string? Nazwa { get; set; }
        public int LiczbaRzedow { get; set; }
        public int LiczbaMiejscWRzedzie { get; set; }
        public virtual ICollection<Miejsce> Miejsca { get; set; } = new List<Miejsce>();
    }

}
