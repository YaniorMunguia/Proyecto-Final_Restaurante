using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly Config _config;
        private IProductoRepositorio _productoRepositorio;

        public ProductoServicio(Config config)
        {
            _config = config;
            _productoRepositorio = new ProductoRepositorio(config.CadenaConexion);
        }

        public async Task<bool> Actualizar(Producto producto)
        {
            return await _productoRepositorio.Actualizar(producto);
        }

        public async Task<bool> Eliminar(string codigo)
        {
            return await _productoRepositorio.Eliminar(codigo);
        }

        public async Task<IEnumerable<Producto>> GetLista()
        {
            return await _productoRepositorio.GetLista();
        }

        public async Task<Producto> GetPorCodigo(string codigo)
        {
            return await _productoRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Producto producto)
        {
            return await _productoRepositorio.Nuevo(producto);
        }
    }
}
