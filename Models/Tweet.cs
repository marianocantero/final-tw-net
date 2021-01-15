using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Models
{
    public class Tweet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TweetId { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        public string Mensaje { get; set; }
        public virtual Usuario Autor { get; set; }
    }
}
