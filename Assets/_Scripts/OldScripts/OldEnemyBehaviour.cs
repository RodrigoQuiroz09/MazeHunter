using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OldEnemyBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    public OldPlayerController player;
    public Transform[] corners;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Start() 
    {
        InvokeRepeating("GoTo",1,3f);
    }

    void GoTo()
    {
        if(Random.Range(1,100)>20)
        {
            agent.SetDestination(player.transform.position);
        }else{
            agent.SetDestination(corners[Random.Range(0,3)].position);
        }
        
    }

}
