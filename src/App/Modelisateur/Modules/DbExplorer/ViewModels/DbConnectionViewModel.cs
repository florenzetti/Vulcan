using Gemini.Framework;
using Gemini.Framework.Services;
using Gemini.Modules.Explorer;
using Modelisateur.Connectors.Snowflake;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Windows.Input;

namespace Modelisateur.Modules.DbExplorer.ViewModels
{
    [Export(typeof(DbConnectionViewModel))]
    public class DbConnectionViewModel : WindowBase
    {
        private readonly DbExplorerProvider _explorerProvider;

        public string Host { get; set; }
        public string Account { get; set; }
        public string User { get; set; }

        [ImportingConstructor]
        public DbConnectionViewModel(DbExplorerProvider explorerProvider)
        {
            _explorerProvider = explorerProvider;
        }

        public void OpenConnection(ObjectExplorer objectExplorer)
        {
            _explorerProvider.ObjectExplorer = objectExplorer;
            TryCloseAsync(true);
        }
    }
}
