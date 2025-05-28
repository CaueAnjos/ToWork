using System.Text.Json;

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
        FilePath = Path.Combine(directory, "workTasks.json");
    }

    public WorkTask AddTask(string taskLable)
    {
        WorkTask task = new(taskLable);
        WorkTasks.Add(task);
        return task;
    }

    public bool RemoveTask(int taskId)
    {
        if (taskId >= WorkTasks.Count || taskId < 0)
            return false;

        WorkTasks.RemoveAt(taskId);
        return true;
    }

    public bool CompleteTask(int taskId)
    {
        if (taskId >= WorkTasks.Count || taskId < 0)
            return false;

        WorkTask taskToComplete = WorkTasks[taskId];

        taskToComplete.Completed = true;
        return true;
    }

    public bool EditTask(int taskId, string? lableOption, DateTime? dateOption, bool? completedOption)
    {
        if (taskId >= WorkTasks.Count || taskId < 0)
            return false;

        WorkTask taskToEdit = WorkTasks[taskId];
        if (lableOption is not null)
            taskToEdit.Label = lableOption;

        if (dateOption is not null)
            taskToEdit.CreationDate = dateOption.Value;

        if (completedOption is not null)
            taskToEdit.Completed = completedOption.Value;

        return true;
    }

    public void Save()
    {
        string json = JsonSerializer.Serialize(WorkTasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public void Load()
    {
        if (!File.Exists(FilePath))
            return;

        var list = JsonSerializer.Deserialize<List<WorkTask>>(File.ReadAllText(FilePath));
        if (list is not null)
        {
            WorkTasks = list;
        }
    }
}
