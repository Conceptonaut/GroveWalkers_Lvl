using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCollection : MonoBehaviour
{
    private List<SporeCluster> sporeInventory = new List<SporeCluster>();

    public void AddSpore(SporeCluster spore)
    {
        if (spore != null)
        {
            sporeInventory.Add(spore);
            //spore.gameObject.SetActive(false);
            Debug.Log("Spore added to Lantern!");
        }
        else
        {
            Debug.Log("Your lantern is already full");
        }
    }

    public void RemoveSpore(Vector3 position)
    {

        sporeInventory[sporeInventory.Count - 1].DropSpore(position);
        sporeInventory.RemoveAt(sporeInventory.Count - 1);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
