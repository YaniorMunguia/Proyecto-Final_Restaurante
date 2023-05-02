using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.MisClientes
{
    public partial class EditarCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        private Cliente cliente = new Cliente();
        [Parameter] public string Identidad { get; set; }

        string imgUrl = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Identidad))
            {
                cliente = await clienteServicio.GetPorCodigoAsync(Identidad);
            }
        }

       

        protected async void Guardar()
        {
            if (string.IsNullOrWhiteSpace(cliente.Identidad) || string.IsNullOrWhiteSpace(cliente.Nombre)
                || string.IsNullOrWhiteSpace(cliente.Telefono) || string.IsNullOrWhiteSpace(cliente.Correo))
                
            {
                return;
            }

            bool edito = await clienteServicio.ActualizarAsync(cliente);

            if (edito)
            {
                await Swal.FireAsync("...LISTO...", "Se actualizo Cliente", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo actualizar el Cliente", SweetAlertIcon.Error);
            }

        }
        protected async void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");
        }

        protected async void Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el Cliente?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await clienteServicio.EliminarAsync(cliente.Identidad);

                if (elimino)
                {
                    await Swal.FireAsync("...LISTO...", "Se elimino este Cliente", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Clientes");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el Cliente", SweetAlertIcon.Error);
                }
            }
        }
    }
}


