using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetOasis.Models
{
    public class TarjetaAcc
    {
        [Display(Name = "Fecha")] public DateTime fecha { get; set; }
        [Display(Name = "Entrada")] public string entrada { get; set; }
        [Display(Name = "Salida")] public string salida { get; set; }
        [Display(Name = "Detalle")] public string detalle { get; set; }
    }
}