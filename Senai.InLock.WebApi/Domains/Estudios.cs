using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Domains
{
    public partial class Estudios
    {
        public Estudios()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int IdEstudio { get; set; }
        public string Nome { get; set; }
        public string PaisOrigem { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Jogos> Jogos { get; set; }
    }
}
