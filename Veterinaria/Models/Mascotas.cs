using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class Mascotas
    {
        [Key]
        public int idMascota { get; set; }
        public string nomMascota { get; set; }
        public decimal peso { get; set; }
        public string raza { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int idDueño { get; set; }

        public virtual Dueño Dueño { get; set; }


        public virtual ICollection<historiaClinica> HistoriaClinicas { get; set; }
    }
}