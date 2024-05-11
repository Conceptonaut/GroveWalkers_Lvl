using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherPlant : MonoBehaviour
{

    public bool hasBeenTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && hasBeenTriggered == false)
        {
            Player.instance.CollectPlant();
            hasBeenTriggered = true;
        }
    }
   
}
