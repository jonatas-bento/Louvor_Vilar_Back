using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Entities
{
    public class Ensaio
    {
        public int Id { get; set; }
        public DateTime DataDoEnsaio { get; set; }
        public List<Song> CancoesDoEnsaio { get; set; }
        public int NumeroDeMembrosPresentes { get; set; }

    }
}
