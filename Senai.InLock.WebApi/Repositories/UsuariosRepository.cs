using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuariosRepository
    {
        public List<Usuarios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios Login(LoginViewModel login)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Usuarios usuarios = ctx.Usuarios.Include(x => x.IdPermissaoNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuarios == null)
                {
                    return null;
                }
                return usuarios;
            }


        }
    }
}
