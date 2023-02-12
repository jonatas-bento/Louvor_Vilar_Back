using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Versao { get; set; }
        public string Autor { get; set; }
        public string Letra { get; set; }
        public string Artista { get; set; }

    }
}
