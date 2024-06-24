using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Buoyancy : MonoBehaviour
{
    [SerializeField] private WaterSurface water = null;

    private WaterSearchParameters searchParameters = new WaterSearchParameters();
    private WaterSearchResult searchResult = new WaterSearchResult();
    
    [SerializeField] private List<Floaters> floaters = new List<Floaters>();
    
    [SerializeField] private float underWaterDrag = 3f;
    [SerializeField] private float underWaterAngularDrag = 1f;
    [SerializeField] private float defaultDrag = 0f;
    [SerializeField] private float defaultAngularDrag = 0.05f;

    [SerializeField] private bool isUnderWater = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        isUnderWater = false;
        for (int i = 0; i < floaters.Count; i++)
        {
            if (floaters[i].FloaterUpdate(rb, water, searchParameters, searchResult))
            {
                isUnderWater = true;
            }
        }
        
        SetState(isUnderWater);
    }

    private void SetState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = defaultDrag;
            rb.angularDrag = defaultAngularDrag;
        }
    }
    public bool GetIsUnderWater()
    {
        return isUnderWater;
    }
}

[System.Serializable]
public class Floaters
{
    [SerializeField] private float floatingPower = 2f;
    [SerializeField] private Transform floater;

    private bool underwater;

    public bool FloaterUpdate(Rigidbody rb, WaterSurface water, WaterSearchParameters searchParameters, WaterSearchResult searchResult)
    {
        searchParameters.startPosition = floater.position;
        water.FindWaterSurfaceHeight(searchParameters, out searchResult);
        
        float difference = floater.position.y - searchResult.height;
        if (difference < 0)
        {
            rb.AddForceAtPosition(Vector3.up * floatingPower * Math.Abs(difference), floater.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;
            }
        }
        else if (underwater)
        {
            underwater = false;
        }
        
        return underwater;
    }
}