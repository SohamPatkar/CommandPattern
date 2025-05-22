using Command.Commands.AbstractCommands;
using Command.Main;
using Command.Actions;

namespace Command.Commands
{
    public class CleanseCommand : UnitCommand
    {
        private bool willHitTarget;

        public CleanseCommand(CommandData commandData)
        {
            CommandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget() => true;
    }
}



