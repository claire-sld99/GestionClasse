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
    public class EvaluationController : Controller
    {
        private GestionClasse db;

        public EvaluationController(GestionClasse injectedContext)
        {
            db = injectedContext;
        }

        public IActionResult AjoutEvaluation(long? id)
        {
            if(id.HasValue)
            {
                var model = new AjoutEvaluationViewModel{
                    Classes = db.Classes.SingleOrDefault(c => c.ClasseID == id)
                };
                return View(model);
            }
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