using Command.Actions;
using Command.Commands.AbstractCommands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Command.Commands
{
    public class AttackCommand : UnitCommand
    {
        private bool willHitTarget;

        public AttackCommand(CommandData commandData)
        {
            CommandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            GameService.Instance.ActionService.GetActionByType(CommandType.Attack).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override bool WillHitTarget() => true;

    }
}


