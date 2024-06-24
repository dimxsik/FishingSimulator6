using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class Fish
{
    private GameObject type;
    private string name;
    private float weight;
    private float size;
    private Sprite image;

    public Fish(GameObject fishType, string fishName ,float fishWeight, Sprite fishImage)
    {
        type = fishType;
        name = fishName;
        weight = fishWeight;
        size = fishWeight / 4;
        image = fishImage;
        fishType.transform.localScale = new Vector3(size, size, size);
    }
    
    public GameObject Type
    {
        get
        {
            return type;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public Sprite FishImage
    {
        get
        {
            return image;
        }
    }

    public float Weight
    {
        get
        {
            return weight;
        }
    }
}