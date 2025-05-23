using ToWork.Models;
using System.CommandLine;

namespace ToWork;

class Program
{
    static async Task<int> Main(string[] args)
    {
        WorkTasksContainer workTasksContainer = new();
        workTasksContainer.Load();

        RootCommand rootCommand = new("A simple todo list project");

        Argument<string> taskLabelArgument = new("taskLabel", "description of the task to add");

        Command addTaskCommand = new("add", "Add a task to the list");
        addTaskCommand.AddArgument(taskLabelArgument);
        addTaskCommand.SetHandler((taskLabel) =>
                {
                    WorkTask task = workTasksContainer.AddTask(taskLabel);
                    Console.WriteLine($"Added task {task}");
                    workTasksContainer.Save();
                }
                , taskLabelArgument);

        Command removeTaskCommand = new("remove", "Remove a task from the list");
        removeTaskCommand.AddArgument(taskLabelArgument);
        removeTaskCommand.SetHandler((taskLabel) =>
                {
                    bool succeeded = workTasksContainer.RemoveTask(taskLabel);
                    if (succeeded)
                    {
                        workTasksContainer.Save();
                        Console.WriteLine($"Removed task {taskLabel}.");
                    }
                    else
                        Console.WriteLine("This task do not exists in the list.");
                }
                , taskLabelArgument);

        Command listTasksCommand = new("list", "List all tasks in the list");
        listTasksCommand.SetHandler(() =>
                {
                    Console.WriteLine("Tasks:");
                    foreach (WorkTask task in workTasksContainer.WorkTasks.OrderBy(t => t.CreationDate))
                    {
                        Console.WriteLine($"- {task}");
                    }
                });

        Command clearTasksCommand = new("clear", "Clear all tasks in the list.");
        clearTasksCommand.SetHandler(() =>
        {
            workTasksContainer.WorkTasks.Clear();
            workTasksContainer.Save();
        });

        Command completeTaskCommand = new("complete", "Mark a task as completed");
        completeTaskCommand.AddArgument(taskLabelArgument);
        completeTaskCommand.SetHandler((taskLabel) =>
        {
            bool succeeded = workTasksContainer.CompleteTask(taskLabel);
            if (succeeded)
            {
                Console.WriteLine($"{taskLabel} completed.");
                workTasksContainer.Save();
            }
            else
                Console.WriteLine("This task do not exists in the list.");
        },
        taskLabelArgument);

        rootCommand.AddCommand(addTaskCommand);
        rootCommand.AddCommand(removeTaskCommand);
        rootCommand.AddCommand(listTasksCommand);
        rootCommand.AddCommand(completeTaskCommand);
        rootCommand.AddCommand(clearTasksCommand);

        return await rootCommand.InvokeAsync(args);
    }
}
