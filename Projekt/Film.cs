using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Film
    {
        public int FilmId { get; set; }
        public string? Tytul { get; set; }
        public DateTime Data { get; set; }
        public int SalaId { get; set; }
        public virtual Sala Sala { get; set; } = null!;
    }
}

