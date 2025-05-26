using Command.Commands.AbstractCommands;
using Command.Main;
using Command.Actions;

namespace Command.Commands
{
    public class BerserkAttackCommand : UnitCommand
    {
        private bool willHitTarget;

        public BerserkAttackCommand(CommandData commandData)
        {
            CommandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive())
                {
                    targetUnit.Revive();
                }

                targetUnit.RestoreHealth(actorUnit.CurrentPower * 2);
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget() => true;
    }
}



