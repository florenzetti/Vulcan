using System;

namespace Modelisateur.Services.SqlParser
{
    class CreateSqlExpression : ISqlExpression
    {
        private ISqlExpression _sqlExpression;

        public CreateSqlExpression(ISqlExpression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            _sqlExpression = expression;
        }

        public string SqlExpression
        {
            get
            {
                return string.Join(Environment.NewLine, string.Format("CREATE {0}", _sqlExpression.SqlExpression));
            }
        }
    }
}
