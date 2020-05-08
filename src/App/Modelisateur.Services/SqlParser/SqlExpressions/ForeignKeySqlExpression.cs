using System;

namespace Modelisateur.Services.SqlParser
{
    class ForeignKeySqlExpression : ISqlExpression
    {
        private string _colonne;
        private string _entiteRef;
        private string _colonneRef;
        public ForeignKeySqlExpression(string colonne, string entiteRef, string colonneRef)
        {
            _colonne = colonne;
            _entiteRef = entiteRef;
            _colonneRef = colonneRef;

        }

        public string SqlExpression
        {
            get 
            {
                return $"FOREIGN KEY ({_colonne}) REFERENCES {_entiteRef}({_colonneRef})";
            }
        }
    }
}
