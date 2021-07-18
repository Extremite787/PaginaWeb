using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Webcreado.Models;

namespace Webcreado.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            List<Persona> listpersona = new List<Persona>();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("ListaPersona")))
            {
                Persona pers = new Persona();
                pers.Cedula = "1751418177";
                pers.Nombre = "Dylan";
                pers.Apellido = "Mejia";
                pers.Direccion = "Quito";
                pers.Genero = "Masculino";
                for (int i = 0; i < 5; i++)
                {
                    listpersona.Add(pers);
                }
            }
            else
            {
                listpersona = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("ListaPersona"));
            }
            HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(listpersona));
            return View(listpersona);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Persona persona)
        {
            try
            {
                List<Persona> listpersona = new List<Persona>();
                listpersona = JsonConvert.DeserializeObject<List<Persona>>(HttpContext.Session.GetString("ListaPersona"));
                listpersona.Add(persona);
                HttpContext.Session.SetString("ListaPersona", JsonConvert.SerializeObject(listpersona));
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
