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
        Argument<int> taskIdArgument = new("taskId", "The number of the task to complete");
        AddArgument(taskIdArgument);
        this.SetHandler(Execute, taskIdArgument);
    }

    public virtual void Execute(int taskId)
    {
        bool succeeded = tasksContainer.CompleteTask(taskId);
        if (succeeded)
        {
            Console.WriteLine($"{tasksContainer.WorkTasks[taskId].Label} completed.");
            tasksContainer.Save();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This task do not exists in the list.");
        }
    }
}
