using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (player.IsCrouched())
                {
                    if (Input.GetKeyDown(KeyCode.E) && (currentState == SporeState.Dormant || currentState ==  SporeState.Collected))
                    {
                        CollectSpore();
                        Debug.Log("You collected the spores!");
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
                    }
                }
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
        Player.instance.OnSporeCollected(this);
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
