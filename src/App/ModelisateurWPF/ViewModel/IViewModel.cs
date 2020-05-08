using System;
using System.Collections.Generic;
using System.Text;

namespace ModelisateurWPF.ViewModel
{
    interface IViewModel
    {
        public object Model { get; }
    }

    interface IViewModel<T> : IViewModel where T : class
    { 
        public T TypedModel { get; }
    }
}
