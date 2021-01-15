using Microsoft.AspNetCore.Mvc;
using ProyectoFinalTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Controllers
{
    public class TweetController : Controller
    {
        private readonly TweetCtx db;
        public TweetController(TweetCtx context)
        {
            db = context;
        }
        public IActionResult Crear()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Crear(string mensaje)
        {
            var session = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Tweet nuevoTweet = new Tweet()
            {
                UsuarioId = session.UsuarioId,
                Mensaje = mensaje,
            };

            db.Tweets.Add(nuevoTweet);
            db.SaveChanges();

             return Redirect("~/Main/Index");
            
        }
        
        public IActionResult Likear(int id)
        {   
            

            var Tweet = db.Tweets.Find(id);
            if(Tweet == null)
            {
                return StatusCode(404);
            }
           var UsuarioLogueado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Like nuevoLike = new Like(){
                IdTweet = Tweet.TweetId,
                IdUsuarioLikeo = UsuarioLogueado.UsuarioId
            };
            db.Likes.Add(nuevoLike);
            db.SaveChanges();
            return Redirect("~/Main/Index");
            
        }

        public IActionResult Eliminar(int id)
        {
            var resultado = db.Tweets.Find(id);
            if(resultado == null)
            {
                return StatusCode(404);
            }
            db.Tweets.Remove(resultado);
            db.SaveChanges();
            return Redirect("~/Main/Index");
        }

        //    public IActionResult ConsultarTweets()
        //    {
        //        var resultado = db.Tweets.Include(t => t.Autor).Where(t => t.UsuarioId.Equals(0));
        //        return Json(resultado);
        //        retu
        //    }
        //}
    }
}
