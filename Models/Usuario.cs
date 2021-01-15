using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es valido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El email no es valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [MinLength(6, ErrorMessage = "El password debe ser de minimo 6 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string UserName { get; set; }
        public List<Tweet> Tweets { get; set; }
    }
}
