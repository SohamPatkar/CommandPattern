using Command.Commands.AbstractCommands;
using Command.Main;
using System.Collections.Generic;

namespace Command.Replay
{
    public class ReplayService
    {
        private Stack<ICommand> replayCommandStack;

        public ReplayState ReplayState { get; private set; }

        public ReplayService() => SetReplayState(ReplayState.DEACTIVE);
        public void SetReplayState(ReplayState stateToSet) => ReplayState = stateToSet;
        public void SetCommandStack(Stack<ICommand> commandsToSet) => replayCommandStack = new Stack<ICommand>(commandsToSet);

        public void ExecuteNext()
        {
            if (replayCommandStack.Count > 0)
            {
                GameService.Instance.ProcessUnitCommand(replayCommandStack.Pop());
            }
        }
    }

    public enum ReplayState
    {
        DEACTIVE,
        ACTIVE
    }
}