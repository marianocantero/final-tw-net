using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Controllers
{
    public class AuthController : Controller
    {
        private readonly TweetCtx db;
        public AuthController(TweetCtx context)
        {
            db = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario datosLogueo)
        {
            {
                if (!ModelState.IsValid)
                {
                    return this.View();
                }
                else
                {
                    var email = datosLogueo.Email;
                    var resultado = db.Usuarios.FirstOrDefault(e=> e.Email == datosLogueo.Email);
                    //return Json(resultado);
                    if (resultado != null)
                    {
                        if (datosLogueo.Password == resultado.Password)
                        {
                            HttpContext.Session.Set<Usuario>("UsuarioLogueado", resultado);
                            var session = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
                            
                            return Redirect("~/Main/Index");

                        }
                        else
                        {
                            ViewBag.Error = "El email o la contraseña son invalidos";
                            return this.View();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }

                }
            }
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Usuario datos)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            db.Usuarios.Add(datos);
            db.SaveChanges();
            //Agregar el usuario a la sesion y redirigirlo al index
            HttpContext.Session.Set<Usuario>("UsuarioLogueado", datos);
            var resultado = db.Usuarios.FirstOrDefault(e => e.Email == datos.Email);
            if (resultado != null)
            {
                Siguiendo nuevoSeguimiento = new Siguiendo()
                {
                    Usuario_Id = resultado.UsuarioId,
                    IdUsuarioSiguiendo = resultado.UsuarioId
                };
                db.Siguiendo.Add(nuevoSeguimiento);
                db.SaveChanges();
                return Redirect("~/Main/Index");
            }
            return NotFound();
        }
    }
}
