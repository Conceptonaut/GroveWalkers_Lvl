using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    public static Player instance;

    public bool isCrouched = false;
    private SporeCollection sporeCollection;

    public GameObject plantLamp;
    public float lampTime = 1f;
    public Light sporeLight;
    public GameObject lanternSpores;
    public bool hasSpore = false;

    public float lightIntensity = 4;
    // Start is called before the first frame update

    public FirstPersonController FPScontroller;

    private void Awake()
    {
        instance = this;

        FPScontroller = GetComponent<FirstPersonController>();  

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

        if (Input.GetKeyDown(KeyCode.Q) && hasSpore == true)
        {
            sporeCollection.RemoveSpore(this.transform.position);
            hasSpore = false;
            UpdateLight();
        }

        if (hasSpore == true)
        {
            sporeLight.intensity -= .35f * Time.deltaTime;
            if (sporeLight.intensity <= 0)
            {
                hasSpore = false;
                sporeCollection.DestroySpore();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Key Hit");

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
            {
                Debug.Log("Raycast Hit Somethin");
                Debug.Log(hit.collider.name);

                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("interactable hit");
                    

                    Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                    if (interactable.requiresSpore == true)
                    {
                        Debug.Log("requires spore is true");

                        if (hasSpore)
                        {
                            Debug.Log("has spore");
                            if (interactable.hasBeenTriggered == false)
                            {
                                Debug.Log("interactable triggered");
                                hasSpore = false;
                                UpdateLight();
                                sporeCollection.DestroySpore();
                                interactable.Interact();
                            }
                        }
                    }
                    else
                    {
                        if (interactable.hasBeenTriggered == false)
                        {
                            interactable.Interact();
                            FPScontroller.cameraCanMove = false;


                        }

                    }
                }
            }
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
            sporeLight.intensity = lightIntensity;
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

    public void CollectPlant()
    {
        plantLamp.transform.DOMoveY(plantLamp.transform.position.y + 1f, lampTime);
    }
}
