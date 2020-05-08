using System;
using System.Collections.Generic;

namespace Modelisateur.Services.SqlParser
{
    class TableSqlExpression : ISqlExpression
    {
        private string _nom;
        private ICollection<CreateColumnSqlExpression> _colonnes;
        private PrimaryKeySqlExpression _clePrimaire;
        private ICollection<ForeignKeySqlExpression> _clesEtrangeres;

        public TableSqlExpression(string nom, ICollection<CreateColumnSqlExpression> colonnes, PrimaryKeySqlExpression primaryKey, ICollection<ForeignKeySqlExpression> clesEtrangeres)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentNullException(nameof(nom));

            _nom = nom;
            _colonnes = colonnes;
            _clePrimaire = primaryKey;
            _clesEtrangeres = clesEtrangeres;
        }

        public string SqlExpression
        {
            get
            {
                string retour = string.Format("TABLE {0} (", _nom);
                
                retour = string.Join($"{Environment.NewLine}", retour, GetColonnesExpression());

                if (_clePrimaire != null)
                    retour = string.Join(Environment.NewLine, retour, _clePrimaire.SqlExpression);
                
                if (_clesEtrangeres != null)
                {
                    retour = string.Join($"{Environment.NewLine}", retour, GetForeignKeysExpression());
                }
                retour = string.Join(Environment.NewLine, retour, ");");

                return retour;
            }
        }

        //TODO: new class SqlExpressionCollection : ICollection<ISqlExpression>
        private string GetColonnesExpression()
        {
            string colonnes = string.Empty;
            foreach (var colonne in _colonnes)
            {
                colonnes = string.Join($"{Environment.NewLine},", colonnes, colonne.SqlExpression);
            }
            colonnes = colonnes.Substring(Environment.NewLine.Length + 1);
            return colonnes;
        }

        //TODO: new class SqlExpressionCollection : ICollection<ISqlExpression>
        private string GetForeignKeysExpression()
        {
            string clesEstrangeres = string.Empty;
            foreach (var cleEtrangere in _clesEtrangeres)
            {
                clesEstrangeres = string.Join($"{Environment.NewLine},", clesEstrangeres, cleEtrangere.SqlExpression);
            }
            clesEstrangeres = clesEstrangeres.Substring(Environment.NewLine.Length + 1);
            return clesEstrangeres;
        }

        //private string GetCollectionExpression(ICollection<ISqlExpression> expressionCollection, string separator)
        //{
        //    string sqlExpression = string.Empty;
        //    foreach (var expression in expressionCollection)
        //    {
        //        sqlExpression = string.Join($"{Environment.NewLine}{separator}", sqlExpression, expression.SqlExpression);
        //    }
        //    sqlExpression = sqlExpression.Substring(Environment.NewLine.Length + separator.Length);
        //    return sqlExpression;
        //}
    }
}