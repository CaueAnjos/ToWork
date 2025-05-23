namespace ToWork.Models;

class WorkTask
{
    public WorkTask(string label, bool completed, DateTime date, IEnumerable<WorkTask>? subTasks = null)
    {
        Label = label;
        Completed = completed;
        CreationDate = date;
        SubTasks = subTasks?.ToList() ?? null;
    }

    public string Label { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }
    public List<WorkTask>? SubTasks { get; set; }
}
