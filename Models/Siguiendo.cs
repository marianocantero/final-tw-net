using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Models
{
    public class Siguiendo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccion { get; set; }
        public int Usuario_Id { get; set; }
        public int IdUsuarioSiguiendo { get; set; }
        public virtual Usuario Seguidor { get; set; }
    }
}
