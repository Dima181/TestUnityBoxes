using DG.Tweening;
using MyTask.CodeBase.UI.Core;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MyTask.CodeBase.Gameplay.Lootbox.Scroll.View
{
    public class UIScrollView : UIScreenView
    {
        public IObservable<Unit> OnExitButtonClicked => _exitButton.OnClickAsObservable();
        public RectTransform RequiresContainer => _requiresContainer;
        public List<RectTransform> ItemList { get => _itemList; set => _itemList = value; }

        public float MaxScrollSpeed => _maxScrollSpeed;
        public float AccelerationTime => _accelerationTime;
        public float DecelerationTime => _decelerationTime;
        public float StopThreshold => _stopThreshold;
        public RectTransform Viewport => _viewport;
        public float Spacing => _spacing;
        public Subject<Unit> CloseBox => _closeBox;


        private Subject<Unit> _closeBox = new();
        [SerializeField] private RectTransform _requiresContainer;
        [SerializeField] private List<RectTransform> _itemList;

        [Space]
        [SerializeField] private float _maxScrollSpeed;
        [SerializeField] private float _accelerationTime;
        [SerializeField] private float _decelerationTime;
        [SerializeField] private float _stopThreshold;

        [SerializeField] private RectTransform _viewport;
        [SerializeField] private float _spacing;

        [SerializeField] private Button _exitButton;
    }
}
