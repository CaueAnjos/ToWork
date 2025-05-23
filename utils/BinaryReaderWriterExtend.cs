using ToWork.Models;

namespace ToWork.Utils;

internal static class BinaryReaderWriterExtend
{
    public static void Write(this BinaryWriter writer, IEnumerable<WorkTask>? tasks)
    {
        if (tasks is not null)
        {
            writer.Write(tasks.Count());
            foreach (WorkTask task in tasks)
                writer.Write(task);
        }
        else
        {
            writer.Write(0);
        }
    }

    public static IEnumerable<WorkTask> ReadWorkTasks(this BinaryReader reader)
    {
        int count = reader.ReadInt32();
        if (count == 0)
            yield break;

        for (int i = 0; i < count; i++)
            yield return reader.ReadWorkTasks();
    }

    public static void Write(this BinaryWriter writer, DateTime date)
    {
        writer.Write(date.Year);
        writer.Write(date.Month);
        writer.Write(date.Day);
        writer.Write(date.Hour);
        writer.Write(date.Minute);
        writer.Write(date.Second);
        writer.Write(date.Millisecond);
    }

    public static DateTime ReadDateTime(this BinaryReader reader)
    {
        return new DateTime(
                reader.ReadInt32(),
                reader.ReadInt32(),
                reader.ReadInt32(),
                reader.ReadInt32(),
                reader.ReadInt32(),
                reader.ReadInt32(),
                reader.ReadInt32()
                );
    }

    public static void Write(this BinaryWriter writer, WorkTask task)
    {
        writer.Write(task.Lable);
        writer.Write(task.Completed);
        writer.Write(task.CreationDate);
        writer.Write(task.SubTasks);
    }

    public static WorkTask ReadWorkTaks(this BinaryReader reader)
    {
        return new WorkTask(
                reader.ReadString(),
                reader.ReadBoolean(),
                reader.ReadDateTime(),
                reader.ReadWorkTasks()
                );
    }
}
