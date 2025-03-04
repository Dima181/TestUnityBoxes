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
            _controller.StartButton.interactable = false;
            _controller.ExitButton.interactable = false;
            await _controller.StartScroll();
        }
    }
}
