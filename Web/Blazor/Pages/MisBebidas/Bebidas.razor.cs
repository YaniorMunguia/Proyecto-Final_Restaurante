using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisBebidas
{
    public partial class Bebidas
    {
        [Inject] private IBebidaServicio bebidaServicio { get; set; }

        private IEnumerable<Bebida> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await bebidaServicio.GetLista();
        }
    }
}
