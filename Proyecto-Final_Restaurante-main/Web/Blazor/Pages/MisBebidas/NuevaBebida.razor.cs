using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisBebidas
{
    public partial class NuevaBebida
    {
        [Inject] IBebidaServicio bebidaServicio { get; set; }

        Bebida bebi = new Bebida();

        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        string imgUrl = string.Empty;

       
        protected async Task Guardar()
        {

            if (string.IsNullOrWhiteSpace(bebi.Codigo) || string.IsNullOrWhiteSpace(bebi.Descripcion))
            {
                return;
            }

            Bebida bebiExistente = new Bebida();

            bebiExistente = await bebidaServicio.GetPorCodigo(bebi.Codigo);

            if (bebiExistente != null)
            {
                if (!string.IsNullOrEmpty(bebiExistente.Codigo))
                {
                    await Swal.FireAsync("--Advertencia--", "Ya existe una bebida con el mismo código", SweetAlertIcon.Warning);
                    return;
                }
            }

            bool inserto = await bebidaServicio.Nuevo(bebi);

            if (inserto)
            {
                await Swal.FireAsync("...Listo...", "La bebida se guardo", SweetAlertIcon.Success);
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

    }
}
