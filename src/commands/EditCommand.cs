using System.CommandLine;
using ToWork.Models;

namespace ToWork.Commands;

internal class EditCommand : Command
{
    protected WorkTasksContainer tasksContainer;

    public EditCommand(WorkTasksContainer workTasksContainer)
        : base("edit", "Edit a task in the list")
    {
        tasksContainer = workTasksContainer;
        Argument<int> taskId = new("taskId", "The number of the task");

        Option<string?> lableOption = new(["--lable", "-l"], "The new lable of the task");
        Option<DateTime?> dateOption = new(["--date", "-d"], "The new date of the task");
        Option<bool?> completedOption = new(["--completed", "-c"], "The new completed status of the task");

        AddArgument(taskId);
        AddOption(lableOption);
        AddOption(dateOption);
        AddOption(completedOption);

        this.SetHandler(Execute, taskId, lableOption, dateOption, completedOption);
    }

    public virtual void Execute(int taskId, string? lableOption, DateTime? dateOption, bool? completedOption)
    {
        bool succeeded = tasksContainer.EditTask(taskId, lableOption, dateOption, completedOption);
        if (succeeded)
        {
            Console.WriteLine($"{tasksContainer.WorkTasks[taskId].Label} edited.");
            tasksContainer.Save();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This task do not exists in the list.");
        }
    }
}
