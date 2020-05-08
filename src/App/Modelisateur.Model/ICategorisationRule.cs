using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Modelisateur.Model
{
    public interface ICategorisationRule<in TInput,out TCategory>
        where TInput : DomainEntityBase
        where TCategory : Enum
    {
        TCategory Categorise(TInput entity);
    }
}