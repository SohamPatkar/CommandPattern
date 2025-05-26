namespace Command.Commands.AbstractCommands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}


