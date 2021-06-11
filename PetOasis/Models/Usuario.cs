using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class Usuario
    {
        [Display(Name = "Usuario")]public string codigo { get; set; }
        [Display(Name = "Contraseña")]public string contraseña { get; set; }
        [Display(Name = "Nombre")]public string nombre { get; set; }
        [Display(Name = "Apellido")]public string apellido { get; set; }
        [Display(Name = "Telefono")]public string telefono { get; set; }
        [Display(Name = "Email")][DataType(DataType.EmailAddress)] public string email { get; set; }
        [Display(Name = "Tipo")]public int tipo { get; set; }
    }
}