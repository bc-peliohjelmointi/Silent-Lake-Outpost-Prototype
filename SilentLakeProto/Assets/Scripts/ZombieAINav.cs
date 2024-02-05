using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAINav : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;
    public GameObject Chase;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Chase.SetActive(true);
        }
    }

    void Update()
    {
        if (Chase.activeSelf)
        {
            agent.SetDestination(Player.position);
        }
    }
}
