using Ifinfo.Shared;
using System.Collections.Generic;

namespace GestionClasseMvc.Models
{
     public class AjoutEleveViewModel
     {

         public Eleve Eleve { get; set; }
        public Classe Classes { get; set; }

        public IEnumerable<string> ValidationMessages {get; set;}

        public bool HasMessages {get; set;}
         
     }
}