using ToWork.Utils;

namespace ToWork.Models;

class WorkTasksContainer
{
    public List<WorkTask> WorkTasks { get; set; } = new List<WorkTask> { };

    public void Save()
    {
        using FileStream fs = new FileStream("workTasks.json", FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new BinaryWriter(fs);
        bw.Write(WorkTasks);
    }
}
