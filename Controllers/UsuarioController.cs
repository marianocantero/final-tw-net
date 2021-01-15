using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TweetCtx db;
        public UsuarioController(TweetCtx context)
        {
            db = context;
        }

        public IActionResult Perfil(int id)
        {
            var tweetsUsuario = db.Tweets.Include(t=>t.Autor).Where(t=>t.UsuarioId == id);
            var usuarioSession = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            ViewBag.nombreUsuario = usuarioSession.UserName;
            ViewBag.emailUsuario = usuarioSession.Email;
            ViewBag.usuarioLogueadoVista = usuarioSession.UsuarioId;
            return View(tweetsUsuario);
            
        }

        public IActionResult SeguirUsuario(int id)
        {
            var usuarioBD = db.Usuarios.Find(id);
            if(usuarioBD != null)
            {
                var usuarioLogueado = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
                Siguiendo nuevoUsuarioASeguir = new Siguiendo(){
                    Usuario_Id = usuarioLogueado.UsuarioId,
                    IdUsuarioSiguiendo = usuarioBD.UsuarioId,
                };
                db.Siguiendo.Add(nuevoUsuarioASeguir);
                db.SaveChanges();
                return Redirect("~/Main/Index");
            }
            return StatusCode(404);
        }

        public IActionResult Editar(int id)
        {
            var usuarioLogueado = db.Usuarios.Find(id);
            if(usuarioLogueado != null)
            {
                return View(usuarioLogueado);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Editar(string email, string password, string username, int usuarioId)
        {
           
            
           var usuarioAEditar = db.Usuarios.Find(usuarioId);
            if(usuarioAEditar != null)
            {
               usuarioAEditar.Email = email;
               usuarioAEditar.Password = password;
               usuarioAEditar.UserName = username;
               db.Usuarios.Update(usuarioAEditar);
               db.SaveChanges();
               return Redirect("~/Main/Index"); 
            } 
            return StatusCode(404);    
        }

        public IActionResult Busqueda()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Busqueda(string busqueda)
         {
              var usuarioSession = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
                ViewBag.nombreUsuario = usuarioSession.UserName;
                ViewBag.emailUsuario = usuarioSession.Email;
                ViewBag.usuarioLogueadoVista = usuarioSession.UsuarioId;
            var resultadoBusqueda = db.Usuarios.Where(x=> x.UserName.Contains(busqueda));
            var topUsuarios = db.Usuarios.FromSqlRaw("SELECT TOP 2 * FROM Usuarios ORDER BY NEWID()");
             ViewBag.recomendados = topUsuarios;

             return View("ResultadosBusqueda" , resultadoBusqueda);
           
         }

    }

    
}