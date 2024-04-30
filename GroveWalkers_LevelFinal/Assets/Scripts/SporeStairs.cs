using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeStairs : Interactable
{
    public GameObject pairedStairs;
    public float stairsTime = 2f;

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

        Debug.Log("Stairs Triggered");

        pairedStairs.transform.DOMoveZ(pairedStairs.transform.position.z - 4f, stairsTime);
        hasBeenTriggered = true;
        //this.transform.rotation = 
    }
}