using MyTask.CodeBase.Gameplay.Lootbox.UI;
using MyTask.CodeBase.Gameplay.UI.HUD;
using MyTask.CodeBase.UI;

namespace MyTask.CodeBase.Gameplay.UI
{
    public class GameplayUIInstaller : UIInstaller<UIGameplayHUDView, UIGameplayHUDPresenter>
    {
        protected override string HudPrefabPath => "UI/HUD/Gameplay Hud";

        protected override void InstallBindingsInternal()
        {
            LootboxScrollUIInstaller.Install(Container);
        }
    }
}
