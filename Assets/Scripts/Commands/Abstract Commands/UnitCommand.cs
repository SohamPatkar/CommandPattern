using Command.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands.AbstractCommands
{
    public abstract class UnitCommand : ICommand
    {
        public CommandData CommandData;

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute();
        public abstract void Undo();

        public abstract bool WillHitTarget();

        public void SetActorUnitID(UnitController actorUnit) => this.actorUnit = actorUnit;

        public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;
    }
}


