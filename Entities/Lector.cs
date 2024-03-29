﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Lector
    {

        [Key]
        public int LectorID { get; set; }
        public string Nombre { get; set; }
        public int Matricula { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }

        public Lector()
        {
            LectorID = 0;
            Nombre = string.Empty;
            Matricula = 0;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Pasword = string.Empty;
            Fecha = DateTime.Now;
        }

    }
}
