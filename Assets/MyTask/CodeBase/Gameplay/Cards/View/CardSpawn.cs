using MyTask.CodeBase.Gameplay.Cards.Configs;
using MyTask.CodeBase.Gameplay.Cards.Model;
using MyTask.CodeBase.Gameplay.Lootbox.Model;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MyTask.CodeBase.Gameplay.Cards.View
{
    public class CardSpawn
    {
        [Inject] private CardConfig _cardConfig;
        [Inject] private BoxRarityConfig _boxRarityConfig;

        public GameObject GetRandomCard(EBoxRarity boxRarity)
        {
            var randomRarity = GetRandomRarity(boxRarity);

            var cardPrefab = _cardConfig.Get(randomRarity);

            if (cardPrefab == null)
            {
                Debug.LogError($"Prefab not found for rarity: {randomRarity}");
                return null;
            }

            return cardPrefab;
        }

        private ECardRarity GetRandomRarity(EBoxRarity boxRarity)
        {
            if (!_boxRarityConfig.RarityValueByRarityBox.TryGetValue(boxRarity, out var rarityWeights))
            {
                return ECardRarity.Rare;
            }

            float totalWeight = rarityWeights.Values.Sum();

            if (totalWeight <= 0)
            {
                return ECardRarity.Rare;
            }

            float randomValue = UnityEngine.Random.Range(0, totalWeight);
            float cumulativeWeight = 0;

            foreach (var rarity in rarityWeights)
            {
                cumulativeWeight += rarity.Value;
                if (randomValue <= cumulativeWeight)
                {
                    return rarity.Key;
                }
            }

            return ECardRarity.Rare;
        }
    }
}
