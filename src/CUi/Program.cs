using Spectre.Console;

var font = FigletFont.Load("starwars.flf");
AnsiConsole.Write(
    new FigletText(font,"CUi")
        .LeftAligned()
        .Color(Color.DodgerBlue3));



//if (AnsiConsole.Confirm("Run prompt example?"))
//{
//    var name = AnsiConsole.Ask<string>("What's your [green]name[/]?");


//    AnsiConsole.Prompt(
//    new TextPrompt<int>("How [green]old[/] are you?")
//        .PromptStyle("green")
//        .ValidationErrorMessage("[red]That's not a valid age[/]")
//        .Validate(age =>
//        {
//            return age switch
//            {
//                <= 0 => ValidationResult.Error("[red]You must at least be 1 years old[/]"),
//                >= 123 => ValidationResult.Error("[red]You must be younger than the oldest person alive[/]"),
//                _ => ValidationResult.Success(),
//            };
//        }));



//    var favorites = AnsiConsole.Prompt(
//    new MultiSelectionPrompt<string>()
//        .PageSize(10)
//        .Title("What are your [green]favorite fruits[/]?")
//        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
//        .InstructionsText("[grey](Press [blue][/] to toggle a fruit, [green][/] to accept)[/]")
//        .AddChoiceGroup("Berries", new[]
//        {
//            "Blackcurrant", "Blueberry", "Cloudberry",
//            "Elderberry", "Honeyberry", "Mulberry"
//        })
//        .AddChoices(new[]
//        {
//            "Apple", "Apricot", "Avocado", "Banana",
//            "Cherry", "Cocunut", "Date", "Dragonfruit", "Durian",
//            "Egg plant",  "Fig", "Grape", "Guava",
//            "Jackfruit", "Jambul", "Kiwano", "Kiwifruit", "Lime", "Lylo",
//            "Lychee", "Melon", "Nectarine", "Orange", "Olive"
//        }));

//    var fruit = favorites.Count == 1 ? favorites[0] : null;
//    if (string.IsNullOrWhiteSpace(fruit))
//    {
//        fruit = AnsiConsole.Prompt(
//            new SelectionPrompt<string>()
//                .Title("Ok, but if you could only choose [green]one[/]?")
//                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
//                .AddChoices(favorites));
//    }


//    AnsiConsole.Status()
//    .Spinner(Spinner.Known.Star)
//    .Start("Thinking...", ctx => {
//        Thread.Sleep(2000);
//    });

//    AnsiConsole.MarkupLine("Your selected: [yellow]{0}[/]", fruit);

//}
