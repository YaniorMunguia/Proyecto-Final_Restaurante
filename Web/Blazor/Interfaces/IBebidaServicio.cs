using Modelos;

namespace Blazor.Interfaces
{
    public interface IBebidaServicio
    {
        Task<bool> Nuevo(Bebida bebida);
        Task<bool> Actualizar(Bebida bebida);
        Task<bool> Eliminar(string codigo);
        Task<IEnumerable<Bebida>> GetLista();
        Task<Bebida> GetPorCodigo(string codigo);
        
    }
}

