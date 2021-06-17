using System.Collections.Generic;
using Ifinfo.Shared;

namespace GestionClasseMvc.Models
{
    public class EleveViewModel
    {
        public Classe Classe { get; set; }
        public IList<Eleve> Eleves { get; set; }
    }
}