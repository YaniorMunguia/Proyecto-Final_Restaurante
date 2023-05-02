using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.MisClientes
{
    public partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Cliente cliente = new Cliente();

        string imgUrl = string.Empty;

        
        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(cliente.Identidad) || string.IsNullOrWhiteSpace(cliente.Nombre)
                || string.IsNullOrWhiteSpace(cliente.Telefono) || string.IsNullOrWhiteSpace(cliente.Correo))

            {
                return;
            }
           
            bool inserto = await clienteServicio.NuevoAsync(cliente);

            if (inserto)
            {
                await Swal.FireAsync("...LISTO...", "Se guardo el Cliente", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("...Error...", "No se pudo guardar el Cliente", SweetAlertIcon.Error);
            }

        }
        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }

    }
}
