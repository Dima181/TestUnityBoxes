using UnityEngine;
using Zenject;

namespace MyTask.CodeBase.Gameplay.Lootbox.Installers
{
    public class BoxInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MonoInstaller[] installers = gameObject.GetComponents<MonoInstaller>();

            foreach (var installer in installers)
            {
                if (installer == this || installer == null)
                    continue;

                Debug.Log(installer.ToString());
                Container.Inject(installer);
                installer.InstallBindings();
            }
        }
    }
}
