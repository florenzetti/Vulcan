using Caliburn.Micro;
using Gemini.Framework;
using Gemini.Framework.Services;
using Gemini.Modules.Explorer;
using Gemini.Modules.Explorer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows.Input;

namespace Modelisateur.Modules.DbExplorer.ViewModels
{
    [Export(typeof(IDbExplorerTool))]
    public class DbExplorerViewModel : Tool, IDbExplorerTool
    {
        private readonly IWindowManager _windowManager;
        private DbExplorerProvider _explorerProvider;
        public string FullPath => _explorerProvider.SourceName;
        public bool IsSourceOpened => _explorerProvider.IsOpened;

        private ICommand _openCommand;
        public ICommand OpenSourceCommand => _openCommand ?? (_openCommand = new RelayCommand(o => OpenSource()));

        public override PaneLocation PreferredLocation => PaneLocation.Left;

        public string OpenSourceButtonText => "Connect to database";

        public TreeItem SourceTree => _explorerProvider.SourceTree;

        TreeItem IExplorerTool.SourceTree => throw new NotImplementedException();

        [ImportingConstructor]
        public DbExplorerViewModel(DbExplorerProvider explorerProvider, IWindowManager windowManager)
        {
            _explorerProvider = explorerProvider;
            _windowManager = windowManager;
            DisplayName = "Database explorer";
        }

        public void CloseSource()
        {
            _explorerProvider.CloseSource();
        }

        public async void OpenSource()
        {
            var connectionViewModel = IoC.Get<DbConnectionViewModel>();
            var result = await _windowManager.ShowDialogAsync(connectionViewModel);
            if(result == true)
                _explorerProvider.OpenSource();
            NotifyOfPropertyChange(() => SourceTree);
        }
    }
}
