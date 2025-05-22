namespace ToWork.Models;

class WorkTask
{
    public WorkTask(string lable, bool completed = false, List<WorkTask>? subTasks = null)
    {
        Lable = lable;
        Completed = completed;
        SubTasks = subTasks;

        CreationDate = DateTime.Now;
    }

    public string Lable { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }
    public List<WorkTask>? SubTasks { get; set; }
}
