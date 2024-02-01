using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieAINav : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.position);
    }
}
