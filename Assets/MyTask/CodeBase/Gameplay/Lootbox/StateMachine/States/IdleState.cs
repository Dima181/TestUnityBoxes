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
            Model.Set("BtnStartEnable", true);
            Model.Set("BtnExitEnable", true);
            Model.Set("BtnStopEnable", false);
        }
    }
}
