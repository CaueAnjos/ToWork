namespace ToWork.Models;

class WorkTask
{
    public WorkTask(string lable, bool completed, DateTime date, IEnumerable<WorkTask>? subTasks = null)
    {
        Lable = lable;
        Completed = completed;
        CreationDate = date;
        SubTasks = subTasks?.ToList() ?? null;
    }

    public string Lable { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }
    public List<WorkTask>? SubTasks { get; set; }
}
