using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Bebida
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre de la bebida es obligatorio")]
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public bool EstaActivo { get; set; }


        public Bebida()
        {
        }
        public Bebida(string codigo, string descripcion, int existencia, decimal precio, bool estaActivo)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Existencia = existencia;
            Precio = precio;
            EstaActivo = estaActivo;
        }
    }

}