using System;

namespace Modelisateur.Services.SqlParser
{
    class CreateColumnSqlExpression : ISqlExpression
    {
        private string _nom;
        private string _type;
        private bool _obligatoire;

        public string SqlExpression
        {
            get
            {
                string retour = string.Format("{0} {1}", _nom, _type);
                if (_obligatoire)
                    retour = string.Format("{0} {1}", retour, "NOT NULL");

                return retour;
            }
        }

        public CreateColumnSqlExpression(string nom, string typedonnees, bool obligatoire)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentNullException(nameof(nom));
            if (string.IsNullOrWhiteSpace(typedonnees))
                throw new ArgumentNullException(nameof(typedonnees));

            _nom = nom;
            _type = typedonnees;
            _obligatoire = obligatoire;
        }
    }
}