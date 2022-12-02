using RMS.Data;
using RMS.Data.Interfaces;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Services
{
    public class LoginService
    {
        private IRepository<USUARIO> _UsuarioRepository;

        public LoginService()
        {
            _UsuarioRepository = new Repository<USUARIO>();
        }

        public async Task<bool> InsetUsuario(USUARIO usuario)
        {
            try
            {
                await _UsuarioRepository.Insert(usuario);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<USUARIO>> GetUsuarios()
        {
            try
            {
                var usuarios =  await _UsuarioRepository.Get();

                return usuarios;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Logar(string email)
        {
            try
            {
                var usuarios = await _UsuarioRepository.Get(c=> c.EMAIL == email);

                return usuarios.Count() > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
