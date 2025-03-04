using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using Cysharp.Threading.Tasks;
using MyTask.CodeBase.Gameplay.Lootbox.Scroll.Controllers;
using MyTask.CodeBase.Gameplay.Lootbox.StateMachine.States;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyTask.CodeBase.Gameplay.Lootbox.StateMachine
{
    public class LootboxMachineController : MonoBehaviourExtBind
    {
        public Button StartButton => _startButton;
        public Button StopButton => _stopButton;
        public Button ExitButton => _exitButton;


        [SerializeField] private Button _startButton;
        [SerializeField] private Button _stopButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private ScrollController _scrollController;

        [OnStart]
        private void StartThis()
        {
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new IdleState(this));
            Settings.Fsm.Add(new ScrollingState(this));
            Settings.Fsm.Add(new StoppingState(this));

            Settings.Fsm.Start("IdleState");

            StartButton.onClick.AddListener(() =>
            {
                Settings.Fsm.Change("Scrolling");
            });

            StopButton.onClick.AddListener(() =>
            {
                Settings.Fsm.Change("Stopping");
            });

            StopButton.interactable = false;
        }

        public async UniTask StartScroll()
        {
            StopButton.interactable = false;
            await _scrollController.StartScroll();
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            StopButton.interactable = true;
        }

        public async UniTask StopScroll()
        {
            StopButton.interactable = false;
            await _scrollController.StopScroll();
            StartButton.interactable = true;
        }

    }
}
