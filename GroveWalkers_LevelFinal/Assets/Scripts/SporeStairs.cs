using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeStairs : Interactable
{
    public GameObject pairedStairs;
    public float stairsTime = 3f;

    public AudioSource stairsAudio;

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
        stairsAudio.Play();
        Invoke("StopAudio", 3);
        hasBeenTriggered = true;
        //this.transform.rotation = 
    }
    public void StopAudio()
    {
        stairsAudio.Stop();
    }

}