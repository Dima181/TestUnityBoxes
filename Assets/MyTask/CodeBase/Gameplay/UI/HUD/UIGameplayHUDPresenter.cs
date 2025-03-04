using Cysharp.Threading.Tasks;
using MyTask.CodeBase.Gameplay.Cards.Model;
using MyTask.CodeBase.Gameplay.Cards.View;
using MyTask.CodeBase.Gameplay.Lootbox.Model;
using MyTask.CodeBase.Gameplay.Lootbox.UI;
using MyTask.CodeBase.UI;
using MyTask.CodeBase.UI.Core;
using UniRx;
using UnityEngine;
using Zenject;

namespace MyTask.CodeBase.Gameplay.UI.HUD
{
    public class UIGameplayHUDPresenter : UIScreenPresenter<UIGameplayHUDView>
    {
        [Inject] private readonly UINavigator _uiNavigator;

        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.OnRareBoxClicked
                .Subscribe(_ => OpenLootbox(EBoxRarity.Rare)).AddTo(disposables);

            _view.OnEpicBoxClicked
                .Subscribe(_ => OpenLootbox(EBoxRarity.Epic)).AddTo(disposables);

            _view.OnLegendaryBoxClicked
                .Subscribe(_ => OpenLootbox(EBoxRarity.Legendary)).AddTo(disposables);

            return UniTask.CompletedTask;
        }

        private async void OpenLootbox(EBoxRarity boxRarity)
        {
            _view.OpenBox.OnNext(Unit.Default);
            
            await UniTask.Delay(1000);

            _uiNavigator.Perform<UILootboxScrollPopupPresenter>(p =>
            {
                p.SetRarity(boxRarity);
                p.ShowAndForget();
            });
        }
    }
}
