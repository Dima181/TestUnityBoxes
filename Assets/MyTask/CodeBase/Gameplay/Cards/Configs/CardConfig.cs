using AYellowpaper.SerializedCollections;
using MyTask.CodeBase.Gameplay.Cards.Model;
using System.Collections.Generic;
using UnityEngine;

namespace MyTask.CodeBase.Gameplay.Cards.Configs
{
    [CreateAssetMenu(menuName = "Configs/Cards/" + nameof(CardConfig), fileName = nameof(CardConfig))]
    public class CardConfig : ScriptableObject
    {
        public SerializedDictionary<ECardRarity, List<GameObject>> CardPrefabsByRarity => _cardPrefabsByRarity;

        [SerializedDictionary("Enum Rarity", "Card Prefab"), SerializeField]
        private SerializedDictionary<ECardRarity, List<GameObject>> _cardPrefabsByRarity;

        public GameObject Get(ECardRarity rarity)
        {
            if (!_cardPrefabsByRarity.TryGetValue(rarity, out var prefabs)
                || prefabs == null 
                || prefabs.Count == 0)
            {
                Debug.LogError($"No card for rarity {rarity}");
                return null;
            }

            return prefabs[Random.Range(0, prefabs.Count)];
        }
    }
}
