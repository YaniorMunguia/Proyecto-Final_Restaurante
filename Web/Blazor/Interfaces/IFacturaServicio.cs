using Modelos;

namespace Blazor.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> Nueva(Factura factura);
		Task<IEnumerable<Factura>> GetLista();
        Task<bool> Eliminar(string id);
    }
}
