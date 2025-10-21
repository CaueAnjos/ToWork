using System.CommandLine;
using ToWork.Models;

namespace ToWork.Commands;

internal class ListCommand : Command
{
    protected WorkTasksContainer tasksContainer;

    public ListCommand(WorkTasksContainer workTasksContainer)
        : base("list", "List all tasks in the list")
    {
        tasksContainer = workTasksContainer;
        this.SetHandler(Execute);
    }

    public virtual void Execute()
    {
        Console.WriteLine("Tasks:");
        var tasks = tasksContainer.WorkTasks.OrderBy(t => t.CreationDate).ToList();
        for (int i = 0; i < tasks.Count; i++)
            Console.WriteLine($"<{i}> {tasks[i]}");
    }
}
