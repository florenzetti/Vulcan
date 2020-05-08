using System;
using System.Collections.Generic;
using System.Text;


namespace Modelisateur.Model
{
    public class Liaison
    {
        public string NameEntite { get; set; }
        public List<string> ElementsDonnees { get; }

        public Liaison()
        {
            ElementsDonnees = new List<string>();
        }
    }
}
