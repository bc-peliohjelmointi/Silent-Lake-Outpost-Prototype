using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAINav : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(Player.position);
        }
    }

    void Update()
    {

    }
}
