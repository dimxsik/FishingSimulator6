using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class FishController : MonoBehaviour
{
    [SerializeField] private GameObject[] fishPrefabs;
    [SerializeField] private GameObject hook;

    [SerializeField] private CaughtFishUIController caughtFishUIController;
    
    private float fishWeight;
    private float fishSize;
    private int fishIndex;
    private string fishName;
    private Sprite fishImage;
    public GameObject currentFish;

    private string currentFishName;
    
    private string[] childNames = { "FishV1(Clone)", "FishV2(Clone)", "FishV3(Clone)", "FishV4(Clone)" };
    private string[] fishNames = new string[] { "Karas", "Pike", "Carp", "Catfish" };
    public Sprite[] fishImages;

    private bool isFishSpawned;
    
    public Fish CreateNewFish()
    {
        fishIndex = Random.Range(0, fishPrefabs.Length);
        fishWeight = Random.Range(.1f, 10f);
        currentFish = fishPrefabs[fishIndex];
        fishName = fishNames[fishIndex];
        fishImage = fishImages[fishIndex];

        Fish newFish = new Fish(currentFish, fishName , fishWeight, fishImage);
        
        return newFish;
    }
    public bool IsFishSpawned()
    {
        return isFishSpawned;
    }

    public void InstantiateFish(Fish fish)
    {
        if (Random.Range(0, 10000) % 1250 == 0 && hook.transform.position.y <= 0f)
        {
            Instantiate(fish.Type,hook.transform);
            caughtFishUIController.CreateWindow(fish);
            currentFishName = fish.Name;
            
            isFishSpawned = true;
        }
    }

    public string CaughtFishName()
    {
        return currentFishName;
    }

    public void FishSwim()
    {
        float speed = 2f;
        var direction = new Vector3(Random.Range(-1f, 0.1f), Random.Range(-1f, 1f), 0).normalized;
        
        hook.transform.Translate( direction * speed * Time.deltaTime);
    }

    public void DestroyFish()
    {
        foreach (string childName in childNames)
        {
            Transform childTransform = hook.transform.Find(childName);
            if (childTransform != null)
            {
                isFishSpawned = false;
                Destroy(childTransform.gameObject);
            }
        }
    }
}