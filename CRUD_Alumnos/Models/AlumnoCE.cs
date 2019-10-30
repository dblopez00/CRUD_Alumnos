using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    public class AlumnoCE
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Ingrese su Edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Ingrese su Sexo")]
        public string Sexo { get; set; }
        public System.DateTime FechaRegistro { get; set; }
    }

    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno
    {
        public string NombreCompleto { get { return Nombre + " " + Apellido; } set { } }
    }
}