using Command.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Commands.AbstractCommands
{
    public abstract class UnitCommand : ICommand
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;

        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute();

        public abstract bool WillHitTarget();

    }
}


