using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class Item
    {
        [Display(Name = "Codigo")]public int codigo { get; set; }
        [Display(Name = "Nombre")] public string nombre { get; set; }
        [Display(Name = "Precio")] public decimal precio { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
        [Display(Name = "Monto")] public decimal monto { get { return precio * cantidad; } }
    }
}