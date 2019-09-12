using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository
    {
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.ToList();
            }
        }

        public void Cadastrar(Estudios estudios)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudios);
                ctx.SaveChanges();
            }
        }

        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.IdEstudio == id);
            }
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudios = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudios);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estudios estudios)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudioBuscado = ctx.Estudios.FirstOrDefault(x => x.IdEstudio == estudios.IdEstudio);
                estudioBuscado.PaisOrigem = estudios.PaisOrigem;
                ctx.Estudios.Update(estudioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Estudios> ListarJogosPorIdEstudio(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
            }
        }

        public List<Estudios> ListarJogosPorNomeEstudio(string nome)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.Include(x => x.Jogos).ToList();
            }
        }

        public List<Estudios> ListarJogosPorValor()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FromSql("Select Top(5) * From Jogos").ToList();
            }
        }
    }
}
