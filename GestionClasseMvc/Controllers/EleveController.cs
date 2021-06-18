using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionClasseMvc.Models;
using Ifinfo.Shared;
using Microsoft.EntityFrameworkCore;
//using System.Linq;

namespace GestionClasseMvc.Controllers
{
    public class EleveController : Controller
    {
        private GestionClasse db;

        public EleveController(GestionClasse injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult ListeEleve(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound("MET UN ID STP");
            }
            var ev = new EleveViewModel();

            var model = db.Eleves.Where(e => e.ClasseID == id).OrderBy(i => i.EleveNom).ToList();
            ev.Eleves = model;
            ev.Evaluations = db.Evaluations.Where(e => e.ClasseID == id).ToList();
            ev.Professeurs = db.Professeurs.ToList();
            ev.Classe = db.Classes.SingleOrDefault(c => c.ClasseID == id);
            if (model == null) 
            {
                return NotFound("Aucuns élèves trouvés");
            }
            return View(ev);
        }
        public IActionResult EleveDetail(long? id)
        {
            if (!id.HasValue)
            {
                return NotFound("Mettez un id dans url");
            }
            var eleve = db.Eleves.SingleOrDefault(e => e.EleveID == id);
            var classes = db.Classes;
            var newEleveModel = new EleveDetailViewModel
            {
                Eleve = eleve,
                Classes = classes
            };
            if (eleve == null)
            {
                return NotFound($"On a pas trouvé d'eleve avec l'id {id}");
            }
            return View(newEleveModel);
        }

        [HttpPost]
        public IActionResult ModifyEleve(Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                var entry = db.Entry(eleve);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                
                var newEleveModel = new EleveDetailViewModel
                {
                    Eleve = eleve
                };
                return View("EleveDetail", newEleveModel);
            }
            return View("test");
        }

        public IActionResult AjoutEleve(long? id)
        {
            if(id.HasValue)
            {
                var model = new AjoutEleveViewModel{
                    Classes = db.Classes.SingleOrDefault(c => c.ClasseID == id)
                };
                return View(model);
            }
            return View();
        }


        [HttpPost]
        public IActionResult AjoutEleve(long id, Eleve eleve)
        {
            if(ModelState.IsValid)
            {
                List<string> messages = new List<string>();
                eleve.EleveID = db.Eleves.Count()+1;
                eleve.ClasseID = id;
                db.Eleves.Add(eleve);
                var affected = db.SaveChanges();
                if(affected == 1){
                    var model = new AjoutEleveViewModel();
                    messages.Add("L'élève à bien été ajoutée !");
                    model.ValidationMessages = messages;
                return View(model);
                }

            }
            return View();
        }
    
    }
}