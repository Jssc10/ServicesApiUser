using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceApi.Models.Data;
using ServiceApi.Models.Response;

namespace ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: HomeController
        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioResponse usr  = new UsuarioResponse();

            try
            {
                usuarios = usr.Presentar();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en el control: {e.Message}");
            }

            return Ok(usuarios);
        }

        // GET: HomeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: HomeController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: HomeController/Create
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            UsuarioResponse usuarioResponse= new UsuarioResponse();
            try
            {
                usuarioResponse.Resgistrar(usuario);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine($"error Controller: {e.Message}");
                throw;
            }
        }

        // GET: HomeController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: HomeController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: HomeController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: HomeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
