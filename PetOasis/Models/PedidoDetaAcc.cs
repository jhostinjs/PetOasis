using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class PedidoDetaAcc
    {

        [Display(Name = "Producto")] public int codigoimg { get; set; }
        [Display(Name = "")] public string producto { get; set; }
        [Display(Name = "Precio")] public decimal precio { get; set; }
        [Display(Name = "Cantidad")] public int cantidad { get; set; }
    }
}