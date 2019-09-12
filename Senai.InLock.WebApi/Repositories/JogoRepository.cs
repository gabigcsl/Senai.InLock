using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }

        public void Cadastrar(Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogos);
                ctx.SaveChanges();
            }
        }

        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.IdJogos == id);
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogos = ctx.Jogos.FirstOrDefault(x => x.IdJogos == id);
                ctx.Jogos.Remove(jogos);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.FirstOrDefault(x => x.IdJogos == jogos.IdJogos);
                JogoBuscado.Nome = jogos.Nome;
                ctx.Jogos.Update(JogoBuscado);
                ctx.SaveChanges();
            }
        }

    }
}
