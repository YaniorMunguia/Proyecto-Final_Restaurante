using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Blazor.Pages.MisProductos
{
    public partial class NuevoProducto
    {
        [Inject] IProductoServicio productoServicio { get; set; }

        Producto prod = new Producto();

        [Inject] private NavigationManager navigationManager { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }

        string imgUrl = string.Empty;

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

            Producto prodExistente = new Producto();

            prodExistente = await productoServicio.GetPorCodigo(prod.Codigo);

            if (prodExistente != null)
            {
                if (!string.IsNullOrEmpty(prodExistente.Codigo))
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un producto con el mismo código", SweetAlertIcon.Warning);
                    return;
                }
            }

            bool inserto = await productoServicio.Nuevo(prod);

            if (inserto)
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
    }
}
