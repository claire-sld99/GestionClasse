using Ifinfo.Shared;
using System.Collections.Generic;

namespace GestionClasseMvc.Models
{
     public class DetailEvaluationViewModel
     {
         public Evaluation Evaluation {get;set;}

         public IEnumerable<Note> Notes {get;set;}

         public IEnumerable<Eleve> Eleves {get;set;}

         public IEnumerable<string> NotifMessages {get;set;}
     }
}