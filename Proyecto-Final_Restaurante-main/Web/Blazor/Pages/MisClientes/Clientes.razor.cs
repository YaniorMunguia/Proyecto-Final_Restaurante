using Blazor.Interfaces;
using Blazor.Servicios;
using Microsoft.AspNetCore.Components;
using Modelos;


namespace Blazor.Pages.MisClientes
{
	public partial class Clientes
	{
		[Inject] private IClienteServicio clienteServicio { get; set; }

		private IEnumerable<Cliente> liste { get; set; }

		protected override async Task OnInitializedAsync()
		{
			liste = await clienteServicio.GetListaAsync();
		}
	}
}
