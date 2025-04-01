using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PackOpener : MonoBehaviour
{
    public GameObject cardPrefab; // Assign your CardDisplayPrefab here
    public Transform cardSpawnParent; // Assign the "Content" GameObject of the Scroll View here
    public int numberOfCardsToOpen = 5;

    void Start()
    {
        if (GameManager.Instance == null || GameManager.Instance.SelectedPack == null)
        {
            Debug.LogError("GameManager or SelectedPack not found! Cannot open pack.");
            // Maybe load back to selection scene or show an error message
            return;
        }

        if (cardPrefab == null || cardSpawnParent == null)
        {
            Debug.LogError("Card Prefab or Spawn Parent not assigned in the Inspector!");
            return;
        }

        OpenPack(GameManager.Instance.SelectedPack);
    }

    void OpenPack(PackData packData)
    {
        Debug.Log($"Opening Pack: {packData.packName}");

        // Clear any previously opened cards (optional)
        foreach (Transform child in cardSpawnParent)
        {
            Destroy(child.gameObject);
        }

        List<CardData> openedCards = new List<CardData>();

        for (int i = 0; i < numberOfCardsToOpen; i++)
        {
            CardData drawnCard = packData.GetRandomCard(); // Use the method from PackData
            if (drawnCard != null)
            {
                openedCards.Add(drawnCard);
            }
            else
            {
                Debug.LogWarning($"Failed to draw card #{i + 1} for pack {packData.packName}. Check pack configuration.");
                // Optionally add a placeholder 'error' card?
            }
        }

        // Optional: Sort cards by rarity or some other criteria before displaying
        // openedCards.Sort((a, b) => a.rarity.CompareTo(b.rarity));

        DisplayCards(openedCards);
    }

    void DisplayCards(List<CardData> cards)
    {
        foreach (CardData card in cards)
        {
            GameObject cardInstance = Instantiate(cardPrefab, cardSpawnParent);
            Image cardImage = cardInstance.GetComponent<Image>();

            if (cardImage != null && card.cardArt != null)
            {
                cardImage.sprite = card.cardArt;
                // Optional: Keep aspect ratio
                cardImage.preserveAspect = true;
            }
            else
            {
                Debug.LogWarning($"Card '{card.cardName}' is missing art or Card Instance is missing Image component.");
            }

            // You could add another script to cardInstance to hold CardData
            // or add text elements to display name/rarity etc.
            cardInstance.name = card.cardName; // Set GameObject name for clarity
        }
    }
}