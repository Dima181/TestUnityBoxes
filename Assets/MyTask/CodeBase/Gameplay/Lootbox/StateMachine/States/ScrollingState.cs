using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace MyTask.CodeBase.Gameplay.Lootbox.StateMachine.States
{
    [State("Scrolling")]
    public class ScrollingState : FSMState
    {
        private LootboxMachineController _controller;

        public ScrollingState(LootboxMachineController controller)
        {
            _controller = controller;
        }

        [Enter]
        private async UniTask EnterThisAsync()
        {
            Model.Set("BtnStartEnable", false);
            Model.Set("BtnExitEnable", false);
            await _controller.StartScroll();
        }
    }
}
