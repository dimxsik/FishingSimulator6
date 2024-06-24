using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private GameDataManager dataManager;
    private GameData gameData;
    
    [SerializeField] private InventoryUIController inventoryUIController;
    [SerializeField] private FishController fishController;

    void Start()
    {
        dataManager = FindObjectOfType<GameDataManager>();
        if (dataManager == null)
        {
            Debug.LogError("GameDataManager not found!");
            return;
        }
        if (!dataManager.GameDataExists())
        {
            gameData = new GameData();
            dataManager.SaveGameData(gameData);
            Debug.Log("Game data file created with initial values.");
        }
        else
        {
            gameData = dataManager.LoadGameData();
        }
    }

    public void MoneyAmount(TextMeshProUGUI text)
    {
        text.text = gameData.coins.ToString();
        dataManager.SaveGameData(gameData);
    }

    public void BaitsAmount(GameObject[] baits, GameObject[] baitsInInventory)
    {
        for (int i = 0; i < baits.Length; i++)
        {
            baits[i].GetComponentInChildren<TextMeshProUGUI>().text = gameData.bait[i].ToString();
            baitsInInventory[i].GetComponentInChildren<TextMeshProUGUI>().text = gameData.bait[i].ToString();
        }
        dataManager.SaveGameData(gameData);
    }
    
    public void FishAmount(GameObject[] fish)
    {
        for (int i = 0; i < fish.Length; i++)
        {
            fish[i].GetComponentInChildren<TextMeshProUGUI>().text = gameData.fish[i].ToString();
        }
        dataManager.SaveGameData(gameData);
    }
    
    public void MinusBait(int amount)
    {
        int selectedBait = inventoryUIController.SelectedBaitID();
        gameData.bait[selectedBait]-= amount;
    }
    
    public void BuyBait()
    {
        Button button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        
        GameObject parent = button.transform.parent.gameObject;

        switch (parent.name)
        {
            case "BaitCorn":
                if (gameData.coins >= 5)
                {
                    gameData.bait[0] += 1;
                    gameData.coins -= 5;
                }
                break;
            case "BaitWorm":
                if (gameData.coins >= 3)
                {
                    gameData.bait[1] += 1;
                    gameData.coins -= 3;
                }
                break;
            case "BaitPea":
                if (gameData.coins >= 4)
                {
                    gameData.bait[2] += 1;
                    gameData.coins -= 4;
                }
                break;
            case "BaitBread":
                if (gameData.coins >= 2)
                {
                    gameData.bait[3] += 1;
                    gameData.coins -= 2;
                }
                break;
        }
    }

    public void PickUpFish()
    {
        switch (fishController.CaughtFishName())
        {
            case "Karas":
                gameData.fish[0] += 1;
                break;
            case "Pike":
                gameData.fish[1] += 1;
                break;
            case "Carp":
                gameData.fish[2] += 1;
                break;
            case "Catfish":
                gameData.fish[3] += 1;
                break;
        }
    }
    
    public void SellFish()
    {
        Button button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        
        GameObject parent = button.transform.parent.gameObject;

        switch (parent.name)
        {
            case "Karas":
                if (gameData.fish[0] > 0)
                {
                    gameData.fish[0] -= 1;
                    gameData.coins += 2;
                }

                break;
            case "Pike":
                if (gameData.fish[1] > 0)
                {
                    gameData.fish[1] -= 1;
                    gameData.coins += 5;
                }

                break;
            case "Carp":
                if (gameData.fish[2] > 0)
                {
                    gameData.fish[2] -= 1;
                    gameData.coins += 4;
                }

                break;
            case "Catfish":
                if (gameData.fish[3] > 0)
                {
                    gameData.fish[3] -= 1;
                    gameData.coins += 6;
                }

                break;
        }
    }
}