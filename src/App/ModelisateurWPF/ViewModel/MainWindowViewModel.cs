using Microsoft.Win32;
using Modelisateur.Model;
using Modelisateur.Model.Repositories;
//using Modelisateur.Services.DataVault;
//using Modelisateur.Services.SqlBuilder;
using ModelisateurWPF.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace ModelisateurWPF.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<CommandViewModel> MenuCommands { get; }

        public ObservableCollection<CommandViewModel> Commands { get; }

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (value != _selectedTabIndex)
                {
                    _selectedTabIndex = value;
                    OnPropertyChanged(nameof(SelectedTabIndex));
                }
            }
        }

        public ObservableCollection<TabViewModel> Tabs { get; }

        public MainWindowViewModel()
        {
            MenuCommands = new ObservableCollection<CommandViewModel>();
            //MenuCommands.Add(new CommandViewModel("_Open", new RelayCommand(o => this.OpenFile())));
            //MenuCommands.Add(new CommandViewModel("_Save", new RelayCommand(o => this.SaveFile())));
            //MenuCommands.Add(new CommandViewModel("_Generate DataVault", new RelayCommand(o => this.GenerateDataVault())));
            //MenuCommands.Add(new CommandViewModel("_Generate Sql", new RelayCommand(o => this.GenerateSql())));
            Commands = new ObservableCollection<CommandViewModel>();

            Tabs = new ObservableCollection<TabViewModel>();
        }

        //private void OpenTab(string name, string filePath)
        //{
        //    var tab = Tabs.FirstOrDefault(o => o.DisplayName == name);
        //    if (tab == null)
        //    {
        //        tab = new EmplacementViewModel(name, filePath);
        //        tab.OnClose += Tab_OnClose;
        //        Tabs.Add(tab);
        //    }
        //    SelectedTabIndex = Tabs.IndexOf(tab);
        //}

        //private void Tab_OnClose(object sender, EventArgs e)
        //{
        //    var tab = (TabViewModel)sender;
        //    SelectedTabIndex = Tabs.IndexOf(tab) - 1 > 0 ? Tabs.IndexOf(tab) : 0;
        //    Tabs.Remove(tab);

        //    //var command = _commands.SingleOrDefault(o => o.DisplayName == tab.DisplayName);
        //    //if (command != null)
        //    //    Commands.Remove(command);
        //}

        //private void OpenFile()
        //{
        //    OpenFileDialog fileDialog = new OpenFileDialog();
        //    if (fileDialog.ShowDialog() == true)
        //    {
        //        if(!Commands.Any(o => o.DisplayName == fileDialog.SafeFileName))
        //            Commands.Add(
        //                new CommandViewModel(fileDialog.SafeFileName, 
        //                new RelayCommand(o => this.OpenTab(fileDialog.SafeFileName, fileDialog.FileName)))
        //                );
        //        OpenTab(fileDialog.SafeFileName, fileDialog.FileName);
        //    }
        //}

        //private void SaveFile()
        //{
        //    if(SelectedTabIndex >= 0)
        //        Tabs[SelectedTabIndex].SaveCommand.Execute(null);
        //}

        //private void GenerateDataVault()
        //{
        //    if (SelectedTabIndex >= 0)
        //    {
        //        EmplacementViewModel vm = Tabs[SelectedTabIndex] as EmplacementViewModel;
        //        Emplacement emplacementSource = Tabs[SelectedTabIndex].Model as Emplacement;
        //        var newEmplacement = new Emplacement() { Name = $"RDV{emplacementSource.Name}" };
        //        foreach (var entiteSource in emplacementSource.Entites)
        //        {
        //            var hub = new HubCreationRule().Create(entiteSource);
        //            newEmplacement.Entites.Add(hub);
        //            newEmplacement.Entites.Add(new SatelliteCreationRule().Create(entiteSource));
        //        }

        //        var fileInfo = new System.IO.FileInfo(vm.FilePath);
        //        var newFileInfo = new System.IO.FileInfo(@$"{fileInfo.Directory.FullName}\{newEmplacement.Name}.txt");
        //        EmplacementRepository repository = new EmplacementRepository(newFileInfo);
        //        repository.Save(newEmplacement, true);

        //        Commands.Add(
        //                new CommandViewModel(newFileInfo.Name,
        //                new RelayCommand(o => this.OpenTab(newFileInfo.Name, newFileInfo.FullName)))
        //                );
        //        OpenTab(newFileInfo.Name, newFileInfo.FullName);
        //    }
        //}

        //private void GenerateSql()
        //{
        //    if (SelectedTabIndex >= 0)
        //    {
        //        EmplacementViewModel vm = Tabs[SelectedTabIndex] as EmplacementViewModel;
        //        Emplacement emplacementSource = Tabs[SelectedTabIndex].Model as Emplacement;

        //        EmplacementSqlCreator creator = new EmplacementSqlCreator();
        //        string sqlEmplacement = creator.Create(emplacementSource);

        //        var fileInfo = new System.IO.FileInfo(vm.FilePath);
        //        var newFileInfo = new System.IO.FileInfo(@$"{fileInfo.Directory.FullName}\{emplacementSource.Name}SQL.txt");
        //        EmplacementRepository repository = new EmplacementRepository(newFileInfo);
        //        repository.Save(sqlEmplacement, true);
        //    }
        //}
    }
}