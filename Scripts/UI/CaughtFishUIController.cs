using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CaughtFishUIController : MonoBehaviour
{ 
    public GameObject caughtFishPanel;

    [SerializeField] private FishController fishController;
    [SerializeField] private Image fishImage;
    [SerializeField] private TextMeshProUGUI caughtFishText;
    
    public void CreateWindow(Fish fish)
    {
        Debug.Log(fish.Weight);
        caughtFishText.text = $"{fish.Name}, {(int)(fish.Weight * 100)}g";
        fishImage.sprite = fish.FishImage;
    }
    public void ShowWindow()
    {
        caughtFishPanel.SetActive(true);
    }
    
    public void CloseWindow()
    {
        caughtFishPanel.SetActive(false);
    }
    
}
