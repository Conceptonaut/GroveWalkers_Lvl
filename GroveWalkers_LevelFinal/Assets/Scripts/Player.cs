using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public bool isCrouched = false;
    private SporeCollection sporeCollection;

    public Light sporeLight;
    public bool hasSpore = false;

    // Start is called before the first frame update

    

    private void Awake()
    {
        instance = this;

        sporeCollection = FindObjectOfType<SporeCollection>();

        sporeLight = GetComponentInChildren<Light>();
        if (sporeLight == null)
        {
            Debug.LogWarning("Light component not found on the player GameObject.");
        }

        // Initially turn off the light
        if (sporeLight != null)
        {
            sporeLight.enabled = false;
        }

    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouched = true;
            Debug.Log("You are Crouched");
        }
        else
        {
            isCrouched = false;
            Debug.Log("You are no longer Crouched");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            sporeCollection.RemoveSpore(this.transform.position);
            hasSpore = false;
            UpdateLight();
        }

        if (hasSpore == true)
        {
            sporeLight.intensity -= .5f * Time.deltaTime;
        }
    }

    public bool IsCrouched()
    {
        return isCrouched;
    }
    public void OnSporeCollected(SporeCluster spore)
    {
        if (spore != null)
        {
            hasSpore = true;
            UpdateLight();
            sporeCollection.AddSpore(spore); // Add the collected spore to the SporeCollectionClass
            // Optionally, you can perform other actions upon collecting a spore
            
        }
    }

    void UpdateLight()
    {
        if (sporeLight != null)
        {
            sporeLight.enabled = hasSpore; // Enable light if the player has a spore, otherwise disable it
        }
    }

    
}
