using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.MisProductos
{
    public partial class EditarProducto
    {
        [Inject] IProductoServicio productoServicio { get; set; }

        Producto prod = new Producto();

        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        string imgUrl = string.Empty;

        [Parameter] public string Codigo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                prod = await productoServicio.GetPorCodigo(Codigo);
            }
        }

        private async Task SeleccionarImagen(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            prod.Foto = buffers;
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        protected async Task Guardar()
        {

            if (string.IsNullOrWhiteSpace(prod.Codigo) || string.IsNullOrWhiteSpace(prod.Descripcion))
            {
                return;
            }

            bool actualizo = await productoServicio.Actualizar(prod);

            if (actualizo)
            {
                await Swal.FireAsync("Felicidades", "Producto Guardado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el producto", SweetAlertIcon.Error);
            }
        }
        protected async Task Cancelar()
        {
            navigationManager.NavigateTo("/Productos");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el producto?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await productoServicio.Eliminar(Codigo);

                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Producto eliminado", SweetAlertIcon.Success);
                    navigationManager.NavigateTo("/Productos");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar el producto", SweetAlertIcon.Error);
                }
            }
        }
    }
}
