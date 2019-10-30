using CRUD_Alumnos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                using (AlumnosContexts db = new AlumnosContexts())
                {
                    //List<Alumno> lista = db.Alumno.Where(a => a.Edad > 21).ToList();
                    return View(db.Alumno.ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (AlumnosContexts db = new AlumnosContexts())
                {
                    a.FechaRegistro = DateTime.Now;
                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("","Error al registrar Alumno - "+ ex);
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            using(AlumnosContexts db = new AlumnosContexts())
            {
                try
                {
                    Alumno al = db.Alumno.Where(a => a.ID == id).FirstOrDefault();
                    //Alumno al2 = db.Alumno.Find(id);
                    return View(al);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("","Error al Editar"+ex);
                    return View();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (AlumnosContexts db = new AlumnosContexts())
                {
                    Alumno al = db.Alumno.Find(a.ID);
                    al.Nombre = a.Nombre;
                    al.Apellido = a.Apellido;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DetallesA(int id)
        {
            try
            {
                using (AlumnosContexts db = new AlumnosContexts())
                {
                    Alumno al = db.Alumno.Find(id);
                    return View(al);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult EliminarA (int id)
        {
            try
            {
                using(AlumnosContexts db = new AlumnosContexts())
                {
                    Alumno al = db.Alumno.Find(id);
                    db.Alumno.Remove(al);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar al ALumno" + ex);
                return View();
            }
        }
    }
}