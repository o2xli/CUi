using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUi.Components
{
    internal class FileDialog : IDialog
    {
        private readonly Options options;
        private readonly bool isOSWindows;
        public FileDialog(Options? options = null) 
        {
            if (options == null)
                this.options = new();
            else
                this.options = options;
            if (Environment.OSVersion.Platform.ToString()
                .StartsWith("win", true, null))
            {
                isOSWindows = true;
            }
        }
        public string Show()
        {
            string currentFolder = options.InitialDirectory;
            while (true)
            {

                Directory.SetCurrentDirectory(currentFolder);
                
                RefreshDisplay(currentFolder);

                var choices = GetChoices(currentFolder);

                string title = options.SelectFile ? options.TextSelectFile : options.TextSelectFolder;
                var selectionPromptResult = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"[green]{title}:[/]")
                        .PageSize(options.PageSize)
                        .MoreChoicesText($"[grey]{options.TextMoreChoices}[/]")
                        .AddChoices(choices.Keys)
                    );

                var selectedItemPath = choices[selectionPromptResult];
                if (selectedItemPath == "/////")
                {
                    selectedItemPath = SelectDrive();
                    currentFolder = selectedItemPath;
                }
                if (selectedItemPath == "///new")
                {
                    string newFolderName = AnsiConsole.Ask<string>($"[blue]{options.TextCreateNew}: [/]");
                    if (newFolderName != null)
                    {
                        try
                        {
                            Directory.CreateDirectory(newFolderName);
                            selectedItemPath = Path.Combine(currentFolder, newFolderName);
                        }
                        catch (Exception ex)
                        {
                            AnsiConsole.WriteLine("[red]Error: [/]" + ex.Message);
                        }
                    }
                }

                if (selectedItemPath == Directory.GetCurrentDirectory())
                    return currentFolder;
                if (Directory.Exists(selectedItemPath))
                    currentFolder = selectedItemPath;
                else
                    return selectedItemPath;
            }
        }

        private void RefreshDisplay(string actualFolder)
        {
            string headerText = options.SelectFile ? options.TextSelectFile : options.TextSelectFolder;
            AnsiConsole.Clear();
            AnsiConsole.WriteLine();
            var rule = new Rule($"[b][green]{headerText}[/][/]").Centered();
            AnsiConsole.Write(rule);

            AnsiConsole.WriteLine();
            AnsiConsole.Markup($"[b][Yellow]{options.TextCurrentFolder}: [/][/]");
            var path = new TextPath(actualFolder.ToString());
            path.RootStyle = new Style(foreground: Color.Green);
            path.SeparatorStyle = new Style(foreground: Color.Green);
            path.StemStyle = new Style(foreground: Color.Blue);
            path.LeafStyle = new Style(foreground: Color.Yellow);
            AnsiConsole.Write(path);
            AnsiConsole.WriteLine();
        }

        private Dictionary<string, string> GetChoices(string actualFolder)
        {
            Dictionary<string, string> choices = new Dictionary<string, string>();

            if (isOSWindows)
            {
                choices.Add($"[green]{GetIcon(":computer_disk:")} {options.TextSelectDrive}[/]", "/////");
            }
            if (!options.SelectFile)
            {
                choices.Add($"{GetIcon(":ok_button:")} [green]{options.TextSelectCurrent}[/]", Directory.GetCurrentDirectory());
            }
            if (options.CanCreateFolder)
            {
                choices.Add($"[green]{GetIcon(":plus:")} {options.TextCreateNew}[/]", "///new");
            }
            if (new DirectoryInfo(actualFolder)?.Parent != null)
            {
                choices.Add($"[green]{GetIcon(":upwards_button:")} {options.TextLevelUp}[/]", new DirectoryInfo(actualFolder).Parent.FullName);
            }
            foreach (var di in Directory.GetDirectories(Directory.GetCurrentDirectory()).Select(d => new DirectoryInfo(d)))
            {
                choices.Add($"{GetIcon(":file_folder:")} {di.Name}", di.FullName);
            }

            if (options.SelectFile)
            {
                foreach (string file in Directory.GetFiles(actualFolder, options.Filter))
                {
                    choices.Add($"{GetIcon(":abacus:")} {Path.GetFileName(file)}", file);
                }
            }

            return choices;
        }

        private string GetIcon(string iconName)
        {
            return options.DisplayIcons ? iconName : String.Empty;
        }

        private string SelectDrive()
        {
            var drives = Directory.GetLogicalDrives();
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (string drive in drives)
            {
                result.Add($"{GetIcon(":computer_disk:")} {drive}", drive);
            }
            AnsiConsole.Clear();
            AnsiConsole.WriteLine();
            var rule = new Rule($"[b][green]{options.TextSelectDrive}[/][/]").Centered();
            AnsiConsole.Write(rule);

            AnsiConsole.WriteLine();
            string title = options.TextSelectDrive;
            var selected = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[green]{title}:[/]")
                .PageSize(options.PageSize)
                .MoreChoicesText($"[grey]{options.TextMoreChoices}[/]")
                .AddChoices(result.Keys)
            );
            var record = result.Where(s => s.Key == selected).Select(s => s.Value).FirstOrDefault();
            return record;
        }

        public record Options
        {
            public string InitialDirectory { get; init; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            public string Filter { get; init; } = "*.*";
            public bool DisplayIcons { get; init; } = true;
            public bool SelectFile { get; init; } = true;
            public int PageSize { get; init; } = 15;
            public bool CanCreateFolder { get; init; } = true;
            public string TextLevelUp { get; init; } = "..";
            public string TextCurrentFolder { get; init; } = "Selected Folder";
            public string TextMoreChoices { get; init; } = "Use arrows Up and Down to select";
            public string TextCreateNew { get; init; } = "Create new folder";
            public string TextSelectFile { get; init; } = "Select File";
            public string TextSelectFolder { get; init; } = "Select Folder";
            public string TextSelectDrive { get; init; } = "Select Drive";
            public string TextSelectCurrent { get; init; } = "Select current Folder";
        }
    }
}
