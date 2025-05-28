using System.Text.Json.Serialization;

namespace ToWork.Models;

class WorkTask
{
    [JsonConstructor]
    public WorkTask(string Label, bool Completed, DateTime CreationDate, List<WorkTask>? SubTasks = null)
    {
        this.Label = Label;
        this.Completed = Completed;
        this.CreationDate = CreationDate;
        this.SubTasks = SubTasks;
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
