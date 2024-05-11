using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{
    public AudioSource splash;
    public GameObject tpPoint;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.instance.transform.position = tpPoint.transform.position;
            splash.Play();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
