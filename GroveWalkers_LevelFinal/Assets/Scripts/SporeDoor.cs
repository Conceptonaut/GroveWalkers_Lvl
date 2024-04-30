using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SporeDoor : Interactable
{
    public float doorOpenTime = 2f;

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

        this.transform.DORotate(new Vector3(0f, 90f, 0f), doorOpenTime);
        hasBeenTriggered = true;
        //this.transform.rotation = 
    }
}
