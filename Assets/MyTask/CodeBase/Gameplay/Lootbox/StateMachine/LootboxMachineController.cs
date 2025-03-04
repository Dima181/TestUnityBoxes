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

            Model.EventManager.AddAction("OnStartClick", () =>
            {
                Settings.Fsm.Change("Scrolling");
            });
            
            Model.EventManager.AddAction("OnStopClick", () =>
            {
                Settings.Fsm.Change("Stopping");
            });

            Model.Set("BtnStartEnable", true);
            Model.Set("BtnStopEnable", false);
        }

        public async UniTask StartScroll()
        {
            Model.Set("BtnStopEnable", false);
            await _scrollController.StartScroll();
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            Model.Set("BtnStopEnable", true);
        }

        public async UniTask StopScroll()
        {
            Model.Set("BtnStopEnable", false);
            await _scrollController.StopScroll();
            Model.Set("BtnStartEnable", true);
        }

    }
}
