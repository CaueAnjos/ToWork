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
        Argument<int> taskIdArgument = new("taskId", "The number of the task to remove");
        AddArgument(taskIdArgument);
        this.SetHandler(Execute, taskIdArgument);
    }

    public virtual void Execute(int taskId)
    {
        bool succeeded = tasksContainer.RemoveTask(taskId);
        if (succeeded)
        {
            tasksContainer.Save();
            Console.WriteLine($"Removed task {taskId}.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This task do not exists in the list.");
        }
    }
}
