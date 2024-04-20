using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SporeCollection : MonoBehaviour
{
    [SerializeField]
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

    public void DestroySpore()
    {
        // GameObject Go = sporeInventory[sporeInventory.Count - 1].gameObject;

        sporeInventory[sporeInventory.Count - 1].StartRespawn();
        sporeInventory.RemoveAt(sporeInventory.Count - 1);
        //Destroy(Go);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
