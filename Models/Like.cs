using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Models
{
    public class Like
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLike{get;set;}
        public int IdTweet{get;set;}
        public int IdUsuarioLikeo{get;set;}
        public virtual Usuario Likeador {get;set;}
    }
}