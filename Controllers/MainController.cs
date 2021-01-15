using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Controllers
{
    public class MainController : Controller
    {
        private readonly TweetCtx db;
        public MainController(TweetCtx context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var usuarioLogueado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            var resultadoSiguiendo = db.Tweets.FromSqlInterpolated($"select TOP 200 * from Tweets T join Siguiendo S on(T.UsuarioId = S.IdUsuarioSiguiendo) where S.Usuario_Id = {usuarioLogueado.UsuarioId} ORDER BY TweetId DESC").Include(t=>t.Autor);
            /* var resultadoSiguiendo = db.Tweets.FromSqlRaw("select TOP 200 * from Tweets T join Siguiendo S on(T.UsuarioId = S.IdUsuarioSiguiendo) where S.Usuario_Id = 1 ORDER BY TweetId DESC").Include(t=>t.Autor); */

            var topUsuarios = db.Usuarios.FromSqlRaw("SELECT TOP 2 * FROM Usuarios ORDER BY NEWID()");
            var Likes = db.Likes.FromSqlRaw("SELECT * FROM  Likes");
            

            var usuarioSession = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            ViewBag.nombreUsuario = usuarioSession.UserName;
            ViewBag.emailUsuario = usuarioSession.Email;
            ViewBag.usuarioLogueadoVista = usuarioSession.UsuarioId;
            ViewBag.recomendados = topUsuarios;
            ViewBag.Likes = Likes;
                //.Include(t => t.Autor);
            return View(resultadoSiguiendo);
        }
    }
}
