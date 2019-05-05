using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class historiaClinica
    {
        [Key]
        public int idHistoriaClinica { get; set; }

        [Display(Name ="Ingrese el tipo de consulta")]
        public string tipoConsulta { get; set; }

        public string vacuna { get; set; }

        [DataType(DataType.Date)]
        public DateTime fecha { get; set; }
        public string descConsulta { get; set; }

        public int idMascota { get; set; }


        public virtual Mascotas Mascotas { get; set; }

    }
}