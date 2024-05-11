using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SporePads : Interactable
{
    public GameObject padOne;
    public GameObject padTwo;
    public float padTime = 2f;

    public AudioSource lilyAudio;

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

        padOne.transform.DOMoveY(padOne.transform.position.y + 3f, padTime);
        lilyAudio.Play();
        Invoke("RaisePadTwo", 1);
        hasBeenTriggered = true;
        //this.transform.rotation = 
    }

    public void RaisePadTwo()
    {
        padTwo.transform.DOMoveY(padTwo.transform.position.y + 3f, padTime);
        lilyAudio.Play();

    }
}