using System.Text.Json.Serialization;

namespace ToWork.Models;

class WorkTask
{
    [JsonConstructor]
    public WorkTask(string label, bool completed, DateTime creationDate, List<WorkTask>? subTasks = null)
    {
        this.Label = label;
        this.Completed = completed;
        this.CreationDate = creationDate;
        this.SubTasks = subTasks;
    }

    public WorkTask(string label)
    {
        Label = label;
        Completed = false;
        CreationDate = DateTime.Now;
        SubTasks = null;
    }

    public string Label { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }
    public List<WorkTask>? SubTasks { get; set; }

    public override string ToString()
    {
        char completed = Completed ? 'x' : ' ';

        return $"[{CreationDate}] ({completed}) {Label}";
    }
}
