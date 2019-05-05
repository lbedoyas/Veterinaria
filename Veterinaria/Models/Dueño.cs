using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Veterinaria.Models
{
    public class Dueño
    {
        [Key]
        public int idDueño { get; set; }

        [Display(Name ="Nombre del cliente")]
        public string nomDueño { get; set; }

        [Display(Name ="Apellido del cliente")]
        public string apeDueño { get; set; }

        [Display(Name ="telefono del cliente")]
        public int telefono { get; set; }

        [Display(Name ="direccion del cliente")]
        public string direccion { get; set; }

        public virtual ICollection<Mascotas> Mascotas { get; set; }

    }
}