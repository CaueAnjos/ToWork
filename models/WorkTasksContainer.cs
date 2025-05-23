using ToWork.Utils;

namespace ToWork.Models;

class WorkTasksContainer
{
    public List<WorkTask> WorkTasks { get; set; } = new List<WorkTask> { };

    public void Save()
    {
        using FileStream fs = new("workTasks.json", FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        bw.Write(WorkTasks);
    }

    public void Load()
    {
        using FileStream fs = new("workTasks.json", FileMode.Open, FileAccess.Read);
        using BinaryReader br = new(fs);
        WorkTasks = br.ReadWorkTasks().ToList();
    }
}
