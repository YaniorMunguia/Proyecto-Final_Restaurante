﻿using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Producto
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public byte[] Foto { get; set; }
        public bool EstaActivo { get; set; }

        public Producto()
        {
        }

        public Producto(string codigo, string descripcion, int existencia, decimal precio, byte[] foto, bool estaActivo)
        {
            Codigo=codigo;
            Descripcion=descripcion;
            Existencia=existencia;
            Precio=precio;
            Foto=foto;
            EstaActivo=estaActivo;
        }
    }

}
