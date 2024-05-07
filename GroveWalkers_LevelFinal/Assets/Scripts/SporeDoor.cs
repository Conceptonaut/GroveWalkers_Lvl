using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SporeDoor : Interactable
{
    public float doorOpenTime = 3f;

    public AudioSource doorAudio;

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

        this.transform.DORotate(new Vector3(0f, +90f, 0f), doorOpenTime);
        doorAudio.Play();
        Invoke("StopAudio", 2);

        hasBeenTriggered = true;
        //this.transform.rotation = 
    }

    public void StopAudio()
    {
        doorAudio.Stop();
    }
}
