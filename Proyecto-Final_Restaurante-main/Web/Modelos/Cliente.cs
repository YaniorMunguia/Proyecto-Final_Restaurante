﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cliente
    {
        [Required(ErrorMessage = "Identidad es requerida")]
        public string Identidad { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
        public bool EstaActivo { get; set; }

        public Cliente()
        {
        }
        public Cliente(string identidad, string nombre, string telefono, string correo, string direccion, string fechaNacimiento, bool estaActivo)
        {
            Identidad = identidad;
            Nombre = nombre;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
            EstaActivo = estaActivo;
        }

        
    }
}
