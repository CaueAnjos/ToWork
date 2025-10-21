using System.CommandLine;
using ToWork.Models;

namespace ToWork.Commands;

internal class AddCommand : Command
{
    protected WorkTasksContainer tasksContainer;

    public AddCommand(WorkTasksContainer workTasksContainer)
        : base("add", "Add a task to the list")
    {
        tasksContainer = workTasksContainer;

        Argument<string> taskLabelArgument = new("taskLabel", "description of the task to add");
        AddArgument(taskLabelArgument);
        this.SetHandler(Execute, taskLabelArgument);
    }

    public virtual void Execute(string taskLabel)
    {
        WorkTask task = tasksContainer.AddTask(taskLabel);
        Console.WriteLine($"Added task {task}");
        tasksContainer.Save();
    }
}
