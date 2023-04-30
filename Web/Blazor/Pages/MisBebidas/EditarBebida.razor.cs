using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisBebidas
{
    public partial class EditarBebida
    {
        [Inject] IBebidaServicio bebidaServicio { get; set; }

        Bebida bebi = new Bebida();

        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        string imgUrl = string.Empty;

        [Parameter] public string Codigo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                bebi = await bebidaServicio.GetPorCodigo(Codigo);
            }
        }

        protected async Task Guardar()
        {

            if (string.IsNullOrWhiteSpace(bebi.Codigo) || string.IsNullOrWhiteSpace(bebi.Descripcion))
            {
                return;
            }

            bool actualizo = await bebidaServicio.Actualizar(bebi);

            if (actualizo)
            {
                await Swal.FireAsync("...Listo...", "Bebida Guardado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("...Error...", "No se pudo guardar la bebida", SweetAlertIcon.Error);
            }
        }
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Bebidas");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar la bebida?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await bebidaServicio.Eliminar(Codigo);

                if (elimino)
                {
                    await Swal.FireAsync("...listo...", "Producto eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Bebidas");
                }
                else
                {
                    await Swal.FireAsync("...Error...", "No se pudo eliminar la bebida", SweetAlertIcon.Error);
                }
            }
        }

    }
}
