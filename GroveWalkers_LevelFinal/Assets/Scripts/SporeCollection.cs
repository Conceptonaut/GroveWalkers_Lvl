using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCollection : MonoBehaviour
{
    private SporeCluster currentSpore = null;
    public GameObject sporePrefab;

    public void AddSpore(SporeCluster spore)
    {
        if (currentSpore == null)
        {
            currentSpore = spore;
            Debug.Log("Spore added to Lantern!");
        }
        else
        {
            Debug.Log("Your lantern is already full");
        }
    }

    public void DropSpore()
    {
        if (currentSpore != null)
        {
            Debug.Log("You dropped your Spore");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
