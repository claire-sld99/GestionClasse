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
using System.Linq;

namespace GestionClasseMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private GestionClasse db;

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
            if(!id.HasValue)
            {
                return NotFound("MET UN ID STP");
            }
            var ev = new EleveViewModel();

                var model = db.Eleves.Where(e => e.ClasseID == id).ToList();
                ev.Eleves = model;
                if(model == null)
                {
                    return NotFound("Aucuns élèves trouvés");         
                }
            
            
            return View(ev);
        }
    }
}
