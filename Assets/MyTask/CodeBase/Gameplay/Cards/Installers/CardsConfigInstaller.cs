using Infrastructure.Scenes;
using Infrastructure.Transitions;
using MyTask.CodeBase.Gameplay.Cards.Configs;
using MyTask.CodeBase.Gameplay.Cards.View;
using Zenject;

namespace MyTask.CodeBase.Gameplay.Cards.Installers
{
    public class CardsConfigInstaller : Installer<CardsConfigInstaller>
    {
        private const string CARDS_CONFIG_PATH = "Scriptable Objects/Gameplay/Cards/CardsConfig";
        private const string BOX_RARITY_CONFIG_PATH = "Scriptable Objects/Gameplay/Cards/BoxRarityConfig";

        public override void InstallBindings()
        {
            Container.Bind<CardConfig>()
                .FromScriptableObjectResource(CARDS_CONFIG_PATH)
                .AsSingle();
            
            Container.Bind<BoxRarityConfig>()
                .FromScriptableObjectResource(BOX_RARITY_CONFIG_PATH)
                .AsSingle();

            Container.Bind<CardSpawn>()
                .AsSingle();
        }
    }
}
