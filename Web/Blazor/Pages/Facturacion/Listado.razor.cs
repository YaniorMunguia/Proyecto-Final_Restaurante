using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.Facturacion
{
    public partial class Listado
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }

        private IEnumerable<Factura> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await facturaServicio.GetLista();
        }

    }
}
