using System.Collections.Generic;
using Ifinfo.Shared;

namespace GestionClasseMvc.Models
{
    public class HomeIndexViewModel
    {
        public IList<Classe> Classes {get; set;}
        public IList<Eleve> Eleves {get; set;}
    }
}