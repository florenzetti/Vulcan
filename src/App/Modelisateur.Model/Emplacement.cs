using Newtonsoft.Json;
using System.Collections.Generic;

namespace Modelisateur.Model
{
    public class Emplacement : DomainEntityBase, ISourceCode
    {
        public List<Entite> Entites { get; }

        public Emplacement()
        {
            Entites = new List<Entite>();
        }

        public string GetSourceCode()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public Emplacement SetFromSourceCode(string sourceCode)
        {
            return JsonConvert.DeserializeObject<Emplacement>(sourceCode);
        }
    }
}