using System;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Domains
{
    public partial class Jogos
    {
        public int IdJogos { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string Valor { get; set; }
        public int? IdEstudio { get; set; }

        public Estudios IdEstudioNavigation { get; set; }
    }
}
