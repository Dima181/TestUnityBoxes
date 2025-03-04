using Cysharp.Threading.Tasks;
using MyTask.CodeBase.Gameplay.Cards.Model;
using MyTask.CodeBase.Gameplay.Cards.View;
using MyTask.CodeBase.Gameplay.Lootbox.Model;
using MyTask.CodeBase.Gameplay.Lootbox.Scroll.View;
using MyTask.CodeBase.UI.Core;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace MyTask.CodeBase.Gameplay.Lootbox.UI
{
    public class UILootboxScrollPopupPresenter : UIScreenPresenter<UIScrollView>
    {
        [Inject] private CardSpawn _cardSpawn;

        private EBoxRarity _boxRarity;

        public void SetRarity(EBoxRarity rarity)
        {
            _boxRarity = rarity;
        }

        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            ClearPreviousCards();

            for (int i = 0; i < 5; i++)
            {
                var cardPrefab = _cardSpawn.GetRandomCard(_boxRarity);

                var cardInstance = UnityEngine.Object.Instantiate(cardPrefab, _view.RequiresContainer);

                _view.ItemList.Add(cardInstance.GetComponent<RectTransform>());
            }

            _view.OnExitButtonClicked
                .Subscribe(_ =>
                {
                    Hide().Forget();
                    _view.CloseBox.OnNext(Unit.Default);
                })
                .AddTo(disposables);

            return UniTask.CompletedTask;
        }

        private void ClearPreviousCards()
        {
            foreach (var item in _view.ItemList)
            {
                UnityEngine.Object.Destroy(item.gameObject);
            }
            _view.ItemList.Clear();
        }
    }
}
