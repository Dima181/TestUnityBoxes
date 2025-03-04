using AxGrid;
using AxGrid.FSM;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace MyTask.CodeBase.Gameplay.Lootbox.StateMachine.States
{
    [State("Stopping")]
    public class StoppingState : FSMState
    {
        private LootboxMachineController _controller;

        public StoppingState(LootboxMachineController controller)
        {
            _controller = controller;
        }

        [Enter]
        private async UniTask EnterThisAsync()
        {
            _controller.StopButton.interactable = false;
            _controller.ExitButton.interactable = false;
            await _controller.StopScroll();
            Settings.Fsm.Change("IdleState");
        }
    }
}
