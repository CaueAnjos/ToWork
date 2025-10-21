using System.CommandLine;
using ToWork.Models;

namespace ToWork.Commands;

internal class ClearCommand : Command
{
    protected WorkTasksContainer tasksContainer;

    public ClearCommand(WorkTasksContainer workTasksContainer)
        : base("clear", "Clear all tasks in the list.")
    {
        tasksContainer = workTasksContainer;
        this.SetHandler(Execute);
    }

    public virtual void Execute()
    {
        tasksContainer.WorkTasks.Clear();
        tasksContainer.Save();
    }
}
