using Command.Commands.AbstractCommands;
using Command.Main;
using Command.Actions;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousHealth;

        public MeditateCommand(CommandData commandData)
        {
            CommandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Undo()
        {
            if (willHitTarget)
            {
                var healthToReduce = (int)(previousHealth * 0.2f);
                targetUnit.TakeDamage(healthToReduce);
            }

            actorUnit.Owner.ResetCurrentActiveUnit();
        }

        public override void Execute()
        {
            previousHealth = targetUnit.CurrentHealth;
            GameService.Instance.ActionService.GetActionByType(CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget() => true;
    }
}


