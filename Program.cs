using ToWork.Models;
using System.CommandLine;
using System.CommandLine.Invocation;

var rootCommand = new RootCommand();

var toworkCommand = new Command("towork", "Perform work tasks");
var addCommand = new Command("add", "Add a new task");
addCommand.AddArgument(new Argument<string>("task", "Task description"));

addCommand.Handler = CommandHandler.Create<string>((task) =>
{
    Console.WriteLine($"Adding task: {task}");
});

toworkCommand.AddCommand(addCommand);
rootCommand.AddCommand(toworkCommand);

await rootCommand.InvokeAsync(args);
