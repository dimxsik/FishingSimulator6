using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    public GameObject[] baits;
    [SerializeField] private GameObject[] baitsInInventory;
    [SerializeField] private GameObject[] fishInInvetory;
    
    [SerializeField] private GameObject[] baitPrefabs;
    public Transform hookTransform;

    [SerializeField] private TextMeshProUGUI coinsAmount;
    private GameObject currentBait;

    [SerializeField] private GameManager gameManager;

    public int selectedBait = 0;
    

    private void Start()
    {
        AttachBait();
    }

    private void Update()
    {
        gameManager.MoneyAmount(coinsAmount);
        gameManager.BaitsAmount(baits, baitsInInventory);
        gameManager.FishAmount(fishInInvetory);
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
    }
    
    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
    }


    public bool CanBeBaitChoosen()
    {
        string baitAmount = baits[selectedBait].GetComponentInChildren<TextMeshProUGUI>().text;

        if (int.Parse(baitAmount) == 0)
        {
            return false;
        }
        return true;
    }

    public void NextBait()
    {
        if (selectedBait < 3)
        {
            baits[selectedBait++].SetActive(false);
            baits[selectedBait].SetActive(true);
        }
        else
        {
            baits[3].SetActive(false);
            selectedBait = 0;
            baits[selectedBait].SetActive(true);
        }
    }
    
    public void AttachBait()
    {
        Destroy(currentBait);

        if (CanBeBaitChoosen())
        {
            currentBait = Instantiate(baitPrefabs[selectedBait], hookTransform.position, hookTransform.rotation);
        
            currentBait.transform.SetParent(hookTransform);
        }
    }

    public void DestroyBait()
    {
        Destroy(currentBait);
    }

    public int SelectedBaitID()
    {
        return selectedBait;
    }

}
