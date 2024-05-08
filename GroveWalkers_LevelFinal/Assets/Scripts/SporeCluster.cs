using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum SporeState
{
    Dormant,
    Fleeing,
    Collected
}

public class SporeCluster : MonoBehaviour
{
    public SporeState currentState = SporeState.Dormant;
    public Light sporeLight;
    public GameObject particleMesh;
    public Transform[] fleePoints;
    public SphereCollider triggerCollider;
    private NavMeshAgent agent;
    private bool isCollected;

    public Image customImage;

    public AudioSource sporeAudio;

    private Vector3 spawnPoint;

    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void ToggleMeshAndLight(bool active)
    {
        Debug.LogError("CHECK MESH ::: " + active);
        particleMesh.SetActive(active);
        sporeLight.enabled = active;
    }

    void Start()
    {
        spawnPoint = this.transform.position;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = false;
        }
    }

    bool isPlayer;
    public void Update()
    {
        if(isPlayer)
        {

            Debug.LogError("player is CROUCHED ::: " + player.IsCrouched() + " CURRENT STATE :::: " + currentState + " INPUT GETKEY " + Input.GetKeyDown(KeyCode.E));
            if (player.IsCrouched())
            {
                if (Input.GetKeyDown(KeyCode.E) && (currentState == SporeState.Dormant || currentState == SporeState.Collected))
                {
                    Debug.LogError("You collected the spores!");
                    CollectSpore();
                    isPlayer = false;
                }

            }
            else
            {
                if (currentState == SporeState.Dormant)
                {
                    currentState = SporeState.Fleeing;
                    triggerCollider.enabled = false;
                    Debug.Log("You distrubed the spores");
                    MoveToRandomFleePoint();
                    isPlayer = false;
                }
            }

        }
    }

    private Player player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            Debug.LogError("player ::: " + player.name);
            if (player != null)
            {
                isPlayer = true;
            }
            else
            {
                isPlayer= false;
            }
        }
    }
    private void MoveToRandomFleePoint()
    {
        if (fleePoints.Length > 0)
        {
            int randomIndex = Random.Range(0, fleePoints.Length);
            agent.SetDestination(fleePoints[randomIndex].position);
            agent.isStopped = false;
        }
    }

    private void CollectSpore()
    {
        currentState = SporeState.Collected;
        triggerCollider.enabled = false;
        ToggleMeshAndLight(false);
        sporeAudio.Play();
        Player.instance.OnSporeCollected(this);
        customImage.enabled = false;
    }

    public void StartRespawn()
    {
        Invoke("Respawn", CONTROLLER.SPORE_RESPAWN_TIMER);
    }

    private void Respawn()
    {
        this.transform.position = spawnPoint;
        ToggleMeshAndLight(true);
        triggerCollider.enabled = true;
        currentState = SporeState.Dormant;
       
    }

    public void DropSpore(Vector3 position)
    {
        if (currentState == SporeState.Collected)
        {
            this.transform.position = position;
            ToggleMeshAndLight(true);
           // currentState = SporeState.Dormant;
            triggerCollider.enabled = true;
        }
    }

}
