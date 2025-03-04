using MyTask.CodeBase.Extensions;
using MyTask.CodeBase.Gameplay.Lootbox.Controllers;
using UnityEngine;
using Zenject;

namespace MyTask.CodeBase.Gameplay.Lootbox.Installers
{
    public class BoxAnimatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BoxAnimatorController>()
                .FromRootComponent(this)
                .AsSingle();
        }
    }
}
