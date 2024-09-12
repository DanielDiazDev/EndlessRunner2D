using System.Threading.Tasks;

public static class TaskExtensions
{
    public static async void WrapErrors(this Task task)
    {
        await task;
    }
}