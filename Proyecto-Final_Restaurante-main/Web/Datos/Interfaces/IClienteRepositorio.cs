using Modelos;


namespace Datos.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<bool> NuevoAsync(Cliente cliente);
        Task<bool> ActualizarAsync(Cliente cliente);
        Task<bool> EliminarAsync(string identidad);
        Task<IEnumerable<Cliente>> GetListaAsync();
        Task<Cliente> GetPorCodigoAsync(string identidad);
    }
}
