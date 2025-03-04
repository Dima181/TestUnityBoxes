using Infrastructure.Scenes;
using MyTask.CodeBase.Gameplay.Cards.Installers;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Install<ScenesFlowInstaller>();
            Install<CardsConfigInstaller>();
        }

        private void Install<T>() where T : Installer<T>
        {
            Installer<T>.Install(Container);
            Debug.Log($"[PROJECT INSTALLER] Install: <b>{typeof(T).Name}</b>");
        }
    }
}