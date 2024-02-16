using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAINav : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform Player;
    public GameObject Chase;
    Animator animator; 

    Vector3 target;

    void Start()
    {
        if (!Chase.activeSelf)
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            if (!agent)
            {
                Debug.LogError("NavMeshAgent component not found.");
            }
            else
            {
                SetRandomDestination();
            }
        }
    }

    void Update()
    {
        if (Chase.activeSelf)
        {
            agent.SetDestination(Player.position);
            
            if (agent.velocity.magnitude > 0.1f)
            {
                
                animator.SetBool("Speed", true);
            }
            else
            {
                
                animator.SetBool("Speed", false);
            }
        }
        else
        {
            if (agent.remainingDistance < 0.5f)
            {
                SetRandomDestination();
            }
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomPoint = GetRandomPointInNavMesh();
        agent.SetDestination(randomPoint);
    }

    Vector3 GetRandomPointInNavMesh()
    {
        Vector3 randomPoint = Vector3.zero;

        NavMeshHit hit;
        for (int i = 0; i < 30; i++)
        {
            float randomX = Random.Range(-500f, 500f);
            float randomZ = Random.Range(-500f, 500f);

            randomPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }

        return randomPoint;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Chase.SetActive(true);
        }
    }
}
