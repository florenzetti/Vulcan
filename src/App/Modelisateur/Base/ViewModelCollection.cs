using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Modelisateur.Base
{
    class ViewModelCollection<TViewModel, TModel> : BindableCollection<TViewModel>
        where TViewModel : class, IViewModel, new()
        where TModel : class
    {
        private bool _syncEnabled;
        private readonly ICollection<TModel> _models;

        public ViewModelCollection(ICollection<TModel> models)
        {
            _models = models;
            _syncEnabled = true;
            foreach (var model in _models)
                Load(new TViewModel() { Model = model });
            CollectionChanged += ViewModelCollection_CollectionChanged;
        }

        public override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add { base.CollectionChanged += value; }
            remove { base.CollectionChanged -= value; }
        }


        public void Load(ICollection<TViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                Load(viewModel);
            }
        }

        public void Load(TViewModel viewModel)
        {
            _syncEnabled = false;
            Add(viewModel);
            _syncEnabled = true;
        }

        private void ViewModelCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (!_syncEnabled)
                return;

            _syncEnabled = false;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var model in e.NewItems.OfType<IViewModel>().Select(o => o.Model).OfType<TModel>())
                        _models.Add(model);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var model in e.OldItems.OfType<IViewModel>().Select(o => o.Model).OfType<TModel>())
                        _models.Remove(model);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ObservableCollection<TViewModel> viewModelCollection = sender as ObservableCollection<TViewModel>;
                    _models.Clear();
                    if (viewModelCollection != null)
                    {
                        foreach (TModel model in viewModelCollection.Select(o => o.Model).OfType<TModel>())
                        {
                            _models.Add(model);
                        }
                    }
                    break;
            }

            _syncEnabled = true;
        }
    }
}