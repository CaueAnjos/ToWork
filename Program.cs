using ToWork.Models;
using System.CommandLine;
using ToWork.Commands;

namespace ToWork;

class Program
{
    static async Task<int> Main(string[] args)
    {
        WorkTasksContainer workTasksContainer = new();
        try
        {
            workTasksContainer.Load();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            workTasksContainer.WorkTasks.Clear();
        }

        RootCommand rootCommand = new("A simple todo list project");

        rootCommand.AddCommand(new AddCommand(workTasksContainer));
        rootCommand.AddCommand(new RemoveCommand(workTasksContainer));
        rootCommand.AddCommand(new ListCommand(workTasksContainer));
        rootCommand.AddCommand(new ClearCommand(workTasksContainer));
        rootCommand.AddCommand(new EditCommand(workTasksContainer));
        rootCommand.AddCommand(new CompleteCommand(workTasksContainer));

        return await rootCommand.InvokeAsync(args);
    }
}
