using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class Animal
    {
        [Required][Display(Name ="Codigo")]public int codigo { get; set; }
        [Required][Display(Name = "Nombre")] public string nombre { get; set; }
        [Required][Display(Name = "Tipo")] public int tipo { get; set; }

        [Required][Display(Name = "Fecha de rescate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] public DateTime rescate { get; set; }

        [Required][Display(Name = "Sexo")] public string sexo { get; set; }
        [Required][Display(Name = "Tamaño")] public string tamaño { get; set; }

        [Required][Display(Name = "Estado")] public int estado { get; set; }

        [Required][Display(Name = "Fecha aprox. de nacimiento")] public string nacimiento { get; set; }

        [Required][Display(Name = "Disponibilidad")] public int disponibilidad { get; set; }

        [Display(Name = "Imagen")] public string imgAni { get; set; }

    }
}