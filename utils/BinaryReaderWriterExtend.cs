using ToWork.Models;

namespace ToWork.Utils;

internal static class BinaryReaderWriterExtend
{
    public static void Write(this BinaryWriter writer, WorkTask task)
    {
        writer.Write(task.Lable);
        writer.Write(task.Completed);
        writer.Write(task.CreationDate);

        writer.Write(task.SubTasks?.Count ?? 0);

        if (task.SubTasks is not null)
        {
            foreach (WorkTask subTask in task.SubTasks)
                writer.Write(subTask);
        }
    }

    public static WorkTask Read(this BinaryReader reader)
    {

    }

    public static void Write(this BinaryWriter writer, IEnumerable<WorkTask> tasks)
    {
        foreach (WorkTask task in tasks)
            writer.Write(task);
    }

    public static void Write(this BinaryWriter writer, DateTime date)
    {
        writer.Write(date.Day);
        writer.Write(date.Month);
        writer.Write(date.Year);
        writer.Write(date.Hour);
        writer.Write(date.Minute);
        writer.Write(date.Second);
        writer.Write(date.Millisecond);
    }
}
