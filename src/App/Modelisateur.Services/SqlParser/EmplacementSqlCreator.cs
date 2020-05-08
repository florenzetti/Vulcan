using Modelisateur.Model;
using System;
using System.Linq;

namespace Modelisateur.Services.SqlParser
{
    public class EmplacementSqlCreator : EntiteSqlCreator, ICreator<Emplacement, string>
    {
        public string Create(Emplacement entity)
        {
            string result = string.Empty;
            foreach (var entite in entity.Entites)
                result = string.Join(Environment.NewLine, result, Create(entite));

            return result;
        }
    }
}
