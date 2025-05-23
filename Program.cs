using ToWork.Models;

Console.WriteLine("This is a todo app");

WorkTask task = new("Fazer as tarefas", false, DateTime.Now, null);

WorkTasksContainer container = new();
container.WorkTasks.Add(task);

container.Save();
