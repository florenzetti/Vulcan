using Gemini.Modules.CodeEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace Modelisateur.Modules.CodeEditor
{
    public class LanguageDefinitions
    {
        [Export]
        public static ExcludeLanguageDefinition excludeCsharp = new ExcludeLanguageDefinition("C#");
        [Export]
        public static ExcludeLanguageDefinition excludeJs = new ExcludeLanguageDefinition("JavaScript");
        [Export]
        public static ExcludeLanguageDefinition excludeHTML = new ExcludeLanguageDefinition("HTML");
        [Export]
        public static ExcludeLanguageDefinition excludeASP = new ExcludeLanguageDefinition("ASP/XHTML");
        [Export]
        public static ExcludeLanguageDefinition excludeBoo = new ExcludeLanguageDefinition("Boo");
        [Export]
        public static ExcludeLanguageDefinition excludeCoco = new ExcludeLanguageDefinition("Coco");
        [Export]
        public static ExcludeLanguageDefinition excludeCSS = new ExcludeLanguageDefinition("CSS");
        [Export]
        public static ExcludeLanguageDefinition excludeCpp = new ExcludeLanguageDefinition("C++");
        [Export]
        public static ExcludeLanguageDefinition excludeJava = new ExcludeLanguageDefinition("Java");
        [Export]
        public static ExcludeLanguageDefinition excludePatch = new ExcludeLanguageDefinition("Patch");
        [Export]
        public static ExcludeLanguageDefinition excludePhp = new ExcludeLanguageDefinition("PHP");
        [Export]
        public static ExcludeLanguageDefinition excludeTex = new ExcludeLanguageDefinition("TeX");
        [Export]
        public static ExcludeLanguageDefinition excludeVbnet = new ExcludeLanguageDefinition("VBNET");
        [Export]
        public static ExcludeLanguageDefinition excludeXml = new ExcludeLanguageDefinition("XML");
        [Export]
        public static ExcludeLanguageDefinition excludeMarkdown = new ExcludeLanguageDefinition("MarkDown");
        [Export]
        public static ExcludeLanguageDefinition excludePowershell = new ExcludeLanguageDefinition("PowerShell");
    }
}
