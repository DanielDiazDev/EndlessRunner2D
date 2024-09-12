using System.Collections.Generic;
using System.Threading.Tasks;

public class CommandQueue
{
    private static CommandQueue _instance;
    public static CommandQueue Instance => _instance ??= new CommandQueue();

    private readonly Queue<ICommand> _commands;
    private bool _runningCommand;

    private CommandQueue()
    {
        _commands = new Queue<ICommand>();
        _runningCommand = false;
    }
    public void AddCommand(ICommand command)
    {
        _commands.Enqueue(command);
        RunNextCommand().WrapErrors();
    }

    private async Task RunNextCommand()
    {
        if(_runningCommand)
        {
            return;
        }
        while(_commands.Count > 0)
        {
            _runningCommand = true;
            var command = _commands.Dequeue();
            await command.Execute();
        }
        _runningCommand = false;
    }
}
