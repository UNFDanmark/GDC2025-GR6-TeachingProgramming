using System;
using UnityEngine;
using UnityEngine.AI;

public class Evilscript : MonoBehaviour
{
    public NavMeshAgent agent;

    GameObject playerTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Hej jeg er evil");
        playerTarget = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTarget.transform.position);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        
    }
}
