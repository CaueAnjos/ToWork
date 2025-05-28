using System.CommandLine;
using ToWork.Models;

namespace ToWork.Commands;

internal class CompleteCommand : Command
{
    protected WorkTasksContainer tasksContainer;

    public CompleteCommand(WorkTasksContainer workTasksContainer)
        : base("complete", "Mark a task as completed")
    {
        tasksContainer = workTasksContainer;
        Argument<string> taskLabelArgument = new("taskLabel", "description of the task to add");
        this.SetHandler(Execute, taskLabelArgument);
    }

    public virtual void Execute(string taskLabel)
    {
        bool succeeded = tasksContainer.CompleteTask(taskLabel);
        if (succeeded)
        {
            Console.WriteLine($"{taskLabel} completed.");
            tasksContainer.Save();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This task do not exists in the list.");
        }
    }
}
