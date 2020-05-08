using Modelisateur.Model;
using System.Collections.Generic;
using System.Linq;

namespace Modelisateur.Services.SqlParser
{
    public class EntiteSqlCreator : ICreator<Entite, string>
    {
        public string Create(Entite entity)
        {
            List<CreateColumnSqlExpression> colonnesExpressions = entity.ElementsDonnees
                .Select(o => new CreateColumnSqlExpression(o.Name, o.Type, o.Required)).ToList();
            List<string> colonnnesCle = entity.ElementsDonnees.Where(o => o.IsKey).Select(o => o.Name).ToList();
            //List<ForeignKeySqlExpression> clesEtrangeres = entity.ElementsDonnees
            //    .Select(o => new ForeignKeySqlExpression(o.Name, o.ForeignKey.NameEntite, o.ForeignKey.NameElementDonnee)).ToList();
            var table = new TableSqlExpression(entity.Name, colonnesExpressions, new PrimaryKeySqlExpression(colonnnesCle, true), null);

            return new CreateSqlExpression(table).SqlExpression;
        }
    }
}