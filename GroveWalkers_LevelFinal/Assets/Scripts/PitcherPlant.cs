using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherPlant : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public override void Interact()
    {
        base.Interact();

        Player.instance.CollectPlant();
    }
}
