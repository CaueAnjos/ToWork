using ToWork.Utils;

namespace ToWork.Models;

class WorkTasksContainer
{
    public List<WorkTask> WorkTasks { get; set; } = new List<WorkTask> { };
    private string path = "workTasks.bin";

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
