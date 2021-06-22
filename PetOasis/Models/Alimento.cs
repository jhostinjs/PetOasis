using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class Alimento
    {
        [Display (Name = "Codigo")]public int codigo { get; set; }
        [Display(Name = "Nombre")] public string nombre { get; set; }
        [Display(Name = "Precio")] public decimal precio { get; set; }
        [Display(Name = "Stock")] public int cantidad { get; set; }
        [Display(Name = "Tipo")] public int tipo { get; set; }
        [Display(Name = "Disponibilidad")] public int disponibilidad { get; set; }
        [Display(Name = "Imagen")] public string imgAli { get; set; }
    }
}