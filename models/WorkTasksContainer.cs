using ToWork.Utils;

namespace ToWork.Models;

class WorkTasksContainer
{
    public List<WorkTask> WorkTasks { get; set; }
    public string FilePath { get; private set; }

    public WorkTasksContainer()
    {
        WorkTasks = new List<WorkTask>();

        // path
        string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ToWork");
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        FilePath = Path.Combine(directory, "workTasks.bin");
    }

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
        using FileStream fs = new(FilePath, FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        bw.Write(WorkTasks);
    }

    public void Load()
    {
        if (!File.Exists(FilePath))
            return;

        using FileStream fs = new(FilePath, FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        WorkTasks = br.ReadWorkTasks().ToList();
    }
}
