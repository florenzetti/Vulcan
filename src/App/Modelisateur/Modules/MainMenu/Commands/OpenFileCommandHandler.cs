//using Gemini.Framework.Commands;
//using Gemini.Framework.Services;
//using Gemini.Modules.Shell.Commands;
//using System;
//using System.ComponentModel.Composition;
//using System.Threading.Tasks;
//using Caliburn.Micro;
//using Modelisateur.Modules.TextEditor.ViewModels;
//using Microsoft.Win32;
//using Gemini.Demo.Modules.TextEditor;
//using Gemini.Framework;

//namespace Modelisateur.Modules.MainMenu.Commands
//{
//    [CommandHandler]
//    class OpenFileCommandHandler : CommandHandlerBase<OpenFileCommandDefinition>
//    {
//        private readonly IEditorProvider _editorProvider;
//        private readonly IDocument _document;

//        [ImportingConstructor]
//        public OpenFileCommandHandler(IEditorProvider provider, IDocument document)
//        {
//            _editorProvider = provider;
//            _document = document;
//        }
//        public override async Task Run(Command command)
//        {
//            OpenFileDialog fileDialog = new OpenFileDialog();
//            if (fileDialog.ShowDialog() == true)
//            {
//                await _editorProvider.Open(_document, fileDialog.FileName);
//            }
//        }
//    }
//}
