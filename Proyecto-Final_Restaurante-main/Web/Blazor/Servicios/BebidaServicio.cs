using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class BebidaServicio : IBebidaServicio
    {
        private readonly Config _config;
        private IBebidaRepositorio _bebidaRepositorio;

        public BebidaServicio(Config config)
        {
            _config = config;
            _bebidaRepositorio = new BebidaRepositorio(config.CadenaConexion);
        }
        public async Task<bool> Actualizar(Bebida bebida)
        {
            return await _bebidaRepositorio.Actualizar(bebida);
        }

        public async Task<bool> Eliminar(string codigo)
        {
            return await _bebidaRepositorio.Eliminar(codigo);
        }

        public async Task<IEnumerable<Bebida>> GetLista()
        {
            return await _bebidaRepositorio.GetLista();
        }

        public async Task<Bebida> GetPorCodigo(string codigo)
        {
            return await _bebidaRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Bebida bebida)
        {
            return await _bebidaRepositorio.Nuevo(bebida);
        }
    }
}