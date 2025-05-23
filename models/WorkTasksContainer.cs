using ToWork.Utils;

namespace ToWork.Models;

class WorkTasksContainer
{
    public List<WorkTask> WorkTasks { get; set; } = new List<WorkTask> { };
    private string path = "workTasks.bin";

    public WorkTask AddTask(string taskLable)
    {
        WorkTask task = new(taskLable);
        WorkTasks.Add(task);
        return task;
    }

    public bool RemoveTask(string taskLable)
    {
        WorkTask? taskToRemove = WorkTasks.FirstOrDefault(t => t.Label == taskLable);
        if (taskToRemove is null)
            return false;

        WorkTasks.Remove(taskToRemove);
        return true;
    }

    public bool CompleteTask(string taskLable)
    {
        WorkTask? taskToComplete = WorkTasks.FirstOrDefault(t => t.Label == taskLable);
        if (taskToComplete is null)
            return false;

        taskToComplete.Completed = true;
        return true;
    }

    public void Save()
    {
        using FileStream fs = new(path, FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        bw.Write(WorkTasks);
    }

    public void Load()
    {
        using FileStream fs = new(path, FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        WorkTasks = br.ReadWorkTasks().ToList();
    }
}
