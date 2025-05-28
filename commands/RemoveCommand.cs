using System.CommandLine;
using ToWork.Models;

namespace ToWork.Commands;

internal class RemoveCommand : Command
{
    protected WorkTasksContainer tasksContainer;

    public RemoveCommand(WorkTasksContainer workTasksContainer)
        : base("remove", "Remove a task from the list")
    {
        tasksContainer = workTasksContainer;
        Argument<string> taskLabelArgument = new("taskLabel", "description of the task to add");
        AddArgument(taskLabelArgument);
        this.SetHandler(Execute, taskLabelArgument);
    }

    public virtual void Execute(string taskLabel)
    {
        bool succeeded = tasksContainer.RemoveTask(taskLabel);
        if (succeeded)
        {
            tasksContainer.Save();
            Console.WriteLine($"Removed task {taskLabel}.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This task do not exists in the list.");
        }
    }
}
