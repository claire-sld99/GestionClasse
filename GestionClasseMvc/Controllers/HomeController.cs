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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GestionClasse db;
        public IEnumerable<Classe> Classes { get; set; }

        public HomeController(ILogger<HomeController> logger, GestionClasse injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Classes = db.Classes.ToList(),
                Eleves = db.Eleves.ToList()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        public IActionResult AjoutEvaluation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AjoutEvaluation(long id, Evaluation evaluation)
        {
            var rand = new Random();
            if(ModelState.IsValid)
            {
                List<string> messages = new List<string>();
                evaluation.ProfesseurID = rand.Next(1, db.Professeurs.Count()+1);
                evaluation.EvaluationID = db.Evaluations.Count()+1;
                evaluation.ClasseID = id;
                db.Evaluations.Add(evaluation);
                var affected = db.SaveChanges();
                if(affected == 1){
                    var model = new AjoutEvaluationViewModel();
                    messages.Add("L'évaluation à bien été créé !");
                    model.ValidationMessages = messages;
                return View(model);
                }

            }
            return View();
        }
    }
}
