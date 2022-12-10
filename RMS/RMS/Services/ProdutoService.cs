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
    public class ProdutoService
    {
        private IRepository<PRODUTO> _UsuarioRepository;

        public ProdutoService()
        {
            _UsuarioRepository = new Repository<PRODUTO>();
        }

        public async Task<bool> InsetLisProduto(List<PRODUTO> usuario)
        {
            try
            {
                await _UsuarioRepository.InsertList(usuario);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<PRODUTO>> GetProdutos()
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

        public async Task<bool> DeletarProdutos()
        {
            try
            {
                await _UsuarioRepository.DeleteAll();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
