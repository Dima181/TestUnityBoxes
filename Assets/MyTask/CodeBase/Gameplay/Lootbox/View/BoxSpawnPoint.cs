using MyTask.CodeBase.Gameplay.Lootbox.Installers;
using UnityEngine;
using Zenject;

namespace MyTask.CodeBase.Gameplay.Lootbox.View
{
    public class BoxSpawnPoint : MonoBehaviour
    {
        [SerializeField] private BoxInstaller _prefab;
        [Inject] private DiContainer _di;

        private void OnEnable()
        {
            var subContainer = _di.CreateSubContainer();

            var installer = subContainer.InstantiatePrefabForComponent<BoxInstaller>(
                _prefab,
                transform.position,
                transform.rotation,
                transform.parent);

            subContainer.Inject(installer);
            installer.InstallBindings();

            Destroy(gameObject);
        }
    }
}
