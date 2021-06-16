using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionClasseMvc.Models;
using Ifinfo.Shared;

namespace GestionClasseMvc.Controllers
{
    public class EleveController : Controller
    {
        private readonly ILogger<EleveController> _logger;
        private GestionClasse db;

        public HomeController(ILogger<EleveController> logger, GestionClasse injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}