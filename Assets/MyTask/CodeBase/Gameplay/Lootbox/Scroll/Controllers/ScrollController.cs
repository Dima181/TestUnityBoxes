using Cysharp.Threading.Tasks;
using DG.Tweening;
using MyTask.CodeBase.Gameplay.Lootbox.Scroll.View;
using UniRx;
using UnityEngine;

namespace MyTask.CodeBase.Gameplay.Lootbox.Scroll.Controllers
{
    public class ScrollController : MonoBehaviour
    {
        [SerializeField] private UIScrollView _scrollView;

        private float _currentScrollSpeed = 0f;
        private bool _isScrolling = false;
        private bool _isStopping = false;
        private float _symbolHeight;
        private float _topThreshold;
        private float _bottomThreshold;

        private void Start()
        {
            if (_scrollView.ItemList.Count == 0) return;

            _symbolHeight = _scrollView.ItemList[0].rect.height + _scrollView.Spacing;
            _topThreshold = _scrollView.Viewport.rect.yMax + _symbolHeight;
            _bottomThreshold = _scrollView.Viewport.rect.yMin - _symbolHeight;
        }

        private void Update()
        {
            if (_isScrolling)
            {
                ScrollDown();
                RecycleSymbols();
            }
        }

        private void ScrollDown()
        {
            foreach (var symbol in _scrollView.ItemList)
            {
                symbol.localPosition -= new Vector3(0, _currentScrollSpeed * Time.deltaTime, 0);
            }
        }

        private void RecycleSymbols()
        {
            foreach (var symbol in _scrollView.ItemList)
            {
                if (symbol.localPosition.y < _bottomThreshold)
                {
                    var maxY = GetMaxY();
                    symbol.localPosition = new Vector3(symbol.localPosition.x, maxY + _symbolHeight, symbol.localPosition.z);
                }
            }
        }

        private float GetMaxY()
        {
            float maxY = float.MinValue;
            foreach (var symbol in _scrollView.ItemList)
            {
                if (symbol.localPosition.y > maxY)
                    maxY = symbol.localPosition.y;
            }
            return maxY;
        }

        public async UniTask StartScroll()
        {
            if (_isScrolling) return;

            _isScrolling = true;
            _isStopping = false;
            _currentScrollSpeed = 0;

            float elapsedTime = 0;
            while (elapsedTime < _scrollView.AccelerationTime)
            {
                elapsedTime += Time.deltaTime;
                _currentScrollSpeed = Mathf.Lerp(0, _scrollView.MaxScrollSpeed, elapsedTime / _scrollView.AccelerationTime);
                await UniTask.Yield();
            }

            _currentScrollSpeed = _scrollView.MaxScrollSpeed;
        }

        public async UniTask StopScroll()
        {
            if (!_isScrolling || _isStopping) return;

            _isStopping = true;
            float elapsedTime = 0;
            float initialSpeed = _currentScrollSpeed;

            while (elapsedTime < _scrollView.DecelerationTime)
            {
                elapsedTime += Time.deltaTime;
                _currentScrollSpeed = Mathf.Lerp(initialSpeed, 0, elapsedTime / _scrollView.DecelerationTime);
                await UniTask.Yield();
            }

            _currentScrollSpeed = 0;
            _isScrolling = false;
            await AlignToCenter();
        }

        private async UniTask AlignToCenter()
        {
            var closestSymbol = GetClosestToCenter();
            if (closestSymbol == null) return;

            float targetOffset = closestSymbol.localPosition.y + (_symbolHeight / 2);
            float targetPosition = 0f;
            float delta = targetPosition - targetOffset;

            float slowSpeed = _scrollView.MaxScrollSpeed * 0.1f * Mathf.Sign(delta);
            float duration = 0.5f;
            float elapsedTime = 0;
            float initialSpeed = _currentScrollSpeed;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                _currentScrollSpeed = Mathf.Lerp(initialSpeed, slowSpeed, elapsedTime / duration);
                await UniTask.Yield();
            }

            _currentScrollSpeed = slowSpeed;

            foreach (var symbol in _scrollView.ItemList)
            {
                symbol.DOLocalMoveY(symbol.localPosition.y + delta, 0.3f)
                    .SetEase(Ease.OutQuad)
                    .OnComplete(() => _isScrolling = false);
            }
        }

        private RectTransform GetClosestToCenter()
        {
            RectTransform closest = null;
            float minDistance = float.MaxValue;
            float viewportCenter = 0f;

            foreach (var symbol in _scrollView.ItemList)
            {
                float symbolCenterY = symbol.localPosition.y + (_symbolHeight / 2);
                float distance = Mathf.Abs(symbolCenterY - viewportCenter);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = symbol;
                }
            }

            return closest;
        }
    }
}
