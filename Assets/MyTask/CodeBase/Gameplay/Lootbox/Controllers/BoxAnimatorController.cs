using MyTask.CodeBase.Gameplay.UI.HUD;
using UnityEngine;
using UniRx;
using Zenject;
using MyTask.CodeBase.Gameplay.Lootbox.Scroll.View;

namespace MyTask.CodeBase.Gameplay.Lootbox.Controllers
{
    public class BoxAnimatorController : MonoBehaviour
    {
        [Inject] private UIGameplayHUDView _uiGameplayHUDView;
        [Inject] private UIScrollView _uiScrollView;

        [SerializeField] private Animator _animator;

        private void Start()
        {
            _uiGameplayHUDView.OpenBox
                .Subscribe(_ =>
                {
                    _animator.SetTrigger("Open");
                })
                .AddTo(this);

            _uiScrollView.CloseBox
                .Subscribe(_ =>
                {
                    _animator.SetTrigger("Idle");
                })
                .AddTo(this);
        }
    }
}
