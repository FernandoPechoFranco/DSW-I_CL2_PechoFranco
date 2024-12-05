using Microsoft.AspNetCore.Mvc;
using DSW_I_CL2_PechoFranco.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSW_I_CL2_PechoFranco.Controllers
{
    public class CDController : Controller
    {
       
        private static List<CD> cds = new List<CD>
        {
            new CD { Id = 1, Nombre = "Thriller", Artista = "Michael Jackson", Genero = "Pop", Precio = 15.99m },
            new CD { Id = 2, Nombre = "Back in Black", Artista = "AC/DC", Genero = "Rock", Precio = 12.99m }
        };

      
        public IActionResult Index()
        {
            return View(cds); 
        }

    
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CD cd)
        {
            if (ModelState.IsValid)
            {
        
                cd.Id = cds.Max(c => c.Id) + 1;
                cds.Add(cd);
                return RedirectToAction("Index"); 
            }
            return View(cd); 
        }

     
        public IActionResult Edit(int id)
        {
            var cd = cds.FirstOrDefault(c => c.Id == id);
            if (cd == null) return NotFound();
            return View(cd);
        }

    
        [HttpPost]
        public IActionResult Edit(CD cd)
        {
            if (ModelState.IsValid)
            {
                var existingCd = cds.FirstOrDefault(c => c.Id == cd.Id);
                if (existingCd == null) return NotFound();

          
                existingCd.Nombre = cd.Nombre;
                existingCd.Artista = cd.Artista;
                existingCd.Genero = cd.Genero;
                existingCd.Precio = cd.Precio;

                return RedirectToAction("Index");
            }
            return View(cd);
        }

 
        public IActionResult Delete(int id)
        {
            var cd = cds.FirstOrDefault(c => c.Id == id);
            if (cd == null) return NotFound();
            cds.Remove(cd);
            return RedirectToAction("Index");
        }
    }
}
