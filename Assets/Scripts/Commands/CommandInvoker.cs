using Command.Commands.AbstractCommands;
using System.Collections;
using System.Collections.Generic;
using Command.Main;
using UnityEngine;

namespace Command.Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public CommandInvoker() => SubscribeToEvents();

        private void SubscribeToEvents() => GameService.Instance.EventService.OnReplayButtonClicked.AddListener(SetReplayStack);

        private void SetReplayStack()
        {
            GameService.Instance.ReplayService.SetCommandStack(commandRegistry);
            commandRegistry.Clear();
        }

        private bool RegistryEmpty() => commandRegistry.Count == 0;

        private bool CommandBelongsToActivePlayer()
        {
            return (commandRegistry.Peek() as UnitCommand).CommandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
        }

        public void Undo()
        {
            if (!RegistryEmpty() && CommandBelongsToActivePlayer())
            {
                commandRegistry.Pop().Undo();
            }
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);
    }
}

