using MyTask.CodeBase.UI.Core;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MyTask.CodeBase.Gameplay.UI.HUD
{
    public class UIGameplayHUDView : UIScreenView
    {
        public IObservable<Unit> OnRareBoxClicked => _rareBox.OnClickAsObservable(); 
        public IObservable<Unit> OnEpicBoxClicked => _epicBox.OnClickAsObservable();
        public IObservable<Unit> OnLegendaryBoxClicked => _legendaryBox.OnClickAsObservable();
        public Subject<Unit> OpenBox => _openBox;


        private Subject<Unit> _openBox = new();
        [SerializeField] private Button _rareBox;
        [SerializeField] private Button _epicBox;
        [SerializeField] private Button _legendaryBox;

    }
}
