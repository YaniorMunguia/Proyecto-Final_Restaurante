using Modelos;

namespace Datos.Interfaces
{
    public interface IFacturaRepositorio
    {
        Task<int> Nueva(Factura factura);
		Task<IEnumerable<Factura>> GetLista();
        Task<bool> Eliminar(string id);
    }
}
