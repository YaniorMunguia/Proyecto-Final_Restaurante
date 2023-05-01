using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class ClienteServicio : IClienteServicio
    {

        private readonly Config _config;
        private IClienteRepositorio _clienteRepositorio;

        public ClienteServicio(Config config)
        {
            _config = config;
            _clienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }
        public async Task<bool> ActualizarAsync(Cliente cliente)
        {
            return await _clienteRepositorio.ActualizarAsync(cliente);
        }

        public async Task<bool> EliminarAsync(string identidad)
        {
            return await _clienteRepositorio.EliminarAsync(identidad);
        }

        public async Task<IEnumerable<Cliente>> GetListaAsync()
        {
            return await _clienteRepositorio.GetListaAsync();
        }

        public async Task<Cliente> GetPorCodigoAsync(string identidad)
        {
            return await _clienteRepositorio.GetPorCodigoAsync(identidad);
        }

        public async Task<bool> NuevoAsync(Cliente cliente)
        {
            return await _clienteRepositorio.NuevoAsync(cliente);
        }
    }
}
