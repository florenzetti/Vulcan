using System;
using System.Collections.Generic;
using System.Text;

namespace Modelisateur.Base
{
    public interface IViewModel
    {
        object Model { get; set; }
    }

    interface IViewModel<T> : IViewModel where T : class
    {
        T TypedModel { get; }
    }
}
