using UnityEngine;
using System.Collections.Generic;
using System.Linq; // Needed for LINQ methods like Where

[CreateAssetMenu(fileName = "New Pack", menuName = "Trading Card Game/Pack Data")]
public class PackData : ScriptableObject
{
    public string packName;
    public Sprite packArt; // Optional: Art for the pack itself

    // --- Option A: Simple Rarity Pools (Easier to start) ---
    // Assign cards directly to rarity lists in the Inspector
    public List<CardData> commonCards;
    public List<CardData> uncommonCards;
    public List<CardData> rareCards;
    public List<CardData> legendaryCards;

    // --- Define Probabilities for each Rarity ---
    // These should ideally sum to 1 (or 100 if you prefer percentages)
    [Range(0f, 1f)] public float commonChance = 0.60f;
    [Range(0f, 1f)] public float uncommonChance = 0.25f;
    [Range(0f, 1f)] public float rareChance = 0.10f;
    [Range(0f, 1f)] public float legendaryChance = 0.05f;

    // Helper method to get a random card based on defined chances
    public CardData GetRandomCard()
    {
        float randomValue = Random.value; // Random number between 0.0 and 1.0

        if (randomValue <= legendaryChance && legendaryCards.Count > 0)
        {
            return legendaryCards[Random.Range(0, legendaryCards.Count)];
        }
        else if (randomValue <= legendaryChance + rareChance && rareCards.Count > 0)
        {
            return rareCards[Random.Range(0, rareCards.Count)];
        }
        else if (randomValue <= legendaryChance + rareChance + uncommonChance && uncommonCards.Count > 0)
        {
            return uncommonCards[Random.Range(0, uncommonCards.Count)];
        }
        else // Default to Common
        {
            // Check if commonCards list is not empty to avoid errors
            if (commonCards.Count > 0)
            {
                return commonCards[Random.Range(0, commonCards.Count)];
            }
            else
            {
                // Fallback: If no common cards, try another rarity or return null
                Debug.LogWarning($"Pack '{packName}' has no Common cards defined, and was selected as fallback.");
                // Try uncommon as a fallback if available
                if (uncommonCards.Count > 0) return uncommonCards[Random.Range(0, uncommonCards.Count)];
                // Add more fallbacks or return null/error card
                return null;
            }
        }

        // Note: This simple probability assumes you *always* get a card.
        // Ensure your chances add up close to 1.0 and lists aren't empty.
        // A more robust system would handle cases where a rarity pool might be empty.
    }


    // --- Option B: Weighted List (More flexible but slightly more complex) ---
    /*
    [System.Serializable]
    public struct CardDropInfo
    {
        public CardData card;
        public float weight; // Higher weight = higher chance
    }
    public List<CardDropInfo> possibleCards;

    public CardData GetRandomCardWeighted()
    {
        if (possibleCards == null || possibleCards.Count == 0) return null;

        float totalWeight = possibleCards.Sum(c => c.weight);
        float randomValue = Random.Range(0, totalWeight);
        float currentWeight = 0;

        foreach (var cardInfo in possibleCards)
        {
            currentWeight += cardInfo.weight;
            if (randomValue <= currentWeight)
            {
                return cardInfo.card;
            }
        }
        return possibleCards.Last().card; // Fallback
    }
    */
}