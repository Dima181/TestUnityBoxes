using AxGrid;
using AxGrid.FSM;
using UnityEngine;

namespace MyTask.CodeBase.Gameplay.Lootbox.StateMachine.States
{
    [State("IdleState")]
    public class IdleState : FSMState
    {
        private LootboxMachineController _controller;

        public IdleState(LootboxMachineController controller)
        {
            _controller = controller;
        }

        [Enter]
        public void Enter()
        {
            _controller.StartButton.interactable = true;
            _controller.ExitButton.interactable = true;
            _controller.StopButton.interactable = false;
        }
    }
}
