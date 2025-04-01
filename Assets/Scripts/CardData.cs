using UnityEngine;

// Enum to define rarities
public enum CardRarity { Common, Uncommon, Rare, Legendary }

[CreateAssetMenu(fileName = "New Card", menuName = "Trading Card Game/Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardArt; // Assign the card image here in the Inspector
    public CardRarity rarity;
    // Add other relevant card info if needed (description, stats, etc.)
    // public string description;
    // public int attackPower;
}