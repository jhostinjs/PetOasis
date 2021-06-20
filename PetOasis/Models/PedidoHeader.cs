using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class PedidoHeader
    {
        [Display(Name = "Numero Pedido")] public string numero { get; set; }
        [Display(Name = "Fecha")] public DateTime fecha { get; set; }
        [Display(Name = "Usuario")] public string usuario { get; set; }
        [Display(Name = "Estado")] public string estado { get; set; }
    }
}