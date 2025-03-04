using AYellowpaper.SerializedCollections;
using MyTask.CodeBase.Gameplay.Cards.Model;
using MyTask.CodeBase.Gameplay.Lootbox.Model;
using UnityEngine;

namespace MyTask.CodeBase.Gameplay.Cards.Configs
{
    [CreateAssetMenu(menuName = "Configs/Cards/" + nameof(BoxRarityConfig), fileName = nameof(BoxRarityConfig))]
    public class BoxRarityConfig : ScriptableObject
    {
        public SerializedDictionary<EBoxRarity, SerializedDictionary<ECardRarity, float>> RarityValueByRarityBox => _rarityValueByRariryBox;

        [SerializedDictionary("Box Rarity", "Card Rarity"), SerializeField]
        private SerializedDictionary<EBoxRarity, SerializedDictionary<ECardRarity, float>> _rarityValueByRariryBox;
    }
}
