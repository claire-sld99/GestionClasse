﻿using System;
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
            var model = db.Eleves.SingleOrDefault(e => e.EleveID == id);
            var newEleveModel = new EleveDetailViewModel
            {
                Eleve = model
            };
            if (model == null)
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
            return View("AjoutEvaluation");
        }

        [HttpPost]
        public IActionResult AjoutEvaluation(Evaluation evaluation)
        {
             if(ModelState.IsValid)
             {
                 db.Evaluations.Add(evaluation);
                 db.SaveChanges();
             }
            return View();
        }
    }
}