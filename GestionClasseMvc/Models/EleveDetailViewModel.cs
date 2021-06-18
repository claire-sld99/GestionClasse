using Ifinfo.Shared;
using System.Collections.Generic;

namespace GestionClasseMvc.Models
{
    public class EleveDetailViewModel
    {
        public Eleve Eleve { get; set; }
        public IEnumerable<Classe> Classes { get; set; }

        public bool HasErrors { get; set; }

        public IEnumerable<string> ValidationErrors { get; set; }
    }
}