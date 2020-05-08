using Gemini.Framework.Services;
using Gemini.Modules.Explorer;
using Gemini.Modules.Explorer.Models;
using Modelisateur.Connectors.Snowflake;
using Modelisateur.Connectors.Snowflake.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

namespace Modelisateur.Modules.DbExplorer
{
    [Export(typeof(DbExplorerProvider))]
    public class DbExplorerProvider : IExplorerProvider
    {
        public ObjectExplorer ObjectExplorer { get; set; }
        public IEnumerable<EditorFileTemplate> ItemTemplates
        {
            get
            {
                yield return new EditorFileTemplate() { Name = "Database" };
            }
        } 

        public bool IsOpened => _sourceTree != null;

        public string SourceName => "Database";

        private TreeItem _sourceTree;
        public TreeItem SourceTree => _sourceTree;

        public DbExplorerProvider()
        {
        }

        public void CloseSource()
        {
            throw new NotImplementedException();
        }

        public FolderTreeItem CreateFolder(string fullPath, string name)
        {
            throw new NotSupportedException();
        }

        public TreeItem CreateItem(string fullPath, string name, EditorFileTemplate fileTemplate)
        {
            throw new NotSupportedException();
        }

        public void DeleteItem(TreeItem item)
        {
            throw new NotImplementedException();
        }

        public EditorFileTemplate GetTemplate(TreeItem item)
        {
            throw new NotImplementedException();
        }

        public void MoveItem(TreeItem item, TreeItem moveToParent)
        {
            throw new NotImplementedException();
        }

        public TreeItem OpenSource()
        {
            _sourceTree = new FolderTreeItem("Server", "server") { IsExpanded = true };
            var dbs = ObjectExplorer?.GetDatabases();
            foreach (var db in dbs)
            {
                _sourceTree.AddChild(new Models.DatabaseTreeItem(db));
            }

            return _sourceTree;
        }

        public void UpdateItem(TreeItem item, string newName)
        {
            _sourceTree = null;
        }
    }
}
